using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestASPMVC.Models;

namespace TestASPMVC.Controllers
{
    public class ClientController : Controller
    {
		//http://localhost:8080/Client/ListeClients - liste des clients avec 
        //Des instruction Razor dans la view
		public ActionResult ListeClients()
        {

            Clients clients = new Clients();

            ViewData["Clients"] = clients.ObtenirListeClients();

            return View();

        }

		// http://localhost:8080/Client/ChercheClient/Nicolas - Retour le client
		// http://localhost:8080/Client/ChercheClient/Eric    - Retourne une erreur
        public ActionResult ChercheClient(string id)

        {

            ViewData["Nom"] = id;

            Clients clients = new Clients();

            Client client = clients.ObtenirListeClients().FirstOrDefault(c => c.Nom == id);

            if (client != null)
            {
                ViewData["Age"] = client.Age;
                return View("Trouve");            
            }

            return View("NonTrouve");

        }
    }
}
