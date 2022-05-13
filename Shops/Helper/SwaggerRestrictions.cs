﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shops.Helper
{
    public class SwaggerRestrictions
    {
        public string AllowedEndpoints { get; set; }
        public string ExcludedEndpoints { get; set; }
        public string AllowedSchemas { get; set; }
        public string ExcludedSchemas { get; set; }
    }
}
