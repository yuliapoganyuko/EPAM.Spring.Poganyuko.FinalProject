namespace BLL.Interface.Entities
{
    public class BllProfile: IBllEntity
    {
        public int Id { get; set; }

        public virtual BllUser User { get; set; }

        public byte[] Avatar { get; set; }
    }
}
