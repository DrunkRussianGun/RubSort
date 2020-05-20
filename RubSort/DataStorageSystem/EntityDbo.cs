using System.ComponentModel.DataAnnotations;

namespace RubSort.DataStorageSystem
{
    public class EntityDbo
    {
        [Key]
        public long Id { get; set; }
    }
}