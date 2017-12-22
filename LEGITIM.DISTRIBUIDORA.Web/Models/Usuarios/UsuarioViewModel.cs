using LEGITIM.DISTRIBUIDORA.Domain.Models.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using SharpArch.NHibernate;
using NHibernate.Linq;
using LEGITIM.DISTRIBUIDORA.Web.Utils.Usuarios;
using LEGITIM.DISTRIBUIDORA.Utils;

namespace LEGITIM.DISTRIBUIDORA.Web.Models.Usuarios
{
    public class UsuarioViewModel
    {
        [Display(Name = "Identificador unico")]
        public int Id { set; get; }

        [Display(Name = "Login "), Required(ErrorMessage = "Campo Obrigatório")]
        public string Login { set; get; }

        [Display(Name = "Senha "), Required(ErrorMessage = "Campo Obrigatório")]
        public string Senha { set; get; }
        
        [Display(Name = "Nome")]
        public string Nome { set; get; }

        [Display(Name = "Nome Coordenador")]
        public string NomeCoordenador { set; get; }

        [Display(Name = "Sigla")]
        public string Sigla { set; get; }
        [Display(Name = "Curso")]
        public string Curso { set; get; }

        [Display(Name = "Perfil")]
        public string Perfil { set; get; }

        [Display(Name = "Perfil")]
        public int PerfilId { set; get; }

        public IList<AtribuiPerfilViewModel> ListaAtribuiPerfil { set; get; }

        public static UsuarioViewModel ConverterDominio(Usuario domain)
        {
            var model = new UsuarioViewModel();

            if (domain == null) return model;

            model.Id = domain.Id;
            model.Login = domain.Login;
            model.Senha = domain.Senha;
            model.Nome = domain.Nome;
            if (domain.Perfil != null)
            {
                model.Perfil = domain.Perfil.Descricao;
            }

            return model;
        }


        public Boolean LogaUsuario()
        {
            Boolean confirmado = ConfirmacaoUsuario(this.Login, this.Senha);

            return confirmado;
        }

        private Boolean ConfirmacaoUsuario(string login, string senha)
        {
            login = login.Trim();
            senha = Encryptor.MD5Hash(senha.Trim());
            var usuario = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey)
                                               .Query<Usuario>()
                                               .FirstOrDefault(x => x.Login.Equals(login));
            if (usuario != null)
            {
                if (usuario.Senha.Equals(senha))
                {
                    UsuarioAtual.Logar(usuario);
                    return true;
                }
                return false;
            }
            else return false;
        }

        public UsuarioViewModel InicializaAtribuiPerfilViewModel()
        {
            ListaAtribuiPerfil = new List<AtribuiPerfilViewModel>();
            var usuarios = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey)
                                            .Query<Usuario>().ToList();

            foreach (Usuario usuario in usuarios)
            {
                this.ListaAtribuiPerfil.Add(AtribuiPerfilViewModel.ConverterDominio(usuario));
            }

            return this;
        }

        public List<Usuario> ConverterUsuarioViewModel()
        {
            var ListaUsuarios = new List<Usuario>();

            var usuarios = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey)
                                            .Query<Usuario>();
            var perfis = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey)
                                          .Query<Perfil>();

            foreach (AtribuiPerfilViewModel usuariomodel in this.ListaAtribuiPerfil)
            {
                if (usuariomodel.PerfilId != null)
                {
                    var usuario = usuarios.FirstOrDefault(x => x.Id == usuariomodel.Id);
                    usuario.Perfil = perfis.FirstOrDefault(x => x.Id == usuariomodel.PerfilId);
                    ListaUsuarios.Add(usuario);
                }
            }

            return ListaUsuarios;
        }

    }
}