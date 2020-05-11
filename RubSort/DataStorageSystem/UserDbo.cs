using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RubSort.DataStorageSystem
{
    [Table("Users")]
    public class UserDbo : EntityDbo
    {
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}