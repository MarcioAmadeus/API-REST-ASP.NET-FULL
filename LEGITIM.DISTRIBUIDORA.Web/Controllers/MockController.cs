using LEGITIM.DISTRIBUIDORA.Utils.Enums;
using LEGITIM.DISTRIBUIDORA.Domain.Models.Basic;
using SharpArch.Domain.PersistenceSupport;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LEGITIM.DISTRIBUIDORA.Web.Utils.Usuarios;
using System.Net;
using System;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace LEGITIM.DISTRIBUIDORA.Web.Controllers
{
    public partial class MockController : BasicController
    {
        #region Construtor & Repositórios & private atributes
        private readonly IRepository<Perfil> _perfilRepository;
        private readonly IRepository<Acao> _acaoRepository;
        private readonly IRepository<Usuario> _usuarioRepository;

        private Perfil PerfilAluno;
        private Perfil PerfilProfessor;
        private Perfil PerfilAdmnistradorPrograma;
        private Perfil PerfilAdmnistradorSistema;
        private Perfil PerfilCoordenadorPrograma;
        private Perfil PerfilRegulacao;
        private Acao AcaoCadastrarLinhaPesquisa;
        private Acao AcaoListaLinhasPesquisa;
        private Acao AcaoCadastrarUsuarios;
        private Acao AcaoListaUsuarios;
        private Acao AcaoAssociarCoordenadores;
        private Acao AcaoEditarPermissoesPerfil;

        public MockController(
          IRepository<Aluno> alunoRepository,
          IRepository<Perfil> perfilRepository,
          IRepository<Usuario> usuarioRepository,
          IRepository<Acao> acaoRepository
          //IRepository<Evento> eventoRepository,
          //IRepository<KitSubmissao> kitSubmissaoRepository

          )
        {
            _perfilRepository = perfilRepository;
            _usuarioRepository = usuarioRepository;
            _acaoRepository = acaoRepository;
        }

        #endregion

        #region Index
        public virtual ActionResult Index()
        {
            Mock();
            return View();
        }
        #endregion

        private void Mock()
        {
            #region Acao
            var listaAcao = _acaoRepository.GetAll().ToList();
            if (listaAcao == null || listaAcao.Count == 0)
            {
                //USUARIO
                AcaoCadastrarUsuarios = new Acao()
                {
                    Controller = "Usuário",
                    Action = "Cadastrar Usuário",
                    Prioridade = 9,
                    Pai = "Configurações",
                    PrioridadeInterna = 1,
                    URL = "/Usuario/CadastraUsuario",
                    VisivelNoMenu = eSimNao.N
                };
                _acaoRepository.SaveOrUpdate(AcaoCadastrarUsuarios);
                AcaoListaUsuarios = new Acao()
                {
                    Controller = "Usuário",
                    Action = "Gerenciar Usuários",
                    Prioridade = 9,
                    Pai = "Configurações",
                    PrioridadeInterna = 2,
                    URL = "/Usuario/ListaUsuario"
                };
                _acaoRepository.SaveOrUpdate(AcaoListaUsuarios);

                AcaoEditarPermissoesPerfil = new Acao()
                {
                    Controller = "Usuário",
                    Action = "Editar Permissões de Perfil",
                    Prioridade = 9,
                    Pai = "Configurações",
                    PrioridadeInterna = 3,
                    URL = "/Usuario/EditarPermissao"
                };
                _acaoRepository.SaveOrUpdate(AcaoEditarPermissoesPerfil);


                var GerenciarPermissao = new Acao()
                {
                    Controller = "Usuário",
                    Action = "Gerenciar Permissões de acesso do Perfil",
                    Prioridade = 9,
                    Pai = "Configurações",
                    PrioridadeInterna = 3,
                    URL = "/Usuario/EditarPermissao"
                };
                _acaoRepository.SaveOrUpdate(GerenciarPermissao);


                var GerenciarProduto = new Acao()
                {
                    Controller = "Produto",
                    Action = "Gerenciar Produto",
                    Prioridade = 9,
                    Pai = "Configurações",
                    PrioridadeInterna = 3,
                    URL = "/Produto/GerenciarProduto"
                };
                _acaoRepository.SaveOrUpdate(GerenciarProduto);


                var GerenciarDistribuidor = new Acao()
                {
                    Controller = "Fornecedores",
                    Action = "Gerenciar Fornecedores",
                    Prioridade = 9,
                    Pai = "Configurações",
                    PrioridadeInterna = 3,
                    URL = "Fornecedor/GerenciarDistribuidor"
                };
                _acaoRepository.SaveOrUpdate(GerenciarDistribuidor);


                var GerenciarSegmento = new Acao()
                {
                    Controller = "Fornecedores",
                    Action = "Gerenciar Segmento",
                    Prioridade = 9,
                    Pai = "Configurações",
                    PrioridadeInterna = 3,
                    URL = "Fornecedor/GerenciarSegmento"
                };
                _acaoRepository.SaveOrUpdate(GerenciarSegmento);


                var GerenciarPreco = new Acao()
                {
                    Controller = "Fornecedores",
                    Action = "Gerenciar Preco",
                    Prioridade = 9,
                    Pai = "Configurações",
                    PrioridadeInterna = 3,
                    URL = "Fornecedor/GerenciarPreco"
                };
                _acaoRepository.SaveOrUpdate(GerenciarPreco);



            }
            #endregion

            #region Perfil
            var listaPerfil = _perfilRepository.GetAll().ToList();
            var listaAcoesAluno = new List<Acao>();
            var listaAcoesProfessor = new List<Acao>();
            var listaAcoesAdmPrograma = new List<Acao>();
            var listaAcoesAdmSistema = new List<Acao>();
            var listaAcoesCoordenadorPrograma = new List<Acao>();
            var listaAcoesRegulacao = new List<Acao>();
            if (listaPerfil == null || listaPerfil.Count == 0)
            {
                foreach (Acao acao in _acaoRepository.GetAll().ToList())
                {
                    listaAcoesAdmSistema.Add(acao);
                }

                PerfilAdmnistradorSistema = new Perfil()
                {
                    Descricao = "Administrador do Sistema",
                    Acoes = listaAcoesAdmSistema
                };
                _perfilRepository.SaveOrUpdate(PerfilAdmnistradorSistema);


                var Vendedor = new Perfil()
                {
                    Descricao = "Representante Comercial ",
                    Acoes = listaAcoesAdmSistema
                };
                _perfilRepository.SaveOrUpdate(Vendedor);

                var Gerente = new Perfil()
                {
                    Descricao = "Gerente",
                    Acoes = listaAcoesAdmSistema
                };
                _perfilRepository.SaveOrUpdate(Gerente);
            }
            #endregion

            #region Usuario
            var listaUsuario = _usuarioRepository.GetAll().ToList();
            if (listaUsuario == null || listaUsuario.Count == 0)
            {
                var Usuario2 = new Usuario()
                {
                    Nome = "Admnistrador",
                    Login = "admsistema",
                    Email = "marcioamamadeus@gmail.com",
                    Senha = Encryptor.MD5Hash("123"),
                    Perfil = PerfilAdmnistradorSistema
                };
                _usuarioRepository.SaveOrUpdate(Usuario2);
            }
            #endregion
        }
    }
}
