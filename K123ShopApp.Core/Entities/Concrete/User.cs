using System;
namespace K123ShopApp.Core.Entities.Concrete
{
	public class User 
	{
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool EmailConfirmed { get; set; }
        public string ConfirmationToken { get; set; }
        public int LoginAttempt { get; set; }
    }
}

