using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalPhoto: IEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }
        
        public DateTime Time { get; set; }
        
        public int UserId { get; set; }
        
        public byte[] Image { get; set; }

        public virtual ICollection<DalTag> Tags { get; set; }
        public virtual ICollection<DalLike> Likes { get; set; }

        public DalPhoto()
        {
            Tags = new HashSet<DalTag>();
            Likes = new HashSet<DalLike>();
        }
    }
}
