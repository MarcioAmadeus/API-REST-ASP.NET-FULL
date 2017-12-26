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

namespace LIFE.JOY.API.Controllers
{
    public class UserController : ApiController
    {


        public void test()
        {
            var test = 0;
            if(test == 0)
            {
                var ok = "ok";
            }
        }
        public HttpResponseMessage Get(int id)
        {
            var test = 0;
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
    }
}
