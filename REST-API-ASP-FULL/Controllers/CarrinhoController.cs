﻿using Loja.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace REST_API_ASP_FULL.Controllers
{
    public class CarrinhoController : ApiController
    {

        public string Get(int id)
        {
            CarrinhoDAO dao = new CarrinhoDAO();
            var carrinho = dao.Busca(id);

            return carrinho.ToXml();
        }
    }
}
