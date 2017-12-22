using LEGITIM.DISTRIBUIDORA.Domain.Models.Basic;
using SharpArch.Domain.PersistenceSupport;
using System.Linq;
using System.Web.Mvc;
using LEGITIM.DISTRIBUIDORA.Web.Models.Usuarios;
using LEGITIM.DISTRIBUIDORA.Web.Utils.Usuarios;
using LEGITIM.DISTRIBUIDORA.Web.Models.Acoes;

namespace LEGITIM.DISTRIBUIDORA.Web.Controllers
{
    public class UsuarioController : BasicController
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IRepository<Perfil> _perfilRepository;
        private readonly IRepository<Acao> _acaoRepository;
        private readonly IRepository<Aluno> _alunoRepository;
        //TODO_ERRO
        private const string SUCESSO = "Usuário logado com sucesso!";
        private const string CADASTROSUCESSO = "Cadastro realizado com sucesso!";
        private const string FALHA = "Usuário e/ou Senha inválidos!";
        private const string SEMPERFIL = "Usuário não possui perfil associado!";
        private const string SENHAERRADA = "Senhas não correspondem!";
        private const string ACOESSALVAS = "Ações do perfil salvas com sucesso!";
        private const string LOGINEXISTENTE = "Login de usuário já existe, tente outro!";
        private const string SEMPROGRAMAS = "Usuário não possui programa associado!";
        private const string LISTAIDSSESSAO = "usuarios_usuario";
        private const string EDICAOSUCESSO = "Edição realizada com sucesso!";


        public UsuarioController(IRepository<Usuario> usuarioRepository,
                                   IRepository<Perfil> perfilRepository,
                                   IRepository<Aluno> alunoRepository,
                                   IRepository<Acao> acaoRepository)

        {
            _alunoRepository = alunoRepository;
            _usuarioRepository = usuarioRepository;
            _perfilRepository = perfilRepository;
            _acaoRepository = acaoRepository;
        }

        #region Logar Usuario
        public virtual ActionResult LogaUsuario()
        {
            if (!UsuarioAtual.EstaLogado())
            {
                var model = new UsuarioViewModel() { };
                UsuarioAtual.PreencherAcoesSePossivel(this);
                return View(model);
            }
            else
            {
                return RedirectToAction("Deslogar");
            }
        }

        [HttpPost]
        public virtual ActionResult LogaUsuario(UsuarioViewModel model)
        {
            var UsuarioValido = model.LogaUsuario();
            if (ModelState.IsValid)
            {
                if (UsuarioValido)
                {
                    if (UsuarioAtual.getUsuarioLogado().Perfil != null)
                    {
                        PreencherViewBag(SUCESSO, null);
                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        UsuarioAtual.Deslogar();
                        PreencherViewBag(null, SEMPERFIL);
                        return View(model);
                    }
                }
                else
                {
                    PreencherViewBag(null, FALHA);
                    return View(model);
                }
            }
            else
            {
                PreencherViewBag();
                return View(model);
            }
        }
        #endregion

        #region Deslogar
        public virtual ActionResult Deslogar()
        {
            if (!UsuarioAtual.EstaLogado())
            {
                return RedirectToAction("LogaUsuario");
            }
            else
            {
                var model = UsuarioViewModel.ConverterDominio(UsuarioAtual.getUsuarioLogado());
                PreencherViewBag();
                Deslogar(model);
                return RedirectToAction("LogaUsuario");
            }
        }
        [HttpPost]
        private void Deslogar(UsuarioViewModel model)
        {
            UsuarioAtual.Deslogar();
        }
        #endregion

        #region Lista de Usuario
        public virtual ActionResult ListaUsuario()
        {
            var disponibilidade = UsuarioAtual.AcaoEstaDisponivel("/Usuario/ListaUsuario");
            if (disponibilidade.Equals(UsuarioAtual.PermissaoConcedida()))
            {
                var model = new UsuarioViewModel() { };
                model.InicializaAtribuiPerfilViewModel();
                UsuarioAtual.setListaIdsUsuarioNaSessao(model.ListaAtribuiPerfil.Select(x => x.Id).ToList(), LISTAIDSSESSAO);
                PreencherViewBag();
                return View(model);
            }
            else return Redirect(disponibilidade);
        }
        #endregion

