using Microsoft.AspNetCore.Identity;
using Module4.Data;
using Module4.Models.User;

namespace Module4.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager){
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddAccountAsync(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> DeleteAccountAsync(AppUser user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<SignInResult> PassSignInAsync(LoginVM user)
        {
            return await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);
        }
    }
}
