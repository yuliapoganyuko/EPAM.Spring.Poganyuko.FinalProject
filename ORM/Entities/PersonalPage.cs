using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    public class PersonalPage
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public byte[] Avatar { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Like> Likes { get; set; }

        public PersonalPage()
        {
            Photos = new HashSet<Photo>();
            Likes = new HashSet<Like>();
        }
    }
}
