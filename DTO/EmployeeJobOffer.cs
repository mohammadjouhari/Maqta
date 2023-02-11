using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeJobOffer : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Position { get; set; }
        public DateTime JoiningDate { get; set; }

    }
}
