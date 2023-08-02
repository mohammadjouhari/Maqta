using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeSkill : BaseEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int EmployeeId { get; set; }
    }
}
