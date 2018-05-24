using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebApplication1.Models
{
    public class ChatHub : Hub
    {
        public async Task Send(string Message)
        {
            
            await this.Clients.All.SendAsync("send", Message);
        }
    }
}