using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Tickets.Data.Entities
{
    public class Ticket : IdentityUser
    {

        [Display(Name = "Boleta")]
        public ListTicket ListTicket { get; set; }

        [Display(Name = "Disponibilidad")]        
        public bool wasUsed { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Display(Name = "Nombre completo")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Entrada")]
        public Entrance Entrance { get; set; }

        [Display(Name = "Fecha")]        
        public DateTime Date { get; set; }     

        


    }
}
