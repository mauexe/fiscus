using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace webapp.Services;

public class AuthService
{
    private readonly AuthenticationStateProvider _authStateProvider;

    public AuthService(AuthenticationStateProvider authStateProvider)
    {
        _authStateProvider = authStateProvider;
    }

    public async Task<IEnumerable<int>?> GetUserOrganisationIdAsync()
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity?.IsAuthenticated == true)
        {
            var claims = user.FindAll("OrganisationId");
            var ids = claims.Select(c => Int32.Parse(c.Value));
            return ids;
        }

        return null;
    }
}