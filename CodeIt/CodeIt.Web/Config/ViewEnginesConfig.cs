using System.Web.Mvc;

namespace CodeIt.Web.Config
{
    public class ViewEnginesConfig
    {
        public static void Configure()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}