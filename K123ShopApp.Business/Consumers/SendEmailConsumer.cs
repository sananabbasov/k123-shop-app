using System;
using K123ShopApp.Core.Utilities.MailHelper;
using K123ShopApp.Entities.SharedModels;
using MassTransit;

namespace K123ShopApp.Business.Consumers
{
    public class SendEmailConsumer : IConsumer<SendEmailCommand>
    {
        private readonly IMailSender _mailSender;

        public SendEmailConsumer(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public async Task Consume(ConsumeContext<SendEmailCommand> context)
        {
            string text = File.ReadAllText(@"../K123ShopApp.Business/EmailTemplates/ConfirmationEmail.txt");
            text = text.Replace("href='#'", $"href='https://localhost:7037/api/user/verifyemail?email={context.Message.Email}&token={context.Message.Token}'");
            //_mailSender.SendMail(context.Message.Email, text, true);
        }
    }
}

