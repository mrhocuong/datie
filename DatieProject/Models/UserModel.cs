namespace DatieProject.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RegDate { get; set; }
        public bool IsAdmin { get; set; }
        public bool? IsActive { get; set; }
    }
}