using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate_Access.NHibernateEntity
{
    public class NHiberNateEmployeeMapperClass : ClassMapping<NHibernateEmployee>
    {
        public NHiberNateEmployeeMapperClass()
        {
            Property(b => b.Email, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.StringClob);
                x.NotNullable(true);
            });
            Table("Employee");
        }
    }
}
