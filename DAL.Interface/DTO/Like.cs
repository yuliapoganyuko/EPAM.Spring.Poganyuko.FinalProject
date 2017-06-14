namespace DAL.Interface.DTO
{
    public class Like: IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int PhotoId { get; set; }
    }
}
