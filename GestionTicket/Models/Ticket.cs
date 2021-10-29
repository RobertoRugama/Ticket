namespace GestionTicket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        public int Id { get; set; }

        public DateTime FechaGeneracion { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public string Solucion { get; set; }

        public int EstadoId { get; set; }

        public int UsuarioId { get; set; }

        public int ResponsableId { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual Responsable Responsable { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
