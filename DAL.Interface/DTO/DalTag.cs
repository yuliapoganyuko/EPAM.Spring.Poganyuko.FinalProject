using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalTag: IEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<DalPhoto> Photos { get; set; }

        public DalTag()
        {
            Photos = new List<DalPhoto>();
        }
    }
}
