namespace Entity
{
    public class EmployeeEducation : BaseEntity
    {
        public string Major { get; set; }
        public string EducationLevel { get; set; }
        public string EducationCertificate { get; set; }
        public string InsitutationName { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int EmployeeId { get; set; }
    }

    
}
