using System.ComponentModel.DataAnnotations;

namespace ORM.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
