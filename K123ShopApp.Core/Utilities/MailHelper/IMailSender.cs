using System;
namespace K123ShopApp.Core.Utilities.MailHelper
{
	public interface IMailSender
	{
		bool SendMail(string mailAddress, string message, bool bodyHtml);
	}	
}

