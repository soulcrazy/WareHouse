using Microsoft.Extensions.Configuration;

namespace WareHouse.Core.Helper
{
    public class ConfigHelper
    {
        public static readonly IConfiguration Configuration;

        static ConfigHelper()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true);
            Configuration = builder.Build();
        }

        public static string GetConnectString()
        {
            return Configuration.GetConnectionString("mysql");
        }
    }
}