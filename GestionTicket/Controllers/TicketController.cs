using GestionTicket.Models;
using GestionTicket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionTicket.Controllers
{
    public class TicketController : Controller
    {
        private TicketsContext context = new TicketsContext();
        // GET: Ticket
        public ActionResult Index()
        { 
          var listado = context.Tickets;

          return View(listado);
                   
        }
        [HttpGet]
        public ActionResult Nuevo()
        {
            var viewmodel = new TicketViewModel();
            viewmodel.Estados = context.Estados.ToList();
            viewmodel.Responsables = context.Responsables.ToList();
            viewmodel.Usuarios = context.Usuarios.ToList();

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Nuevo(Ticket ticket)
        {
            context.Tickets.Add(ticket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detalle(int Id)
        {
            var viewModel = new TicketViewModel();
            viewModel.Ticket = context.Tickets.FirstOrDefault(x => x.Id == Id);
            return View(viewModel);
        }
    }
}