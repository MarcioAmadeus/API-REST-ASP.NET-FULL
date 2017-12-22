using LEGITIM.DISTRIBUIDORA.Domain.Models.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using SharpArch.NHibernate;
using NHibernate.Linq;
using LEGITIM.DISTRIBUIDORA.Web.Utils.Usuarios;
using SharpArch.Domain.PersistenceSupport;
using LEGITIM.DISTRIBUIDORA.Utils.SoftDelete;
using LEGITIM.DISTRIBUIDORA.Web.Controllers;
using System.Web;
using System.Text.RegularExpressions;

namespace LEGITIM.DISTRIBUIDORA.Web.Models.Usuarios
{
    public class CadastraUsuarioViewModel
    {
        [Display(Name = "Identificador unico")]
        public int Id { set; get; }

        [Display(Name = "Login "), Required(ErrorMessage = "Campo Obrigatório")]
        public string Login { set; get; }

        [Display(Name = "Senha "), Required(ErrorMessage = "Campo Obrigatório")]
        public string Senha { set; get; }

        [Display(Name = "Confirmar Senha "), Required(ErrorMessage = "Campo Obrigatório")]
        public string ConfirmarSenha { set; get; }

        [Display(Name = "Nome"), Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { set; get; }

        [Display(Name = "Email"), Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { set; get; }


        [Display(Name = "Perfil"), Required(ErrorMessage = "Campo Obrigatório")]
        public int PerfilId { set; get; }

        [Display(Name = "Perfil")]
        public string PerfilDescricao { set; get; }

        [Display(Name = "Lattes")]
        public string Lattes { set; get; }

        [Display(Name = "CPF")]
        public string CPF { set; get; }

        [Display(Name = "Foto de Perfil")]
        public HttpPostedFileBase File { get; set; }

        [Display(Name = "Foto de Perfil")]
        public string PathFile { set; get; }

        [Display(Name = "Foto de Perfil")]
        public string FolderPhotos { set; get; }

        
        public CadastraUsuarioViewModel()
        {
            //InicializaProgramas();
        }

        public static CadastraUsuarioViewModel ConverterDominio(Usuario domain)
        {
            var model = new CadastraUsuarioViewModel();

            if (domain == null) return model;
            if (domain.PathPhoto != null && domain.PathPhoto != "")
            {
                string host = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
                var URL = host + "/Content/UsuarioPhoto" + "/" + domain.FolderPhotos + "/" + domain.PathPhoto;
                model.PathFile = URL;
            }
            model.Id = domain.Id;
            model.Login = domain.Login;
            model.Email = domain.Email;
            model.Nome = domain.Nome;
            if (domain.Perfil != null)
            {
                model.PerfilDescricao = domain.Perfil.Descricao;
                model.PerfilId = domain.Perfil.Id;
            }
            return model;
        }


        public bool ConfirmaSenha()
        {
            return this.Senha.Equals(this.ConfirmarSenha);
        }

        public bool LoginExistente(IRepository<Usuario> usuarioRepository)
        {
            var usuario = usuarioRepository.GetAll().FirstOrDefault(x => x.Login.Equals(this.Login.Trim()));
            return usuario != null;
        }

        public Usuario CadastrarUsuario(BasicController controller, Usuario User)
        {
            var domain = new Usuario();

            if (User != null)
            {
                domain = User;
            }

            if (domain.FolderPhotos == null)
            {
                domain.FolderPhotos = this.Login;
            }
            if (this.File != null)
            {

                bool exists = System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~/Content/UsuarioPhoto/" + domain.FolderPhotos));
                if (!exists)
                    System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/Content/UsuarioPhoto/" + domain.FolderPhotos));

                domain.PathPhoto = controller.Uploadfile(this.File, Regex.Replace(this.Nome, @"\s+", "")
                                                                            //+ this.Aluno.Matricula
                                                                            , "~/Content/UsuarioPhoto/" + domain.FolderPhotos);
            }


            domain.Login = this.Login;
            domain.Senha = Encryptor.MD5Hash(this.Senha);
            domain.Nome = this.Nome;
            domain.Email = this.Email;

            if (this.PerfilId != 0)
            {
                domain.Perfil = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey)
                                               .Query<Perfil>()
                                               .FirstOrDefault(x => x.Id == this.PerfilId);
            }


            return domain;
        }



        public void ExcluirUsuarioPorModel(IRepository<Usuario> usuarioRepository)
        {
            var usuario = usuarioRepository.GetAll().FirstOrDefault(x => x.Id == this.Id);
            usuarioRepository.SoftRemove(usuario);
        }
    }
}