using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LEGITIM.DISTRIBUIDORA.Web.Utils
{
    public static class ImageHelper
    {
        /// <summary>Converts a photo to a base64 string.</summary>
        /// <param name="html">The extended HtmlHelper.</param>
        /// <param name="fileNameandPath">File path and name.</param>
        /// <returns>Returns a base64 string.</returns>
        public static MvcHtmlString PhotoBase64ImgSrc(this HtmlHelper html, string fileNameandPath)
        {
            string base64;
            if (File.Exists(fileNameandPath))
            {
                base64 = ConvertImageFullFilePathToBase64String(fileNameandPath);
            }
            else
            {
                var noFilePath = string.Format("{0}Content\\img\\no-image.png", AppDomain.CurrentDomain.BaseDirectory);
                base64 = ConvertImageFullFilePathToBase64String(noFilePath);
            }

            return MvcHtmlString.Create(String.Format("data:image/gif;base64,{0}", base64));
        }

        public static string ConvertImageFullFilePathToBase64String(string fileNameandPath)
        {
            if (!File.Exists(fileNameandPath))
            {
                return string.Empty;
            }

            var byteArray = File.ReadAllBytes(fileNameandPath);
            var base64 = Convert.ToBase64String(byteArray);
            return base64;
        }
    }
}
