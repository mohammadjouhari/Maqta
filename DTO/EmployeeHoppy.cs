using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeHoppy : BaseEntity
    {
        public int HoppyId { get; set; }
        public string Name { get; set; }
        public int EmployeeId { get; set; }
    }
}
