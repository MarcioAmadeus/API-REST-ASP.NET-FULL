using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LIFE.JOY.Domain.Models.Basic;
using FGV.EBAPE.Web.Utils.Usuarios;
using SharpArch.NHibernate;
using NHibernate.Linq;

namespace LIFE.JOY.API.Models.User
{
    public class UserJsonModel
    {

        public int Id { set; get; }
        public string Nome { set; get; }
        public string Login { get; set; }
        public string Source { get; set; }
        public string PhotoURL { get; set; }
        public string Fullname { get; set; }
        public string Gender { get; set; }
        public string Nickname { get; set; }
        public DateTime Birth { get; set; }
        public string BirthAsString { get; set; }
        public string Bio { get; set; }
        public string Senha { get; set; }
        public string PessoaId { get; set; }
        public Perfil Perfil { get; set; }
        public string PerfilAsString { get; set; }
        public int PerfilId { get; set; }


        public static UserJsonModel ConverterDominio(Usuario domain)
        {
            var model = new UserJsonModel();

            if (domain == null) return model;

            model.Id = domain.Id;
            model.Nome = domain.Nome;
            model.Login = domain.Login;
            model.Source = domain.Source;
            model.PhotoURL = domain.PhotoURL;
            model.Fullname = domain.Fullname;
            model.Gender = domain.Gender;
            model.Nickname = domain.Nickname;
            model.BirthAsString = domain.Birth.ToString();
            model.Bio = domain.Bio;
            model.Senha = domain.Senha;


            if (domain.Perfil != null)
            {
                model.PerfilAsString = domain.Perfil.Descricao;
                model.PerfilId = domain.Perfil.Id;
            }
            return model;
        }

        public Usuario add(int id = 0)
        {
            var domain = new Usuario();

            if(id != 0)
            {
                domain.Id.Equals(id);
            }
            domain.Login = this.Login;
            domain.Nome = this.Nome;
            domain.Source = this.Source;
            domain.PhotoURL = this.PhotoURL;
            domain.Fullname = this.Fullname;
            domain.Gender = this.Gender;
            domain.Nickname = this.Nickname;
            domain.Birth = Convert.ToDateTime(this.BirthAsString);
            //domain.Birth = DateTime.ParseExact(this.BirthAsString, "dd-MM-yyyy HH:mm:ss",
            //                           System.Globalization.CultureInfo.InvariantCulture);
            domain.Bio = this.Bio;
            domain.Senha = Encryptor.MD5Hash(this.Senha);
           

            if (this.PerfilId != 0)
            {
                domain.Perfil = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey)
                                               .Query<Perfil>()
                                               .FirstOrDefault(x => x.Id == this.PerfilId);
            }


            return domain;
        }
    }
}