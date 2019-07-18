using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB.API.Entities
{
    public class CompanyProviders
    {
        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        public Guid ProviderId { get; set; }

        public Provider Provider { get; set; }
    }
}
