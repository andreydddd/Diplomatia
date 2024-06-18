using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;

namespace Diplomatia.Telegram
{
    public partial class TgControl : UserControl
    {
        public TgControl()
        {
            InitializeComponent();
        }
        TelegramBotClient botClient;
        private void TgControl_Load(object sender, EventArgs e)
        {
            botClient = new TelegramBotClient("");
        }
       // public async Task StartReceiver();
        
    }
        

        
}

