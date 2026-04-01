using Microsoft.Extensions.Configuration;
using System.IO;

namespace ECommApp.Util
{
    public static class DatabaseHelper
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