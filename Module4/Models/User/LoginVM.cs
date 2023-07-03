using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Module4.Models.User
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