        #region Excluir Usuario
        public virtual ActionResult ExcluirUsuario(int usuarioId = 0)
        {
            var disponibilidade = UsuarioAtual.AcaoEstaDisponivelComId("/Usuario/ListaUsuario"
            , usuarioId
            , UsuarioAtual.getListaIdsUsuarioNaSessao(LISTAIDSSESSAO));
            if (disponibilidade.Equals(UsuarioAtual.PermissaoConcedida()))
            {
                var usuario = _usuarioRepository.GetAll().FirstOrDefault(x => x.Id == usuarioId);
                var model = CadastraUsuarioViewModel.ConverterDominio(usuario);
                PreencherViewBag();
                return View(model);
            }
            else return Redirect(disponibilidade);
        }

        [HttpPost]
        public virtual ActionResult ExcluirUsuario(CadastraUsuarioViewModel model)
        {
            model.ExcluirUsuarioPorModel(_usuarioRepository);

            return RedirectToAction("ListaUsuario");
        }
        #endregion

        #region Editar Permissoes do Perfil
        public virtual ActionResult EditarPermissao(int? PerfilId)
        {
            if (PerfilId == 0 || PerfilId == null)
            {
                PerfilId = 1;
            }
            var disponibilidade = UsuarioAtual.AcaoEstaDisponivel("/Usuario/EditarPermissao");
            if (disponibilidade.Equals(UsuarioAtual.PermissaoConcedida()))
            {

                var editarViewModel = _perfilRepository.GetAll()
                                  .Select(PerfilAcaoViewModel.ConverterDominio)
                                  .FirstOrDefault(m => m.Id == PerfilId);

                PreencherViewBag();
                return View(editarViewModel);
            }
            else return Redirect(disponibilidade);
        }

        [HttpPost]
        public virtual ActionResult EditarPermissao(PerfilAcaoViewModel model)
        {
            var envio = ConverterViewModelAdicionarAcao(model);
            var editarViewModel = _perfilRepository.GetAll()
                                 .Select(PerfilAcaoViewModel.ConverterDominio)
                                 .FirstOrDefault(m => m.Id == model.Id);
            PreencherViewBag(ACOESSALVAS, null);
            UsuarioAtual.AtualizaUsuario(_usuarioRepository);
            return View(editarViewModel);
        }
        #endregion

        #region Cadastrar Usuario
        public virtual ActionResult CadastraUsuario(string resultado = null, int userId = 0, string falha = null)
        {
            var disponibilidade = UsuarioAtual.AcaoEstaDisponivel("/Usuario/CadastraUsuario");
            if (disponibilidade.Equals(UsuarioAtual.PermissaoConcedida()))
            {
                var model = new CadastraUsuarioViewModel() { };
                if (userId != 0)
                {

                    var user = _usuarioRepository.GetAll().FirstOrDefault(x => x.Id == userId);
                    model = CadastraUsuarioViewModel.ConverterDominio(user);
                }

                PreencherViewBag(resultado, falha);
                return View(model);
            }
            else return Redirect(disponibilidade);
        }

