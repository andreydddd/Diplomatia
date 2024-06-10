using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplomatia
{
    public partial class Main : Form
    {
        DataBases DataBases = new DataBases();
        private int currentIndex = 0;
        private Guna.UI2.WinForms.Guna2PictureBox[] pictureBoxes;
        private Timer timer;
        

        public Main()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            pictureBoxes = new Guna.UI2.WinForms.Guna2PictureBox[] { guna2PictureBox1, guna2PictureBox2, guna2PictureBox3, guna2PictureBox4 };

            foreach (var pb in pictureBoxes)
            {
                flowLayoutPanel1.Controls.Add(pb);
            }
            // Показать только первые три PictureBox
            pictureBoxes.Take(3).ToList().ForEach(p => p.Visible = true);

            timer = new Timer();
            timer.Interval = 1000; // 1 секунда
            timer.Tick += Timer_Tick;
            timer.Start();

            guna2PictureBox2.Controls.Add(guna2HtmlLabel1);
            guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            guna2HtmlLabel1.Location = new System.Drawing.Point(10, guna2PictureBox2.Height - 65); // Отступ 10 пикселей от левого края и 40 пикселей от нижнего края
            guna2HtmlLabel1.AutoSize = true; // Автоматический размер для текста
            guna2HtmlLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            guna2PictureBox1.Controls.Add(guna2HtmlLabel2);
            guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            guna2HtmlLabel2.ForeColor = System.Drawing.Color.White;
            guna2HtmlLabel2.Location = new System.Drawing.Point(1, guna2PictureBox1.Height - 65); // Отступ 10 пикселей от левого края и 40 пикселей от нижнего края
            guna2HtmlLabel2.AutoSize = true; // Автоматический размер для текста
            guna2HtmlLabel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            guna2PictureBox3.Controls.Add(guna2HtmlLabel3);
            guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            guna2HtmlLabel3.ForeColor = System.Drawing.Color.White;
            guna2HtmlLabel3.Location = new System.Drawing.Point(5, guna2PictureBox3.Height - 65); // Отступ 10 пикселей от левого края и 40 пикселей от нижнего края
            guna2HtmlLabel3.AutoSize = true; // Автоматический размер для текста
            guna2HtmlLabel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            guna2PictureBox4.Controls.Add(guna2HtmlLabel4);
            guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            guna2HtmlLabel4.ForeColor = System.Drawing.Color.White;
            guna2HtmlLabel4.Location = new System.Drawing.Point(5, guna2PictureBox4.Height - 65); // Отступ 10 пикселей от левого края и 40 пикселей от нижнего края
            guna2HtmlLabel4.AutoSize = true; // Автоматический размер для текста
            guna2HtmlLabel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void ButtonGo_Click(object sender, EventArgs e)
        {
            var firstPictureBox = pictureBoxes[0];
            for (int i = 0; i < pictureBoxes.Length - 1; i++)
            {
                pictureBoxes[i] = pictureBoxes[i + 1];
            }
            pictureBoxes[pictureBoxes.Length - 1] = firstPictureBox;

            // Обновить расположение PictureBox в FlowLayoutPanel
            flowLayoutPanel1.Controls.Clear();
            foreach (var pb in pictureBoxes)
            {
                flowLayoutPanel1.Controls.Add(pb);
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            var lastPictureBox = pictureBoxes[pictureBoxes.Length - 1];
            for (int i = pictureBoxes.Length - 1; i > 0; i--)
            {
                pictureBoxes[i] = pictureBoxes[i - 1];
            }
            pictureBoxes[0] = lastPictureBox;

            // Обновить расположение PictureBox в FlowLayoutPanel
            flowLayoutPanel1.Controls.Clear();
            foreach (var pb in pictureBoxes)
            {
                flowLayoutPanel1.Controls.Add(pb);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            MapInterest mp = new MapInterest();
            mp.Show();
            this.Hide();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            InfoHotel hotel = new InfoHotel();
            hotel.Show();
            this.Hide();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            Uslugi uslugi = new Uslugi();
            uslugi.Show();
            this.Hide();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            BronirovanieInfo bronirovanieInfo = new BronirovanieInfo();
            bronirovanieInfo.Show();
            this.Hide();
        }
    }

}