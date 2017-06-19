using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class PhotoModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime Time { get; set; }

        public int? UserId { get; set; }

        public byte[] Image { get; set; }

        public virtual ICollection<TagModel> Tags { get; set; }
        public virtual ICollection<LikeModel> Likes { get; set; }

        public PhotoModel()
        {
            Tags = new HashSet<TagModel>();
            Likes = new HashSet<LikeModel>();
        }
    }
}