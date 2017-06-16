namespace DAL.Interface.DTO
{
    public class DalProfile: IEntity
    {
        public int Id { get; set; }

        public virtual DalUser User { get; set; }

        public byte[] Avatar { get; set; }
    }
}
