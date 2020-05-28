using System.ComponentModel.DataAnnotations.Schema;

namespace RubSort.DataStorageSystem.Dbo
{
    [Table("Users")]
    public class UserDbo : EntityDbo
    {
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}