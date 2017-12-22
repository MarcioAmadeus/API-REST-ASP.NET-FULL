using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.IO;
using LEGITIM.DISTRIBUIDORA.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using LEGITIM.DISTRIBUIDORA.Web.Utils;


namespace LEGITIM.DISTRIBUIDORA.Web.Controllers
{
    public class BasicController : Controller
    {
        #region Download
        public virtual ActionResult download(string name, string directory)
        {
            var Path_ = Regex.Replace(name, @"\s+", "");
            var actualPath = Path.Combine(Server.MapPath(directory), Path_);
            return File(actualPath, "application/pdf", Server.UrlEncode(Path_));
        }
        #endregion

        #region Upload
        public string Uploadfile(HttpPostedFileBase file, String nome, String directory)
        {
            string path = "";
            string fileName = "";
            if (file != null && file.ContentLength > 0)
            {
                var lastIndex = Path.GetFileName(file.FileName).LastIndexOf(".");
                var extensao = Path.GetFileName(file.FileName).Substring(lastIndex);
                fileName = nome + extensao;
                path = Path.Combine(Server.MapPath(directory), fileName);
                if (!System.IO.File.Exists(path))
                {
                    file.SaveAs(path);
                }
                else {
                    System.IO.File.Delete(path);
                    file.SaveAs(path);
                }
            }
            return fileName;
        }
        #endregion


        protected virtual void DownloadPDF(string viewName, object model, string nomeArquivo)
        {
            string html = RenderRazorViewToString(viewName, model);
            var path = HttpRuntime.AppDomainAppPath;
            string imagem = ImageHelper.ConvertImageFullFilePathToBase64String(path + "/Content/images/logo.png");
            html = html.Replace("/Content/images/logo.png", path + "/Content/images/logo.png");
            html = html.Replace("<br>", "<br />");
            
           Export(html, nomeArquivo);
        }

        protected string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines
                    .Engines
                    .FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        protected void Export(string html, string nomeArquivo)
        {
            string fileName = string.Format("{0}.pdf", nomeArquivo);
            var linksCss = new List<string>() {
                    //"~/Content/jquery-ui.css",
                    "~/Content/bootstrap.css",
                    //"~/Content/bootstrap-datepicker.css",
                    //"~/Content/font-awesome.css",
                    //"~/Content/Site.css",
                    //"~/Content/summernote.css",
                    //"~/Content/bootstrap-theme.css"
                    //"~/Content/bootstrap-dropdown-multilevel.css",
                    //"~/Content/menu.css"
            };


            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
            System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);

            //Gerando o arquivo PDF
            using (var document = new Document(PageSize.A4, 40, 40, 40, 40))
            {
                html = FormatImageLinks(html);
                var memStream = new MemoryStream();
                TextReader xmlString = new StringReader(html);
                PdfWriter writer = PdfWriter.GetInstance(document, memStream);
                document.Open();
                FontFactory.RegisterDirectories();
                var htmlContext = new HtmlPipelineContext(null);
                htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());

                // Colocando os css's
                ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
                var s2 = "";
                foreach (var css in linksCss)
                {
                    var parcialPath = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(css));
                    cssResolver.AddCss(parcialPath, "UTF-8", true);
                    //cssResolver.AddCssFile(System.Web.HttpContext.Current.Server.MapPath(css), true);
                }
                //var boot = "C:/Projetos/FGV-EBAPE/LEGITIM.DISTRIBUIDORA.Web/Content/Content/bootstrap.css";
              

               // cssResolver.AddCss(boot, "UTF-8", true);

                //var boot  = System.Web.HttpContext.Current.Server.MapPath("~/Content/bootstrap.css");
                //cssResolver.AddCssFile(System.Web.HttpContext.Current.Server.MapPath(boot), true);
                // Exportando
                IPipeline pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));
                var worker = new XMLWorker(pipeline, true);
                var xmlParse = new XMLParser(true, worker);
                xmlParse.Parse(xmlString);
                xmlParse.Flush();

                bool exists = System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~/Content/projetos"));
                if (!exists)
                    System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/Content/projetos"));


               
                
                document.Close();
                document.Dispose();
               

                System.Web.HttpContext.Current.Response.BinaryWrite(memStream.ToArray());
                var test2 = writer;
            }

            System.Web.HttpContext.Current.Response.End();
            System.Web.HttpContext.Current.Response.Flush();
            
            

        }

        protected string FormatImageLinks(string input)
        {
            if (input == null)
                return string.Empty;
            string tempInput = input;
            const string pattern = @"";
            HttpContext context = System.Web.HttpContext.Current;

            //Modificamos a URL relativa para abosuluta,caso exista alguma imagem em nossa pagina HTML.
            foreach (Match m in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.RightToLeft))
            {
                if (!m.Success) continue;
                string tempM = m.Value;
                const string pattern1 = "src=[\'|\"](.+?)[\'|\"]";
                var reImg = new Regex(pattern1, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                Match mImg = reImg.Match(m.Value);

                if (!mImg.Success) continue;
                string src = mImg.Value.ToLower().Replace("src=", "").Replace("\"", "").Replace("\'", "");

                if (src.StartsWith("http://") || src.StartsWith("https://")) continue;
                src = "src=\"" + context.Request.Url.Scheme + "://" +
                      context.Request.Url.Authority + src + "\"";
                try
                {
                    tempM = tempM.Remove(mImg.Index, mImg.Length);
                    tempM = tempM.Insert(mImg.Index, src);
                    tempInput = tempInput.Remove(m.Index, m.Length);
                    tempInput = tempInput.Insert(m.Index, tempM);
                }
                catch (Exception e)
                {
                    throw (e); // Possibilidade de tratar
                }
            }
            return tempInput;
        }

    }
}