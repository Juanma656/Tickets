using Microsoft.AspNetCore.Identity;
using Tickets.Data.Entities;
using Tickets.Models;

namespace Tickets.Helpers
{
    public interface ITicketHelper
    {
        Task<Ticket> GetUserAsync(string name);

        Task<Ticket> GetUserAsync(Guid userId);

        Task<IdentityResult> AddUserAsync(Ticket ticket, string document);

        Task<Ticket> AddUserAsync(AddTicketViewModel model);

        Task CheckRoleAsync(string roleName);

        Task<bool> IsUserInRoleAsync(Ticket user, string roleName);

        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAsync(Ticket ticket);
    }
}
