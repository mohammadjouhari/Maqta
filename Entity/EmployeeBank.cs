namespace Entity
{
    public class EmployeeBank : BaseEntity
    {
        public String EmployeeId { get; set; }

        public int BankId { get; set; }

        public bool IsActive { get; set; }

        public string Name { get; set; }

        public string Iban { get; set; }



    }

}
