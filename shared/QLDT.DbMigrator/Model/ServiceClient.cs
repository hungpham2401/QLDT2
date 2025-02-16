﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDT.DbMigrator.Model
{
    public class ServiceClient
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string[] RootUrls { get; set; }
        public string[] Scopes { get; set; }
        public string[] GrantTypes { get; set; }
        public string[] RedirectUris { get; set; }
        public string[] PostLogoutRedirectUris { get; set; }
        public string[] AllowedCorsOrigins { get; set; }
    }
}
