namespace Entity
{
    public class EmployeeExperience : BaseEntity
    {
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string JobDescription { get; set; }
        public string CompanyPhone { get; set; }
        public String CertificationExperince { get; set; }
        public int EmployeeId { get; set; }
        public bool IsAllowedToCallCopmany { get; set; }

        public string TestAddingPropert { get; set; }
    }
}
