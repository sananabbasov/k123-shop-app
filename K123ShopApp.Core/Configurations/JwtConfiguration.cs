using System;
using Microsoft.Extensions.Configuration;

namespace K123ShopApp.Core.Configurations
{
	public class JwtConfiguration
	{
		public string SecretKey { get; }
		public string Issuer { get;  }
		public string Audience { get; }
		public int ExpireDate { get; }

		public JwtConfiguration()
		{
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../K123ShopApp.WebApi"));
            configurationManager.AddJsonFile("appsettings.json");
            SecretKey = configurationManager.GetSection("JwtConfiguration:SecretKey").Value;
            Issuer = configurationManager.GetSection("JwtConfiguration:Issuer").Value;
            Audience = configurationManager.GetSection("JwtConfiguration:Audience").Value;
            ExpireDate = Convert.ToInt32(configurationManager.GetSection("JwtConfiguration:ExpireDate").Value);
        }
	}
}

