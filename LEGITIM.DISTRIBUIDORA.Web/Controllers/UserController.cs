using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LEGITIM.DISTRIBUIDORA.Domain.Models.Basic;
using SharpArch.Domain.PersistenceSupport;
using SharpArch.NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LEGITIM.DISTRIBUIDORA.Web.Controllers
{
    public class UserController : ApiController 
    {
        //private readonly IRepository<Usuario> _usuarioRepository;
        //private readonly IRepository<Perfil> _perfilRepository;
        //private readonly IRepository<Acao> _acaoRepository;

        //public UserController(IRepository<Usuario> usuarioRepository,
        //                           IRepository<Perfil> perfilRepository,
        //                           IRepository<Acao> acaoRepository)

        //{
        //    _usuarioRepository = usuarioRepository;
        //    _perfilRepository = perfilRepository;
        //    _acaoRepository = acaoRepository;
        //}


        public HttpResponseMessage Get(int id)
        {
            try
            {
                var dao = NHibernateSession.CurrentFor(NHibernateSession.DefaultFactoryKey)
                                           .Query<Acao>()
                                           .First(x => x.Id == id);
                var user = dao;
                var userAsXML = ToXml(user);
                return Request.CreateResponse(HttpStatusCode.OK, userAsXML);
            }
            catch (KeyNotFoundException)
            {
                var mensagem = string.Format("O Usuario {0} não foi encontrado", id);
                var error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }
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
        //public HttpResponseMessage Post([FromBody] Carrinho carrinho)
        //{
        //    CarrinhoDAO dao = new CarrinhoDAO();
        //    dao.Adiciona(carrinho);

        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
        //    string location = Url.Link("DefaultApi", new { controller = "carrinho", id = carrinho.Id });
        //    response.Headers.Location = new Uri(location);

        //    return response;
        //}

        //[Route("api/carrinho/{idCarrinho}/produto/{idProduto}")]
        //public HttpResponseMessage Delete([FromUri] int idCarrinho, [FromUri] int idProduto)
        //{
        //    var dao = new CarrinhoDAO();
        //    var carrinho = dao.Busca(idCarrinho);
        //    carrinho.Remove(idProduto);
        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //[Route("api/carrinho/{idCarrinho}/produto/{idProduto}/quantidade")]
        //public HttpResponseMessage Put([FromBody]Produto produto, [FromUri] int idCarrinho, [FromUri] int idProduto)
        //{
        //    var dao = new CarrinhoDAO();
        //    var carrinho = dao.Busca(idCarrinho);

        //    carrinho.TrocaQuantidade(produto);

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

    }
}
