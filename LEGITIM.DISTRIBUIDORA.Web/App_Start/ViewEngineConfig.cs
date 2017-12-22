using System.Web.Mvc;

namespace LEGITIM.DISTRIBUIDORA.Web
{
    public class ViewEngineConfig
    {
        public static void RegisterViewEngines()
        {
            //remove all view engines
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            //disable writing the standard MVC response header
            MvcHandler.DisableMvcResponseHeader = true;
        }
    }
}