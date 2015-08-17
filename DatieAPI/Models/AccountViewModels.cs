namespace DatieAPI.Models
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class Register
    {
        public string UserName { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}