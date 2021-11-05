using GestionTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionTicket.ViewModels
{
    public class ViewModelResp
    {
        public Responsable Responsable { get; set; }
        public List<Cargo> Cargos { get; set; }
        
    }

}