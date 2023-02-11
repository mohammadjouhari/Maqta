namespace Entity
{
    public class EmployeeDependent : BaseEntity
    {
        public string Name { get; set; }
        public int RelationshipId { get; set; }
        public int EmployeeId { get; set; }
    }
}
