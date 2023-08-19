using System;
using System.Text.Json;

namespace K123ShopApp.Business.Policy
{
	public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        // userPhotoUrl => user_photo_url
        public override string ConvertName(string name)
        {
            return string.Concat(name.Select((character, index) =>
                index > 0 && char.IsUpper(character)
                    ? "_" + character.ToString()
                    : character.ToString()
            )).ToLower();
        }
    }
}

