using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;

namespace TestASPMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            return View();
        }

        //Possible de passer un ID mais on passe jamais du HTML dans le controleur comme sa 
        // On laisse la job a la view
		public string HelloWorld(string id)
        {
			return @"
                <html>

                    <head>

                        <title>Hello World</title>

                    </head>

                    <body>

                        <p>Hello <span style=""color:red"">" + id + @"</span></p>

                    </body>

                </html>";
        }

		public ActionResult ControllerToView(string id) {
			if (string.IsNullOrWhiteSpace(id))
                return View("Error");
            else
            {
				//Il existe d'autre facon de passé des info a une view comme 
                //le viewBag. Il faudra le récupérer differement dans la view
				//ViewBag.Nom = id;
                ViewData["Nom"] = id;
                return View("Info");
            }
		}

		public string Rerouting(string id)
        {
            return HtmlHelper.GenerateLink(Request.RequestContext,
			                               RouteTable.Routes,
			                               "Mon lien",
			                               null,
			                               "Afficher",
			                               "Home",
			                               new RouteValueDictionary { { "id", id } },
			                               null);
        }
    }
}
