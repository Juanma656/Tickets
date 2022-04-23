using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tickets.Data;
using Tickets.Data.Entities;
using Tickets.Models;

namespace Tickets.Helpers
{
    public class TicketHelper : ITicketHelper
    {

        private readonly DataContext _context;
        private readonly UserManager<Ticket> _userManager;
        private readonly SignInManager<Ticket> _signInManager;

        public TicketHelper(DataContext context, UserManager<Ticket> userManager, SignInManager<Ticket> signInManager)
        {
            _context       = context;
            _userManager   = userManager;           
            _signInManager = signInManager;
        }


        public async Task<IdentityResult> AddUserAsync(Ticket ticket, string name)
        {
            return await _userManager.CreateAsync(ticket, name);
        }

        public async Task<Ticket> AddUserAsync(AddTicketViewModel model)
        {
            Ticket ticket = new()
            {
                ListTicket = await _context.ListTickets.FindAsync(model.ListTicketId),
                wasUsed = model.wasUsed,
                Document = model.Document,
                Name = model.Name,                
                Entrance = await _context.Entrances.FindAsync(model.EntranceId),
                Date = model.DateTime,
                
            };

            IdentityResult result = await _userManager.CreateAsync(ticket, model.Name);
            if (result != IdentityResult.Success)
            {
                return null;
            }

            Ticket newTicket = await GetUserAsync(model.Name);
            
            return newTicket;
        }

        public Task CheckRoleAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket> GetUserAsync(string name)
        {
            return await _context.Tickets
                .Include(t => t.ListTicket)                
                .FirstOrDefaultAsync(t => t.Name == name);
        }

       
             

        public Task<bool> IsUserInRoleAsync(Ticket user, string roleName)
        {
            throw new NotImplementedException();
        }

        

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(Ticket ticket)
        {
            return await _userManager.UpdateAsync(ticket);
        }
       

        Task<Ticket> ITicketHelper.GetUserAsync(string name)
        {
            throw new NotImplementedException();
        }

        Task<Ticket> ITicketHelper.GetUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
