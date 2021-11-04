using GestionTicket.Models;
using GestionTicket.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionTicket.Controllers
{
    public class ResponsableController: Controller
    {
        private TicketsContext context = new TicketsContext();
        
        public ActionResult Index()
        {
            var lista = context.Responsables;
            return View(lista);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var viewModelResp = new ViewModelResp();
            viewModelResp.Cargos = context.Cargos.ToList();
            return View(viewModelResp);
        }
        [HttpPost]
        public ActionResult Create(Responsable responsable)
        {
            context.Responsables.Add(responsable);
            context.SaveChanges();
            return RedirectToAction("Create");
        }
        [HttpGet]
        public ActionResult Actualizar(int Id)
        {
            var viewModelResp = new ViewModelResp();
            viewModelResp.Cargos = context.Cargos.ToList();
            viewModelResp.Responsable = context.Responsables.FirstOrDefault(x => x.Id == Id);
            return View(viewModelResp);
        }
        [HttpPost]
        public ActionResult Actualizar(Responsable responsable)
        {
            bool updateFalied = false;
            do
            {
                updateFalied = false;

                try
                {
                    context.Entry(responsable).State = System.Data.Entity.EntityState.Modified;
                    // context.Responsables.Add(responsable);
                    context.SaveChanges();
                    ViewBag.Mensaje = "El responsable se ha actualizado el registro con exito";
                    return RedirectToAction("Create");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    ex.Entries.Single().Reload();
                    ViewBag.Mensaje = "ha ocurrido un error"+ex.Message.ToString();
                }
            } while (updateFalied);
            return RedirectToAction("Create");
        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            var responsable = context.Responsables.FirstOrDefault(x => x.Id == Id);
            context.Responsables.Remove(responsable);
            context.SaveChanges();
            return RedirectToAction("Create");
           
        }



    }
}