

namespace Entity
{
    public class EmployeeDocument : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Document { get; set; }
        public string AttachmentType { get; set; }
        public string PassportCopy { get; set; }
        public string Notes { get; set; }
    }
}
