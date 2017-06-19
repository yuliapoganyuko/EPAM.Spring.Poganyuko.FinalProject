using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Time { get; set; }
        
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Profile Profile { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        
        public Photo()
        {
            Tags = new HashSet<Tag>();
            Likes = new HashSet<Like>();
        }
    }
}
