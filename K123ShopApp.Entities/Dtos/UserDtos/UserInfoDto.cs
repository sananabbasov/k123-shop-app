using System;
namespace K123ShopApp.Entities.Dtos.UserDtos
{
	public class UserInfoDto
	{
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}

