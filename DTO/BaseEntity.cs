namespace DTO
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public int CreationUserID { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ModifyUserID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? DeleteUserID { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
