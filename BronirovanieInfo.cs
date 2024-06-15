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
            string fio = CurrentUser.Fio; // Получаем FIO текущего пользователя
            dataBases.OpenConnection();

            // Запрос с фильтрацией по fio
            string query = "SELECT * FROM bronirovanie WHERE guest_id = @fio";
            SqlCommand sqlCommand = new SqlCommand(query, dataBases.getConnection());
            sqlCommand.Parameters.AddWithValue("@fio", fio);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                infoBron.labelNomer.Text = reader[1].ToString(); // Название номера
                infoBron.LabelFio.Text = reader[2].ToString(); // ФИО
                infoBron.labeldateStart.Text = reader.GetDateTime(3).ToString("yyyy-MM-dd"); // Дата начала
                infoBron.labeldateEnd.Text = reader.GetDateTime(4).ToString("yyyy-MM-dd"); // Дата окончания
                infoBron.labelCountChel.Text = reader[5].ToString(); // Количество человек
                infoBron.labelPrice.Text = reader[6].ToString(); // Цена

                // Условное добавление StandartControl
                if (infoBron.labelNomer.Text == "Стандарт1" || infoBron.labelNomer.Text == "Стандарт2")
                {
                    StandartControl standartControl = new StandartControl();
                    infoBron.AddStandartControl(standartControl);
                }

                infoBron.Show();
                if (infoBron.labelNomer.Text == "Комфорт1" || infoBron.labelNomer.Text == "Комфорт2")
                {
                    KomfortControl komfortControl = new KomfortControl();
                    infoBron.AddKomfortControl(komfortControl);
                }

                infoBron.Show();

                if (infoBron.labelNomer.Text == "Люкс1" || infoBron.labelNomer.Text == "Люкс2")
                {
                    LuksControl luksControl = new LuksControl();
                    infoBron.AddLuksControl(luksControl);
                }

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
            infoBron.Location = new Point(0, 150);
            this.Controls.Add(infoBron);

            infoBron.BringToFront();
            ShowBookingInfo(infoBron);
        }
    }
}

