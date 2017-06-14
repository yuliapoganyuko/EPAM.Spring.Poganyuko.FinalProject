using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required, Index(IsUnique = true), MinLength(1), MaxLength(50)]
        public string Text { get; set; }
    }
}
