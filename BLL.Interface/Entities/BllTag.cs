using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class BllTag: IBllEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<BllPhoto> Photos { get; set; }

        public BllTag()
        {
            Photos = new List<BllPhoto>();
        }
    }
}
