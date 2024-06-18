using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Message = Telegram.Bot.Types.Message;

namespace Diplomatia
{
    public partial class Tg : Form
    {
        private TelegramBotClient botClient;
        private long CHAT_ID = 895976562; // Замените на реальный ID чата или пользователя

        public Tg()
        {
            InitializeComponent();
            botClient = new TelegramBotClient("YOUR_BOT_TOKEN_HERE"); // Замените YOUR_BOT_TOKEN_HERE на реальный токен бота

            // Привязываем обработчики событий для бота
          //  botClient.OnMessage += BotClient_OnMessage;
          //  botClient.OnMessageEdited += BotClient_OnMessageEdited;
          //  botClient.OnReceiveError += BotClient_OnReceiveError;
        }

        private async void Tg_Load(object sender, EventArgs e)
        {
            try
            {
              //  await botClient.StartReceivingAsync();
                MessageBox.Show("Бот успешно запущен и начал прием сообщений.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при запуске приема сообщений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private async void BotClient_OnMessage(object sender, MessageEventArgs e)
        //{
        //    await ProcessMessage(e.Message);
        //}

        //private async void BotClient_OnMessageEdited(object sender, MessageEventArgs e)
        //{
        //    await ProcessMessage(e.Message);
        //}

        //private async Task ProcessMessage(Telegram.Bot.Types.Message message)
        //{
        //    // Обработка входящего сообщения
        //    if (message.Text != null)
        //    {
        //        string responseMessage = HandleMessage(message.Text);

        //        if (!string.IsNullOrEmpty(responseMessage))
        //        {
        //            await SendMessage(message.Chat.Id, responseMessage);
        //            UpdateListBox($"Ответ от бота: {responseMessage}");
        //        }
        //    }
        //}

        private string HandleMessage(string messageText)
        {
            // Пример обработки текста сообщения от пользователя
            if (messageText.ToLower().Contains("как дела?"))
            {
                return "нормально";
            }
            else if (messageText.ToLower().Contains("да ничо"))
            {
                return "всё ок";
            }
            else
            {
                return null; // Возвращаем null, если необходимо игнорировать сообщение
            }
        }

        private async Task SendMessage(long chatId, string text)
        {
            try
            {
                // Отправляем сообщение через бота
                await botClient.SendTextMessageAsync(chatId, text);
            }
            catch (ApiRequestException ex)
            {
                // Обрабатываем исключения Telegram API
                MessageBox.Show($"Ошибка Telegram API при отправке сообщения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Обрабатываем другие исключения
                MessageBox.Show($"Ошибка при отправке сообщения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            // Отправляем сообщение "пользователь 1\nкак дела?" от лица пользователя
            Task.Run(async () =>
            {
                await SendMessage(CHAT_ID, "пользователь 1\nкак дела?");
                UpdateListBox($"Отправлено пользователем: пользователь 1\nкак дела?");
            });
        }

        private void SendButton2_Click(object sender, EventArgs e)
        {
            // Отправляем сообщение "да ничо" от лица пользователя
            Task.Run(async () =>
            {
                await SendMessage(CHAT_ID, "да ничо");
                UpdateListBox($"Отправлено пользователем: да ничо");
            });
        }

        private void UpdateListBox(string message)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new Action<string>(UpdateListBox), message);
            }
            else
            {
                listBox1.Items.Add(message);
            }
        }

        //private void Tg_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    // Останавливаем прием сообщений при закрытии формы
        //    StopReceiving();
        //}

        //private void StopReceiving()
        //{
        //    try
        //    {
        //        botClient.StopReceiving();
        //        MessageBox.Show("Прием сообщений остановлен.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка при остановке приема сообщений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void BotClient_OnReceiveError(object sender, ReceiveErrorEventArgs e)
        //{
        //    MessageBox.Show($"Ошибка при получении сообщения: {e.ApiRequestException.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
    }


}