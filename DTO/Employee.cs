﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Employee : BaseEntity 
    {
        public string FirstName { get; set; }
        public string Mobile { get; set; }
        public String Email { get; set; }
    }

}
