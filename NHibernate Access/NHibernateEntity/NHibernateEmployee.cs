using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate_Access.NHibernateEntity
{
    public class NHibernateEmployee
    {
         public virtual string FirstName { get; set; }
         public virtual string Mobile { get; set; }
         public virtual string Email { get; set; }
    }
}
