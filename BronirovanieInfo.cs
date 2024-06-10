using Diplomatia.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Diplomatia.Authorization;

namespace Diplomatia
{
    public partial class BronirovanieInfo : Form
    {
        private Timer timer;
        DataBases dataBases = new DataBases();
        public BronirovanieInfo()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 1000; // 1 секунда
            timer.Tick += Timer_Tick;
            timer.Start();
        }
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

        private void ShowBookingInfo(InfoBron infoBron)
        {
            int guestId = CurrentUser.GuestId; // Получаем идентификатор текущего пользователя
            dataBases.OpenConnection();

            // Запрос с фильтрацией по guest_id
            string query = "SELECT * FROM bronirovanie WHERE guest_id = @guest_id";
            SqlCommand sqlCommand = new SqlCommand(query, dataBases.getConnection());
            sqlCommand.Parameters.AddWithValue("@guest_id", guestId);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                infoBron.labelNomer.Text = reader[1].ToString(); // Название номера
                infoBron.LabelFio.Text = reader[2].ToString(); // ФИО
                infoBron.labeldateStart.Text = reader.GetDateTime(3).ToString("yyyy-MM-dd"); // Дата начала
                infoBron.labeldateEnd.Text = reader.GetDateTime(4).ToString("yyyy-MM-dd"); // Дата окончания
                infoBron.labelCountChel.Text = reader[5].ToString(); // Количество человек
                infoBron.labelPrice.Text = reader[6].ToString(); // Цена

                infoBron.Show();
            }
            else
            {
                MessageBox.Show("У вас нет бронирований.");
            }

            reader.Close();
            dataBases.closeConnection();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            InfoBron infoBron = new InfoBron();
            infoBron.Size = new Size(996, 514);
            infoBron.Location = new Point(0, 178);
            this.Controls.Add(infoBron);

            infoBron.BringToFront();
            ShowBookingInfo(infoBron);
        }
    }
}

