using Microsoft.Extensions.Configuration;
using NETCore.Encrypt.Extensions;

namespace ETicaretApp.UI.Helpers
{
    public static class EncryptHelper
    {
        private static IConfiguration Configuration { get; }

        static EncryptHelper()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }


        public static void EncryptPassword(string password, out string hashedPassword)
        {
            string md5Salt = Configuration.GetValue<string>("AppSettings:MD5Salt");
            string saltedPassword = password + md5Salt;
            hashedPassword = saltedPassword.MD5();
        }
    }
}
