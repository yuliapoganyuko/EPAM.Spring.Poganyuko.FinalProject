using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ProfileModel
    {
        public int Id { get; set; }

        public virtual UserModel User { get; set; }

        public byte[] Avatar { get; set; }
    }
}