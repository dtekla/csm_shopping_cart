using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        [Required, MinLength(2, ErrorMessage = "Mininmum length is 2")]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Mininmum length is 4")]
        public string Password { get; set; }

        public User() { }

        public User(AppUser appUser)
        {
            UserName = appUser.UserName;
            Email = appUser.Email;
            Password = appUser.PasswordHash;
        }
    }
}
