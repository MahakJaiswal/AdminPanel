using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using PillaniConnect.Models;
/*using PilaniConnect.Models;
*/


namespace PillaniConnect.Models
{
    public class UserHub : Hub
    {
        public async Task SendNotification(string userId)
        {
            await Clients.All.SendAsync("NewUserAdded", userId);
        }
    }
}
