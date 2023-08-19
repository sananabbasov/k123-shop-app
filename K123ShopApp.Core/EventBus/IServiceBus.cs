using System;
namespace K123ShopApp.Core.EventBus
{
	public interface IServiceBus
	{
        void SendMessage(object model, string queue);
        void ReciveMessage(string queue);
    }
}

