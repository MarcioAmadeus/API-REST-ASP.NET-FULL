using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.IO;
using System.IO.Compression;

namespace LEGITIM.DISTRIBUIDORA.Web.Utils
{
    public static class FileHelpers
    {
        /// <summary>
        /// Checks the file exists or not.
        /// </summary>
        /// <param name="url">The URL of the remote file.</param>
        /// <returns>True : If the file exits, False if file not exists</returns>
        public static bool RemoteFileExists(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }

        /// <summary>
        /// Cria um arquivo compactados a partir da lista de arquivos enviada
        /// </summary>
        /// <param name="files">Caminho completo dos arquivos a serem compactados</param>
        /// <param name="modulo">Nome do Modulo</param>
        /// <param name="zipFileName">Nome do arquivo ZIP</param>
        /// <param name="sessionId">Session Id</param>
        /// <returns>Caminho Completo do Arquivo Compactado</returns>
        public static string CompactarArquivos(List<string> files, string modulo, string zipFileName, string sessionId)
        {
            var path = ConfigurationManager.AppSettings.Get("diretorioNAS")
                + "\\" + ConfigurationManager.AppSettings.Get("diretorioTempFiles")
                + "\\" + sessionId
                + "\\" + modulo;

            var temp = path + "\\DownloadMultiplo";

            var zipPath = path + "\\ArquivoZip";

            var zipFile = zipPath + "\\" + zipFileName + ".zip";

            if (!Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }

            if (!Directory.Exists(zipPath))
            {
                Directory.CreateDirectory(zipPath);
            }

            // clear any existing archive
            if (File.Exists(zipFile))
            {
                File.Delete(zipFile);
            }
            // empty the temp folder
            Directory.EnumerateFiles(temp).ToList().ForEach(f => System.IO.File.Delete(f));

            // copy the selected files to the temp folder
            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    File.Copy(file, Path.Combine(temp, Path.GetFileName(file)));
                }
            }

            // create a new archive
            ZipFile.CreateFromDirectory(temp, zipFile);
            return zipFile;
        }

        public static string VirtualFilePath(string fileName, int folderNumber, string moduloName)
        {
            var virtualFilePath = string.Empty;
            if (!String.IsNullOrEmpty(fileName))
            {
                virtualFilePath = String.Format("{0}//{1}//{2}//{3}",
                    ConfigurationManager.AppSettings.Get("diretorioNAS"),
                    moduloName,
                    folderNumber,
                    fileName);
            }
            return virtualFilePath;
        }
    }
}
