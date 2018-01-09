using LIFE.JOY.Domain.Models.Basic;
using NHibernate.Linq;
using SharpArch.NHibernate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Xml.Serialization;
using System.Net.Http.Formatting;
using LIFE.JOY.API.Models.User;
using LIFE.JOY.Utils.SoftDelete;
using SharpArch.Domain.PersistenceSupport;

namespace LIFE.JOY.API.Controllers
{
    public class UserController : ApiController
    {



        public HttpResponseMessage Get(int id)
        {
            var test = 0;
            try
            {
                var dao = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey)
                                           .Query<Usuario>()
                                           .First(x => x.Id == id);
                var JsonModel = UserJsonModel.ConverterDominio(dao);
                //var userAsXML = ToXml(user);
                return Request.CreateResponse(HttpStatusCode.OK, JsonModel, JsonMediaTypeFormatter.DefaultMediaType);
            }
            catch (KeyNotFoundException)
            {
                var mensagem = string.Format("O Usuario {0} não foi encontrado", id);
                var error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error, JsonMediaTypeFormatter.DefaultMediaType);
            }
        }

        public HttpResponseMessage Post([FromBody] UserJsonModel UserJson)
        {
            UserJsonModel dao = new UserJsonModel();
            var usuario = UserJson.add();
            NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).SaveOrUpdate(usuario);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { controller = "User", id = usuario.Id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        [Route("api/user/Delete/{id}")]
        public HttpResponseMessage Delete([FromUri] int id)
        {

            var dao = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey)
                                           .Query<Usuario>()
                                           .First(x => x.Id == id);

            
            NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).Delete(dao);
            NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey).Flush();
          

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //[Route("api/carrinho/{idCarrinho}/produto/{idProduto}/quantidade")]
        //public HttpResponseMessage Put([FromBody]Produto produto, [FromUri] int idCarrinho, [FromUri] int idProduto)
        //{
        //    var dao = new CarrinhoDAO();
        //    var carrinho = dao.Busca(idCarrinho);

        //    carrinho.TrocaQuantidade(produto);

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}



        public string ToXml(Acao user)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Acao));
            StringWriter stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                xmlSerializer.Serialize(writer, user);
                return stringWriter.ToString();
            }
        }
    }
}
