using LIFE.JOY.Domain.Models.Basic;
using LIFE.JOY.Utils.Enums;
using NHibernate.Linq;
using SharpArch.Domain.PersistenceSupport;
using SharpArch.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace LIFE.JOY.API.Utils.Usuarios
{
    public class UsuarioAtual
    {
        private const string PERMISSAONEGADA = "/Home/PermissaoNegada";
        private const string LOGAR = "/Usuario/LogaUsuario";
        private const string DATAEXPIRADA = "/Home/DataExpirada";
        private const string PERMISSAOCONCEDIDA = "true";

        public static void setListaIdsUsuarioNaSessao(List<int> ListaIds, string NomeSessao)
        {
            HttpContext.Current.Session[NomeSessao] = ListaIds;
        }

        public static List<int> getListaIdsUsuarioNaSessao(string NomeSessao)
        {
            return (List<int>)HttpContext.Current.Session[NomeSessao];
        }

   
        public static Boolean EstaLogado()
        {
            if (HttpContext.Current.Session["Username"] != null)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public static void Logar(Usuario usuario)
        {
            HttpContext.Current.Session["Username"] = usuario;
        }

        public static void AtualizaUsuario(IRepository<Usuario> usuarios)
        {
            var usuario = usuarios.GetAll().FirstOrDefault(x => x.Id == ((Usuario)HttpContext.Current.Session["Username"]).Id);
            HttpContext.Current.Session["Username"] = usuario;
        }

        public static void Deslogar()
        {
            if (HttpContext.Current.Session["Username"] != null)
            {
                HttpContext.Current.Session["Username"] = null;
            }
        }

        public static string PermissaoConcedida()
        {
            return PERMISSAOCONCEDIDA;
        }

        public static bool UsuarioAluno()
        {
            return ((Usuario)HttpContext.Current.Session["Username"]).Perfil.Descricao.Equals("Aluno");
        }

        public static Aluno getUsuarioAluno()
        {
            var aluno = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).Query<Aluno>()
                         .FirstOrDefault(x => x.Matricula.Equals(((Usuario)HttpContext.Current.Session["Username"]).Login));
            return aluno;
        }

        public static Aluno getUsuarioAlunoById(int id)
        {
            var aluno = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).Query<Aluno>()
                         .FirstOrDefault(x => x.Id == id);
            return aluno;
        }

        public static bool UsuarioProfessor()
        {
            return ((Usuario)HttpContext.Current.Session["Username"]).Perfil.Descricao.Equals("Professor");
        }


        public static bool UsuarioAdmSistema()
        {
            return ((Usuario)HttpContext.Current.Session["Username"]).Perfil.Descricao.Equals("Administrador do Sistema");
        }

        public static bool UsuarioAdmPrograma()
        {
            return ((Usuario)HttpContext.Current.Session["Username"]).Perfil.Descricao.Equals("Administrador de Programa");
        }

        public static Usuario getUsuarioAdmPrograma()
        {
            var admSys = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).Query<Usuario>()
                         .FirstOrDefault(x => x.Login.Equals(((Usuario)HttpContext.Current.Session["Username"]).Login));
            return admSys;
        }

        public static bool UsuarioCoorPrograma()
        {
            return ((Usuario)HttpContext.Current.Session["Username"]).Perfil.Descricao.Equals("Coordenador de Programa");
        }


        public static bool UsuarioRegulacao()
        {
            return ((Usuario)HttpContext.Current.Session["Username"]).Perfil.Descricao.Equals("Regulação");
        }

        

        public static void PreencherAcoesSePossivel(ControllerBase controllerBase)
        {
            if (EstaLogado())
            {
                IDictionary<string, IList<Acao>> DicionarioAcoes = new Dictionary<string, IList<Acao>>();
                var acoes = getUsuarioLogado().Perfil.Acoes.OrderBy(x => x.Prioridade).ToList();
                foreach (Acao acao in acoes)
                {
                    if (!DicionarioAcoes.ContainsKey(acao.Controller))
                    {
                        DicionarioAcoes.Add(acao.Controller, acoes.OrderBy(x=> x.PrioridadeInterna).ToList());
                    }
                }
                controllerBase.ViewBag.DicionarioAcoes = DicionarioAcoes;
            }
        }

        public static Usuario getUsuarioLogado()
        {
            return ((Usuario)HttpContext.Current.Session["Username"]);
        }

        public static Usuario getUsuarioLogadobyName(string name)
        {
            return NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).Query<Usuario>()
                .FirstOrDefault(x => x.Nome == name);
        }

        public static Acao getAcaoUsuarioParaUrl(string URL)
        {
            return ((Usuario)HttpContext.Current.Session["Username"]).Perfil.Acoes.FirstOrDefault(x => x.URL.Equals(URL));
        }

        public static string AcaoEstaDisponivel(String URL)
        {
            if (EstaLogado())
            {
                var acao = getAcaoUsuarioParaUrl(URL);
                if (acao != null)
                {
                    return PERMISSAOCONCEDIDA;
                }
                else return PERMISSAONEGADA;
            }
            else return LOGAR;
        }

        public static string AcaoEstaDisponivelComId(String URL, int Id, List<int> Lista)
        {
            if (EstaLogado())
            {
                var acao = getAcaoUsuarioParaUrl(URL);
                if (acao != null)
                {
                    if (Lista.Contains(Id))
                    {
                        return PERMISSAOCONCEDIDA;
                    }
                    else return PERMISSAONEGADA;
                }
                else return PERMISSAONEGADA;
            }
            else return LOGAR;
        }
    }
}
