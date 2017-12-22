using LEGITIM.DISTRIBUIDORA.Domain.Models.Basic;
using LEGITIM.DISTRIBUIDORA.Utils.Enums;
using NHibernate.Linq;
using SharpArch.NHibernate;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LEGITIM.DISTRIBUIDORA.Web.Models.Usuarios;


namespace LEGITIM.DISTRIBUIDORA.Web.Models.Acoes
{
    public class AcaoViewModel
    {
        [Display(Name = "Identificador unico")]
        public int Id { set; get; }

        [Display(Name = "Controller")]
        public string Controller { set; get; }

        [Display(Name = "Action")]
        public string Action { get; set; }

        [Display(Name = "check box")]
        public bool check { set; get; }

        [Display(Name = "URL")]
        public string URL { get; set; }

        [Display(Name = "perfilId")]
        public int perfilId { get; set; }

        public IList<Acao> ListaAcoes { set; get; }

        public static AcaoViewModel ConverterDominio(Acao domain)
        {
            var model = new AcaoViewModel();
            
            if (domain == null) return model;
            var _acoesRepository = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).Query<Acao>();
            var _perfilRepository = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).Query<Perfil>();

            foreach (var item in _acoesRepository) { 
            model.Id = domain.Id;
            model.Controller = domain.Controller;
            model.Action = domain.Action;

            }
            return model;
        }


        public static AcaoViewModel DeterminaAcoesUsuario(Usuario domain)
        {
            var model = new AcaoViewModel();

            if (domain == null) return model;

            model.ListaAcoes = domain.Perfil.Acoes;

            return model;
        }

    }
}