using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class Tag: IEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public Tag()
        {
            Photos = new List<Photo>();
        }
    }
}
