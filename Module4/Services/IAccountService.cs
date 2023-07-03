using Microsoft.AspNetCore.Identity;
using Module4.Communication;
using Module4.Models.User;

namespace Module4.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterVM register);

        Task<string> LoginUserAsync(LoginVM login);
    }
}