        [HttpPost]
        public virtual ActionResult CadastraUsuario(CadastraUsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!model.LoginExistente(_usuarioRepository))
                {
                    if (model.Id != 0 && model.ConfirmaSenha())
                    {
                        var usuario = _usuarioRepository.GetAll().FirstOrDefault(x => x.Id == model.Id);
                        var usuarioDonain = model.CadastrarUsuario(this, usuario);
                        _usuarioRepository.SaveOrUpdate(usuarioDonain);


                        return RedirectToAction("CadastraUsuario", new { resultado = "", falha = "" });
                    }
                    else if (model.ConfirmaSenha())
                    {
                        var usuario = model.CadastrarUsuario(this, null);
                        _usuarioRepository.SaveOrUpdate(usuario);

                        return RedirectToAction("CadastraUsuario", new { resultado = CADASTROSUCESSO, falha = "" });

                    }
                    else
                    {
                        PreencherViewBag(null, SENHAERRADA);
                        return View(model);
                    }
                }
                else
                {
                    PreencherViewBag(null, LOGINEXISTENTE);
                    return View(model);
                }
            }
            else
            {
                PreencherViewBag();
                return View(model);
            }
        }
        #endregion

        #region Editar Usuario
        public virtual ActionResult EditarUsuario(string resultado = null, int userId = 0, string falha = null)
        {
            var disponibilidade = UsuarioAtual.AcaoEstaDisponivel("/Usuario/CadastraUsuario");
            if (disponibilidade.Equals(UsuarioAtual.PermissaoConcedida()))
            {
                var model = new CadastraUsuarioViewModel() { };
                if (userId != 0)
                {

                    var user = _usuarioRepository.GetAll().FirstOrDefault(x => x.Id == userId);
                    model = CadastraUsuarioViewModel.ConverterDominio(user);
                }

                PreencherViewBag(resultado, falha, null, userId);

                return View(model);
            }
            else return Redirect(disponibilidade);
        }

        [HttpPost]
        public virtual ActionResult EditarUsuario(CadastraUsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var login = _usuarioRepository.GetAll().FirstOrDefault(x => x.Id == model.Id).Login;
                if (login.Equals(model.Login))
                {
                    var usuario = _usuarioRepository.GetAll().FirstOrDefault(x => x.Id == model.Id);
                    if (model.Id != 0 && model.ConfirmaSenha())
                    {
                      
                        var usuarioDonain = model.CadastrarUsuario(this, usuario);
                        _usuarioRepository.SaveOrUpdate(usuarioDonain);


                        return RedirectToAction("EditarUsuario", new { resultado = EDICAOSUCESSO, userId = usuario.Id, falha = "" });
                    }
                    else if (model.ConfirmaSenha())
                    {
                        var usuarioDomain = model.CadastrarUsuario(this, null);
                        _usuarioRepository.SaveOrUpdate(usuarioDomain);

                        return RedirectToAction("EditarUsuario", new { resultado = EDICAOSUCESSO, userId = usuario.Id,  falha = "" });

                    }
                    else
                    {
                        PreencherViewBag(null, SENHAERRADA);
                        return View(model);
                    }
                }
                else if(!model.LoginExistente(_usuarioRepository))
                {
                    if (model.Id != 0 && model.ConfirmaSenha())
                    {
                        var usuario = _usuarioRepository.GetAll().FirstOrDefault(x => x.Id == model.Id);
                        var usuarioDonain = model.CadastrarUsuario(this, usuario);
                        _usuarioRepository.SaveOrUpdate(usuarioDonain);


                        return RedirectToAction("EditarUsuario", new { resultado = EDICAOSUCESSO, userId = usuario.Id, falha = "" });
                    }
                    else if (model.ConfirmaSenha())
                    {
                        var usuario = model.CadastrarUsuario(this, null);
                        _usuarioRepository.SaveOrUpdate(usuario);

                        return RedirectToAction("EditarUsuario", new { resultado = EDICAOSUCESSO, userId = usuario.Id, falha = "" });

                    }
                    else
                    {
                        PreencherViewBag(null, SENHAERRADA);
                        return View(model);
                    }
                }
                else
                {
                    PreencherViewBag(null, LOGINEXISTENTE);
                    return View(model);
                }
            }
            else
            {
                PreencherViewBag();
                return View(model);
            }
        }
        #endregion


        #region Perfil de Usuario
        public virtual ActionResult PerfilUsuario(string resultado = null, string falha = null, string aviso = null)
        {
            if (!UsuarioAtual.EstaLogado())
            {
                return RedirectToAction("LogaUsuario");
            }
            else
            {
                var model = new PerfilUsuarioViewModel() { };
                PreencherViewBag(resultado, falha, aviso);
                return View(model);
            }
        }

        #endregion

        #region Metodos Privados

        private void PreencherViewBagOrigem(int aluniId)
        {
            if (aluniId != 0)
            {
                ViewBag.Origem = "Lista";
            }
        }
        private void PreencherViewBag(string resultado = null, string falha = null, string aviso = null, int userId = 0)
        {
            UsuarioAtual.PreencherAcoesSePossivel(this);
            var lista1 = _perfilRepository.GetAll().OrderBy(x => x.Descricao).ToList();

            ViewBag.Resultado = resultado;
            ViewBag.Falha = falha;
            ViewBag.Aviso = aviso;
            ViewBag.Perfis = lista1;
            SelectList listaPerfis = new SelectList(lista1, "Id", "Descricao", userId);
            ViewBag.PerfisEdit = listaPerfis;
        }

        private Perfil ConverterViewModelAdicionarAcao(PerfilAcaoViewModel model)
        {
            var domain = new Perfil();

            if (model == null) return domain;

            if (model.Id != 0)
            {
                domain = _perfilRepository.GetAll().FirstOrDefault(m => m.Id == model.Id);
            }

            var test = domain.Acoes;
            domain.Acoes.Clear();
            var testClear = domain.Acoes;

            if (model.Acoes != null && model.Acoes.Count > 0)
            {
                for (int i = 0; i < model.Acoes.Count; i++)
                {
                    if (model.Acoes[i].check)
                    {
                        var intanciaAcao = _acaoRepository.GetAll().FirstOrDefault(m => m.Id == model.Acoes[i].Id);
                        domain.Acoes.Add(intanciaAcao);
                    }
                }
                _perfilRepository.SaveOrUpdate(domain);
            }

            return domain;
        }
        #endregion

    }

}