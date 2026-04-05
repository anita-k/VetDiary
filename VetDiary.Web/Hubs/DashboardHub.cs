using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace VetDiary.Web.Hubs
{
    public class DashboardHub : Hub
    {
        private static readonly ConcurrentDictionary<string, string> OnlineUsers = new();
        private readonly UserManager<IdentityUser> _userManager;

        public DashboardHub(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public override async Task OnConnectedAsync()
        {
            var email = Context.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(email))
            {
                var user = await _userManager.FindByEmailAsync(email);
                var roles = user != null ? await _userManager.GetRolesAsync(user) : [];
                var role = roles.FirstOrDefault() ?? "User";

                OnlineUsers[Context.ConnectionId] = $"{email}|{role}";
                await BroadcastOnlineUsers();
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            OnlineUsers.TryRemove(Context.ConnectionId, out _);
            await BroadcastOnlineUsers();
            await base.OnDisconnectedAsync(exception);
        }

        private async Task BroadcastOnlineUsers()
        {
            var users = OnlineUsers.Values
                .Distinct()
                .Select(entry =>
                {
                    var parts = entry.Split('|');
                    return new { email = parts[0], role = parts[1] };
                })
                .ToList();

            await Clients.All.SendAsync("UpdateOnlineUsers", users);
        }
    }
}
