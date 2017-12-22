using LEGITIM.DISTRIBUIDORA.Domain.Models.Basic;
using NHibernate.Linq;
using SharpArch.NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LEGITIM.DISTRIBUIDORA.Web.Models.Acoes;
using System.Linq;

namespace LEGITIM.DISTRIBUIDORA.Web.Models.Acoes
{
    public class PerfilAcaoViewModel
    {
        [Display(Name = "Identificador unico")]
        public int Id { set; get; }

        [Display(Name = "Perfil:")]
        public string PerfilDescricao { set; get; }
       

        public IList<AcaoViewModel> Acoes { set; get; }

        public static PerfilAcaoViewModel ConverterDominio(Perfil domain)
        {
            var model = new PerfilAcaoViewModel();

            if (domain == null) return model;

            model.Id = domain.Id;
            model.PerfilDescricao = domain.Descricao;
            var _acoesRepository = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).Query<Acao>();
            IList<Acao> listaacoes = domain.Acoes;
            model.Acoes = new List<AcaoViewModel>();
            foreach (var item in _acoesRepository.OrderBy(x => x.Controller))
            {
                var acaoViewModel = new AcaoViewModel();
                //var item = AcaoViewModel.ConverterDominio(itemacao);
                acaoViewModel.perfilId = model.Id;
                acaoViewModel.Id = item.Id;
                acaoViewModel.Action = item.Action;
                acaoViewModel.Controller = item.Controller;
                acaoViewModel.URL = item.URL;
                acaoViewModel.check = listaacoes.Contains(item);

                
                model.Acoes.Add(acaoViewModel);
            }

            return model;
        }

        public Perfil ConverterViewModelAdicionarAcao(PerfilAcaoViewModel model)
        {
            var domain = new Perfil();

            if (this.Id != 0)
            {
                domain = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).Query<Perfil>().FirstOrDefault(m => m.Id == this.Id);
            }

            if (this.Acoes != null)
            {
                foreach (var item in this.Acoes)
                {
                    if (item.check)
                    {
                        var _acoesRepository = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).Query<Acao>().FirstOrDefault(m => m.Id == item.Id);
                        domain.Acoes.Add(_acoesRepository);
                    }

                }
            }

            return domain;
        }

    }
}