﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(1), MaxLength(50), Index(IsUnique = true)]
        public string Text { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public Tag()
        {
            Photos = new HashSet<Photo>();
        }
    }
}
