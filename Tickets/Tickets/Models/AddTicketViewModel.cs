using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Tickets.Data.Entities;

namespace Tickets.Models
{
    public class AddTicketViewModel
    {
        internal bool wasUsed;

        public IEnumerable<SelectListItem> ListTicket { get; set; }


        [Display(Name = "Documento")]        
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Display(Name = "Nombre completo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Name { get; set; }

        public IEnumerable<SelectListItem> Entrance { get; set; }
        public object?[]? ListTicketId { get; internal set; }
        public object?[]? EntranceId { get; internal set; }
        public DateTime DateTime { get; internal set; }
    }
}
