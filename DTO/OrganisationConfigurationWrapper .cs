using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrganisationConfigurationWrapper
    {
        public Guid TenantId { get; set; }
        public OrganisationConfiguration Settings { get; set; }
    }

    public class OrganisationConfiguration
    {
       
        public Guid TenantId;
        public SettingsType[] AllSettings;
    }

    public class SettingsType
    {
        public OrganisationConfiguration Settings;
        public string TypeName;
    }
}

