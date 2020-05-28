using System.ComponentModel.DataAnnotations;

namespace RubSort.DataStorageSystem.Dbo
{
    public class EntityDbo
    {
        [Key]
        public long Id { get; set; }
    }
}