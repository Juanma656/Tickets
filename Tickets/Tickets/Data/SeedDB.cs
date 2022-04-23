using Tickets.Data.Entities;
using Tickets.Helpers;

namespace Tickets.Data
{
    public class SeedDB
    {
        public int cont = 0;
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
        private async Task CheckListTicketsAsync()
        {
             
            while (cont < 5000)
            if (!_context.ListTickets.Any())
            {
                _context.ListTickets.Add(new ListTicket { "1" });
                
                await _context.SaveChangesAsync();
                    cont ++;
            }
        }

    }
}
