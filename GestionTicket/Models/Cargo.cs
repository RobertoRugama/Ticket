using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GestionTicket.Models
{
    [Table("Cargo")]
    public partial class Cargo
    {
        public Cargo()
        {
            Responsables = new HashSet<Responsable>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Area { get; set; }
        public virtual ICollection<Responsable> Responsables { get; set; }

    }
}