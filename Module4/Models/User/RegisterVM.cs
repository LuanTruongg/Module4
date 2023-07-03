using System.ComponentModel.DataAnnotations;

namespace Module4.Models.User
{
    public class RegisterVM
    {
        [Required]
        //[Display(Name = "Họ")]
        public string FirstName { get; set; } = null!;
        [Required]
        //[Display(Name = "Tên")]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        [Required]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; } = null!;
        [Required]
        [Display(Name = "Nhập lại mật khẩu")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
