using System.Data.Entity;
namespace DatieAPI.Models
{
   // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser 
    {
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdminMaster { get; set; }
    }

}