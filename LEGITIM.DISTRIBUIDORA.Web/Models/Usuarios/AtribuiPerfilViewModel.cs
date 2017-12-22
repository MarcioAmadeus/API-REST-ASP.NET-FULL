using LEGITIM.DISTRIBUIDORA.Domain.Models.Basic;
using NHibernate.Linq;
using SharpArch.NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace LEGITIM.DISTRIBUIDORA.Web.Models.Usuarios
{
    public class AtribuiPerfilViewModel
    {
        [Display(Name = "Identificador unico")]
        public int Id { set; get; }

        [Display(Name = "Nome")]
        public string Nome { set; get; }

        [Display(Name = "Login")]
        public string Login { set; get; }

        [Display(Name = "Perfil")]
        public int? PerfilId { set; get; }

        [Display(Name = "Perfil")]
        public string PerfilDescricao { set; get; }

        [Display(Name = "Email")]
        public string Email { set; get; }

        public static AtribuiPerfilViewModel ConverterDominio(Usuario domain)
        {
            var model = new AtribuiPerfilViewModel();

            if (domain == null) return model;

            model.Id = domain.Id;
            model.Nome = domain.Nome;
            model.Login = domain.Login;
            model.Email = domain.Email;
            if (domain.Perfil != null)
            {
                model.PerfilDescricao = domain.Perfil.Descricao;
            }


            return model;
        }
    }
}