namespace Entity
{
    public class EmployeeEmergencyContact : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
        public string Relationship { get; set; }
        public int EmployeeId { get; set; }
    }
}
