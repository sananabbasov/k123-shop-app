using System;
using Microsoft.Extensions.Configuration;

namespace K123ShopApp.Core.Configurations
{
	public static class EmailConfiguration
	{
		public static string Email { get { return GetConfiguration().GetSection("EmailSettings:Email").Value;  } }
        public static string Password { get { return GetConfiguration().GetSection("EmailSettings:Password").Value; } }
		public static string Smtp { get { return GetConfiguration().GetSection("EmailSettings:Smtp").Value; } }
		public static int Port { get { return Convert.ToInt32(GetConfiguration().GetSection("EmailSettings:Port").Value); } }


		public static ConfigurationManager GetConfiguration()
		{
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../K123ShopApp.WebApi"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager;
        }
    }
}

