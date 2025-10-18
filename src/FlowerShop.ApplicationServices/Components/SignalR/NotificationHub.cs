using System.Collections.Concurrent;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace FlowerShop.ApplicationServices.Components.SignalR;

[Authorize]
public sealed class NotificationHub : Hub
{
    private static readonly ConcurrentDictionary<string, string> UserConnections = new();

    public override Task OnConnectedAsync()
    {
        var email = Context.User?.FindFirstValue(ClaimTypes.Email);
        //var email = Context.User.Claims;

        if (!string.IsNullOrEmpty(email))
        {
            UserConnections[email] = Context.ConnectionId;
        }

        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var email = Context.User?.FindFirstValue(ClaimTypes.Email);
        //var email = Context.User.Claims;

        if (!string.IsNullOrEmpty(email))
        {
            UserConnections.TryRemove(email, out _);
        }

        return base.OnDisconnectedAsync(exception);
    }

    public static string? GetConnectionIdByEmail(string email)
    {
        UserConnections.TryGetValue(email, out var connectionId);

        return connectionId;
    }
}