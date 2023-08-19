using System;
namespace K123ShopApp.Entities.SharedModels
{
	public class SendEmailCommand
	{
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Token { get; set; }
	}
}

