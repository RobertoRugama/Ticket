using GestionTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionTicket.Controllers
{
    public class SesionController : Controller
    {
        private TicketsContext context = new TicketsContext();
        // GET: Sesion
        public ActionResult Login()
        {
            return View();
        }
    }
}