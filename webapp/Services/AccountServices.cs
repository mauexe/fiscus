using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using model.Entities;

namespace webapp.Services;

public class AccountService
{
    private readonly UserManager<FiscusUser> _userManager;
    private readonly SignInManager<FiscusUser> _signInManager;

    public AccountService(UserManager<FiscusUser> userManager, SignInManager<FiscusUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> RegisterUser(string username, string email, string password)
    {
        var user = new FiscusUser { UserName = username, Email = email };
        var result = await _userManager.CreateAsync(user, password);

        return result;
    }

    public async Task SignInUser(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user != null)
        {
            foreach (var org in user.Organisations)
            {
                await _userManager.AddClaimAsync(user, new Claim("OrganisationId", org.Id.ToString()));
            }
            await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);
        }
    }
}