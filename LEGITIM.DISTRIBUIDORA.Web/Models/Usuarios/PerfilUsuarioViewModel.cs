using LEGITIM.DISTRIBUIDORA.Domain.Models.Basic;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using SharpArch.NHibernate;
using NHibernate.Linq;
using LEGITIM.DISTRIBUIDORA.Web.Utils.Usuarios;
using LEGITIM.DISTRIBUIDORA.Utils;
using LEGITIM.DISTRIBUIDORA.Utils.Enums;
using SharpArch.Domain.PersistenceSupport;

namespace LEGITIM.DISTRIBUIDORA.Web.Models.Usuarios
{
    public class PerfilUsuarioViewModel
    {

        //INFOS USUARIO
        public int Id { set; get; }
        public int alunoId { set; get; }
        public int professorId { set; get; }

        [Display(Name = "Perfil")]
        public string Perfil { set; get; }

        [Display(Name = "Email")]
        public string Email { set; get; }

        [Display(Name = "Usuário")]
        public string Login { set; get; }

        [Display(Name = "Nome")]
        public string UsuarioNome { set; get; }

        [Display(Name = "Programas")]
        public IList<string> ProgramasNome { set; get; }

        [Display(Name = "Lattes")]
        public string LattesLink { set; get; }

        //FLUXO DE ETAPAS
        [Display(Name = "Matricula")]
        public string Matricula { set; get; }

        [Display(Name = "Detalhamento de tema")]
        public string SituacaoPreProjetoComData { set; get; }
        public string Path { set; get; }

        [Display(Name = "Orientador ")]
        public string OrientadorComSituacaoData { set; get; }

        [Display(Name = "Projeto ")]
        public string SituacaoProjetoComData { set; get; }
        public int ProjetoId { set; get; }

        [Display(Name = "Banca ")]
        public string SituacaoBancaComData { set; get; }
        public int BancaId { set; get; }

        //DATAS IMPORTANTES
        [Display(Name = "Datas de entrega do Detalhamento de tema")]
        public string DataInicioPreProjeto { set; get; }
        public string DataFimPreProjetoSubmissao { set; get; }
        public string DataFimPreProjetoAprovacao { set; get; }


        [Display(Name = "Datas de entrega do Projeto")]
        public string DataInicioProjeto { set; get; }
        public string DataFimProjetoSubmissao { set; get; }
        public string DataFimProjetoAprovacao { set; get; }

        [Display(Name = "Datas de entrega da versão preliminar")]
        public string DataInicioPreliminar { set; get; }
        public string DataFimPreliminarSubmissao { set; get; }
        public string DataFimPreliminarAprovacao { set; get; }

        [Display(Name = "Datas de marcação da Banca")]
        public string DataInicioBanca { set; get; }
        public string DataFimBancaSubmissao { set; get; }
        public string DataFimBancaAprovacao { set; get; }

        //VINCULO DE TRABALHO
        [Display(Name = "Possui Vínculo de Trabalho?")]
        public string PossuiVinculo { set; get; }

        [Display(Name = "Endereço Profissional")]
        public string EnderecoProfissional { set; get; }

        [Display(Name = "Cargo")]
        public string Cargo { set; get; }

        [Display(Name = "Tipo de Vínculo")]
        public string TipoVinculo { set; get; }

        [Display(Name = "Tipo de Instituição")]
        public string TipoInstituicao { set; get; }

        [Display(Name = "Expectativa de Atuação")]
        public string ExpectativaAtuacao { set; get; }

        [Display(Name = "Mesma Área de Trabalho")]
        public string MesmaAreaTrabalho { set; get; }

        //FINANCIADOR
        [Display(Name = "Programa de Fomento")]
        public string ProgramaFomento { set; get; }

        [Display(Name = "Número de Meses da Bolsa")]
        public int NumeroMesesBolsa { set; get; }

        //TODO_ERRO
        public string FLUXODEETAPAS = "Fluxo de Etapas";
        public string DATASIMPORTANTES = "Datas Importantes: ";
        public string VINCULOTRABALHO = "Vínculo de Trabalho";
        public string FINANCIADOR = "Financiador";
        public bool UsuarioAluno = false;

        private const string SEMSITUACAO = "Não possui";
        private const string SEMDATAS = "Administradores do curso não criaram as datas";

        public PerfilUsuarioViewModel Inicializa()
        {
            var model = new PerfilUsuarioViewModel();
            var usuario = UsuarioAtual.getUsuarioLogado();

            Perfil = usuario.Perfil.Descricao;
            Email = usuario.Email;
            Login = usuario.Login;
            UsuarioNome = usuario.Nome;

            return model;
        }

    }
}