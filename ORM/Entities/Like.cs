using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PhotoId { get; set; }

        [Required]
        public int UserId { get; set; }

       // [ForeignKey("UserId")]
        public virtual Profile Profile { get; set; }

       // [ForeignKey("PhotoId")]
        public virtual Photo Photo { get; set; }
    }
}
