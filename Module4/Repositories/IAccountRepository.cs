using Microsoft.AspNetCore.Identity;
using Module4.Models.User;

namespace Module4.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> AddAccountAsync(AppUser user, string password);
        Task<IdentityResult> DeleteAccountAsync(AppUser user);
        Task<SignInResult> PassSignInAsync(LoginVM user);
    }
}
