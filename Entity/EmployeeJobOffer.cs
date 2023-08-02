namespace Entity
{
    public class EmployeeJobOffer : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Position { get; set; }
        public DateTime JoiningDate { get; set; }

    }
}
