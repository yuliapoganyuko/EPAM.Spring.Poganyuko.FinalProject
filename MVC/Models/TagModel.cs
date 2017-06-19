using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class TagModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<PhotoModel> Photos { get; set; }

        public TagModel()
        {
            Photos = new List<PhotoModel>();
        }
    }
}