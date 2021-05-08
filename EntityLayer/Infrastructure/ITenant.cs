using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Infrastructure
{
    interface ITenant
    {
        string TenantId { get; set; }
    }
}
