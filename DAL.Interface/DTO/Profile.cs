using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class Profile: IEntity
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public byte[] Avatar { get; set; }
    }
}
