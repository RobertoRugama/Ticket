using GestionTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionTicket.Controllers
{
    public class ResponsableController: Controller
    {
        private TicketsContext context = new TicketsContext();
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Responsable responsable)
        {
            return RedirectToAction("Index");
        }
    }
}