using Tickets.Data.Entities;
using Tickets.Helpers;

namespace Tickets.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;
        private readonly TicketHelper _ticketHelper;


        public SeedDB(DataContext context, TicketHelper ticketHelper)
        {
            _context = context;
            _ticketHelper = ticketHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();            
            await CheckTicketsAsync();
            
           
        }

        private async Task<Ticket> CheckTicketsAsync(
            int      Id,
            bool     wasUsed,
            string   Document,
            string   Name,
            Entrance Entrance,
            DateTime Date
            )
        {
            Ticket ticket = await _ticketHelper.GetUserAsync(Name);
            if (ticket == null)
            {
                ticket = new Ticket
                {
                    ListTicket = _context.ListTickets.FirstOrDefault(),
                    wasUsed = wasUsed,
                    Document = Document,
                    Name = Name,                    
                    Entrance = Entrance,
                    Date = Date
                    
                };
                
            }

            return ticket;
        }


    }
}
