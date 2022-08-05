using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Login
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Mininmum length is 4")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

    }
}
