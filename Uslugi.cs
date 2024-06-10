using Diplomatia.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Diplomatia.Authorization;

namespace Diplomatia
{
    public partial class Uslugi : Form
    {

        private int guestId;
        DataBases DataBases = new DataBases();
        public Uslugi()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000; // 1 секунда
            timer.Tick += Timer_Tick;
            timer.Start();

            this.guestId = CurrentUser.GuestId;
        }
        private Timer timer;
        private void Timer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            UslugaShowControl usluga = new UslugaShowControl();
            usluga.Location = new Point(0, 188);
            usluga.Size = new Size(977, 483);
            this.Controls.Add(usluga);

            usluga.BringToFront();
            PrintListUslugi(usluga);
        }
        private void PrintListUslugi(UslugaShowControl uslugaShowControl)
        {
            DataBases.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [uslugi]", DataBases.getConnection());
            SqlDataReader reader = sqlCommand.ExecuteReader();
            uslugaShowControl.flowLayoutPanel1.Controls.Clear();

            while (reader.Read())
            {
                EIUslugaShowControl item = new EIUslugaShowControl();
                item.labelName.Text += reader[1].ToString();
                SetLabelText(item, reader[2].ToString());

                if (!reader.IsDBNull(reader.GetOrdinal("image_uslugi")))
                {
                    byte[] imageData = (byte[])reader["image_uslugi"];
                    item.SetImage(imageData);
                }
                int uslugaId = (int)reader["uslugi_id"]; // Получаем ID услуги
                item.guna2GradientButtonShowUsluga.Click += (sender, e) => ShowUslugaDetails(uslugaId);

                uslugaShowControl.flowLayoutPanel1.Controls.Add(item);
            }

            reader.Close();
            DataBases.closeConnection();
        }

        private void ShowUslugaDetails(int uslugaId)
        {
            DataBases.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [uslugi] WHERE uslugi_id = @id", DataBases.getConnection());
            sqlCommand.Parameters.AddWithValue("@id", uslugaId);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                UslugaFor1Control uslugaDetailControl = new UslugaFor1Control(uslugaId); // Передаем uslugaId в конструктор
                uslugaDetailControl.Location = new Point(0, 188);
                uslugaDetailControl.Size = new Size(980, 555);

                if (!reader.IsDBNull(reader.GetOrdinal("image_uslugi")))
                {
                    byte[] imageData = (byte[])reader["image_uslugi"];
                    uslugaDetailControl.guna2PictureBoxUsluga.Image = ByteArrayToImage(imageData);
                }

                uslugaDetailControl.labelName.Text = reader[1].ToString(); // Название
                uslugaDetailControl.labelSeans.Text = reader[4].ToString(); // Время сеанса
                uslugaDetailControl.labelPrice.Text = reader[5].ToString(); // Цена
                if (!reader.IsDBNull(2)) // Проверяем, есть ли описание
                {
                    uslugaDetailControl.gunaDiscrr.Text = reader[2].ToString(); // Описание
                }

                this.Controls.Add(uslugaDetailControl);
                uslugaDetailControl.BringToFront();
            }

            reader.Close();
            DataBases.closeConnection();
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void SetLabelText(EIUslugaShowControl item, string text)
        {
            if (text.Length > 20)
            {
                item.labelDiskr.Text = text.Substring(0, 17) + "...";
            }
            else
            {
                item.labelDiskr.Text = text;
            }
        }

        private void Uslugi_Load(object sender, EventArgs e)
        {
            
        }
    }
}
