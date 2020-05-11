using System.ComponentModel.DataAnnotations.Schema;

namespace RubSort.DataStorageSystem
{
    [Table("Users")]
    public class UserDbo : EntityDbo
    {
        [Column]
        public string Email { get; set; }
        
        [Column]
        public string Password { get; set; }
    }
}