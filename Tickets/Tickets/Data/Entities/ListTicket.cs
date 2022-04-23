using System.ComponentModel.DataAnnotations;

namespace Tickets.Data.Entities
{
    public class ListTicket
    {
        public int Id { get; set; }

        [Display(Name = "Número de boleta")]
       // [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public static implicit operator ListTicket?(Ticket? v)
        {
            throw new NotImplementedException();
        }
    }
}
