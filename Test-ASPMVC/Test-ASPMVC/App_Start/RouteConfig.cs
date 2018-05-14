using System.Web.Mvc;
using System.Web.Routing;

namespace TestASPMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

  

			// Possible de mettre des contraintes avec des regex (au moins 1 chiffre)
            // Ce qui empecherait home/index/123 de satifaire cette route.
			//routes.MapRoute(
   //             name: "Meteo",
   //             url: "{jour}/{mois}/{annee}",
   //             defaults: new { controller = "Meteo", action = "Afficher" },
   //             constraints: new { jour = @"\d+", mois = @"\d+", annee = @"\d+" }
			//);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //Possible d'avoir un nombre indéfini de paramatre
				//url: "{controller}/{action}/{*id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

			//L'ordre des routes est important. Il faut définir du plus précis au plus général
            routes.MapRoute(
                name: "Calculatrice",
                url: "{action}/{valeur1}/{valeur2}",
                // Toujours possible d'écrire les routes sur des syntaxes différente 
                //url: "{action}/{valeur1}-{valeur2}",
                defaults: new { controller = "Calculatrice", action = "Ajouter", valeur1 = 0, valeur2 = 0 },
                constraints: new { valeur1 = @"\d+", valeur2 = @"\d+" }

            );
        }
    }
}
