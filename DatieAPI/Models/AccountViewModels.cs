using System.ComponentModel.DataAnnotations;

namespace DatieAPI.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool message { get; set; }
    }

    public class Register
    {
        public string UserName { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }
    }
}