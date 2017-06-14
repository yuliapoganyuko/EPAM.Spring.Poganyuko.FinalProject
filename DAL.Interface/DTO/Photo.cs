using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class Photo: IEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }
        
        public DateTime Time { get; set; }
        
        public int UserId { get; set; }
        
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
