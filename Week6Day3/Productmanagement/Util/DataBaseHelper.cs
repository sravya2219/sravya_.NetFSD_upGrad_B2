using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommApp.Productmanagement.Util
{
    public static class DatabaseHelpers
    {
        public static string GetConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)   // ✅ FIX
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // ✅ MUST
                .Build();

            return config.GetConnectionString("DefaultConnection");
        }
    }
}
