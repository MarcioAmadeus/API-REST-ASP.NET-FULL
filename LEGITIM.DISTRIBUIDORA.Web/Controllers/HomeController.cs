using LEGITIM.DISTRIBUIDORA.Domain.Models.Basic;
using LEGITIM.DISTRIBUIDORA.Web.Utils.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpArch.Domain.PersistenceSupport;
using LEGITIM.DISTRIBUIDORA.Utils.SoftDelete;
using LEGITIM.DISTRIBUIDORA.Utils.Enums;
using LEGITIM.DISTRIBUIDORA.Utils;

namespace LEGITIM.DISTRIBUIDORA.Web.Controllers
{
    public class HomeController : BasicController
    {
        #region Construtor & Repositórios

        private readonly IRepository<Aluno> _alunoRepository;

        public HomeController(
            IRepository<Aluno> alunoRepository
            )
        {
        }

        #endregion
        // GET: Home
        public ActionResult Index(string resultado = null)
        {
            return View();
        }

        public ActionResult PermissaoNegada()
        {
            UsuarioAtual.PreencherAcoesSePossivel(this);
            return View();
        }

        public ActionResult DataExpirada()
        {
            UsuarioAtual.PreencherAcoesSePossivel(this);
            return View();
        }

        public ActionResult PreenchimentoPendente()
        {
            UsuarioAtual.PreencherAcoesSePossivel(this);
            return View();
        }

        private void PreencherViewHome(string resultado)
        {
            if (resultado != null)
            {
                ViewBag.ResultadoHome = resultado;
            }
        }
    }
}