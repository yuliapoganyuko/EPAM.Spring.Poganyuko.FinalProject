using System;
using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class BllPhoto: IBllEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime Time { get; set; }

        public int UserId { get; set; }

        public byte[] Image { get; set; }

        public virtual ICollection<BllTag> Tags { get; set; }
        public virtual ICollection<BllLike> Likes { get; set; }

        public BllPhoto()
        {
            Tags = new HashSet<BllTag>();
            Likes = new HashSet<BllLike>();
        }
    }
}
