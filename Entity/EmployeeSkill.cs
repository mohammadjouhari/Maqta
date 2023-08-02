namespace Entity
{
    public class EmployeeSkill : BaseEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int EmployeeId { get; set; }
    }
}
