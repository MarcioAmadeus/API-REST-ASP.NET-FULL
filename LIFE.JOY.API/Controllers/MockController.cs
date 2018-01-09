using LIFE.JOY.Utils.Enums;
using LIFE.JOY.Domain.Models.Basic;
using SharpArch.Domain.PersistenceSupport;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LIFE.JOY.API.Utils.Usuarios;
using System.Net;
using System;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using FGV.EBAPE.Web.Utils.Usuarios;
using SharpArch.NHibernate;
using NHibernate.Linq;

namespace FGV.EBAPE.Web.Controllers
{
    public partial class MockController : Controller
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

        //public MockController(
        //  IRepository<Aluno> alunoRepository,
        //  IRepository<Perfil> perfilRepository,
        //  IRepository<Usuario> usuarioRepository,
        //  IRepository<Acao> acaoRepository
        //  //IRepository<Evento> eventoRepository,
        //  //IRepository<KitSubmissao> kitSubmissaoRepository

        //  )
        //{
        //    _perfilRepository = perfilRepository;
        //    _usuarioRepository = usuarioRepository;
        //    _acaoRepository = acaoRepository;
        //}

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
            var listaAcao = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey)
                .Query<Acao>().ToList();
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
                NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).SaveOrUpdate(AcaoCadastrarUsuarios);

                AcaoListaUsuarios = new Acao()
                {
                    Controller = "Usuário",
                    Action = "Gerenciar Usuários",
                    Prioridade = 9,
                    Pai = "Configurações",
                    PrioridadeInterna = 2,
                    URL = "/Usuario/ListaUsuario"
                };
                NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).SaveOrUpdate(AcaoListaUsuarios);

                AcaoEditarPermissoesPerfil = new Acao()
                {
                    Controller = "Usuário",
                    Action = "Editar Permissões de Perfil",
                    Prioridade = 9,
                    Pai = "Configurações",
                    PrioridadeInterna = 3,
                    URL = "/Usuario/EditarPermissao"
                };
                NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).SaveOrUpdate(AcaoEditarPermissoesPerfil);


                var GerenciarPermissao = new Acao()
                {
                    Controller = "Usuário",
                    Action = "Gerenciar Permissões de acesso do Perfil",
                    Prioridade = 9,
                    Pai = "Configurações",
                    PrioridadeInterna = 3,
                    URL = "/Usuario/EditarPermissao"
                };
                NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).SaveOrUpdate(GerenciarPermissao);


                var GerenciarProduto = new Acao()
                {
                    Controller = "Produto",
                    Action = "Gerenciar Produto",
                    Prioridade = 9,
                    Pai = "Configurações",
                    PrioridadeInterna = 3,
                    URL = "/Produto/GerenciarProduto"
                };
                NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).SaveOrUpdate(GerenciarProduto);


                var GerenciarDistribuidor = new Acao()
                {
                    Controller = "Fornecedores",
                    Action = "Gerenciar Fornecedores",
                    Prioridade = 9,
                    Pai = "Configurações",
                    PrioridadeInterna = 3,
                    URL = "Fornecedor/GerenciarDistribuidor"
                };
                NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).SaveOrUpdate(GerenciarDistribuidor);


                var GerenciarSegmento = new Acao()
                {
                    Controller = "Fornecedores",
                    Action = "Gerenciar Segmento",
                    Prioridade = 9,
                    Pai = "Configurações",
                    PrioridadeInterna = 3,
                    URL = "Fornecedor/GerenciarSegmento"
                };
                NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).SaveOrUpdate(GerenciarSegmento);


                var GerenciarPreco = new Acao()
                {
                    Controller = "Fornecedores",
                    Action = "Gerenciar Preco",
                    Prioridade = 9,
                    Pai = "Configurações",
                    PrioridadeInterna = 3,
                    URL = "Fornecedor/GerenciarPreco"
                };
                NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).SaveOrUpdate(GerenciarPreco);



            }
            #endregion

            #region Perfil
            var listaPerfil = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey)
                                               .Query<Perfil>().ToList();
            //= _perfilRepository.GetAll().ToList();
            var listaAcoesAluno = new List<Acao>();
            var listaAcoesProfessor = new List<Acao>();
            var listaAcoesAdmPrograma = new List<Acao>();
            var listaAcoesAdmSistema = new List<Acao>();
            var listaAcoesCoordenadorPrograma = new List<Acao>();
            var listaAcoesRegulacao = new List<Acao>();
            if (listaPerfil == null || listaPerfil.Count == 0)
            {
                foreach (Acao acao in NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey)
                .Query<Acao>().ToList())
                {
                    listaAcoesAdmSistema.Add(acao);
                }

                PerfilAdmnistradorSistema = new Perfil()
                {
                    Descricao = "Administrador do Sistema",
                    Acoes = listaAcoesAdmSistema
                };
                NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).SaveOrUpdate(PerfilAdmnistradorSistema);

                var Vendedor = new Perfil()
                {
                    Descricao = "Representante Comercial ",
                    Acoes = listaAcoesAdmSistema
                };
                NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).SaveOrUpdate(Vendedor);

                var Gerente = new Perfil()
                {
                    Descricao = "Gerente",
                    Acoes = listaAcoesAdmSistema
                };
                NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).SaveOrUpdate(Gerente);
            }
            #endregion

            #region Usuario
            var listaUsuario = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey)
                                               .Query<Usuario>().ToList(); 
            if (listaUsuario == null || listaUsuario.Count == 0)
            {
                var Usuario2 = new Usuario()
                {
                    Nome = "Felipe",
                    Login = "felipe@gmail.com",
                    Source = "google",
                    PhotoURL = "http://lorempixel.com/640/480",
                    Fullname = "Marcio Amadeus",
                    Gender = "Male",
                    Nickname = "Love God",
                    Birth = DateTime.Now.AddYears(-30),
                    Senha = Encryptor.MD5Hash("123"),
                    Bio = "Ele é discreto e cultua bons livros e ama os animais, tá ligado eu sou o bicho",
                    Perfil = PerfilAdmnistradorSistema
                };
                NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).SaveOrUpdate(Usuario2);

                var Usuario3 = new Usuario()
                {
                    Nome = "Amadeus",
                    Login = "marcioamamadeus@gmail.com",
                    Source = "google",
                    PhotoURL = "http://lorempixel.com/640/480",
                    Fullname = "Marcio Amadeus",
                    Gender = "Male",
                    Nickname = "Love God",
                    Birth = DateTime.Now.AddYears(-30),
                    Senha = Encryptor.MD5Hash("123"),
                    Bio = "Ele é discreto e cultua bons livros e ama os animais, tá ligado eu sou o bicho",
                    Perfil = PerfilAdmnistradorSistema
                };
                NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).SaveOrUpdate(Usuario3);
            }
            #endregion
        }
    }
}
