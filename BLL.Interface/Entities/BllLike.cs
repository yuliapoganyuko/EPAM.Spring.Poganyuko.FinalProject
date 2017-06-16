namespace BLL.Interface.Entities
{
    public class BllLike: IBllEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int PhotoId { get; set; }
    }
}
