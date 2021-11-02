namespace GestionTicket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Responsable")]
    public partial class Responsable
    {
        public Responsable()
        {
            Ticket = new HashSet<Ticket>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(50)]
        public string Correo { get; set; }

        [Required]
        public int CargoId { get; set; }

        public bool? Activo { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
        public virtual Cargo Cargo { get; set; }
    }
}
