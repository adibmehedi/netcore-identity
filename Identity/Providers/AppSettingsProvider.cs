using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Providers
{
    public static class AppSettingsProvider
    {
        public static string DbConnectionString { get; set; }
        public static string DbName { get; set; }

    }
}
