using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Args;

namespace Diplomatia
{

    internal class TelegramMessenger
    {
        private TelegramBotClient botClient;
        public event EventHandler<string> MessageReceived;

        public TelegramMessenger(string token)
        {
            botClient = new TelegramBotClient(token);
            botClient.OnMessageReceived += BotClient_OnMessageReceived;
            botClient.StartReceiving();
        }

        private void BotClient_OnMessageReceived(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                MessageReceived?.Invoke(this, e.Message.Text);
            }
        }

        public async Task SendMessage(string chatId, string message)
        {
            await botClient.SendTextMessageAsync(chatId, message);
        }

        public void Stop()
        {
            botClient.StopReceiving();
        }
    }
}
