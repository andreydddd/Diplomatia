using Diplomatia.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplomatia
{
    public partial class Zayavki : Form
    {
        DataBases DataBases = new DataBases();  
        private Timer timer;
        public Zayavki()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 1000; // 1 секунда
            timer.Tick += Timer_Tick;
            timer.Start();

            guna2ComboBoxType.SelectedItem = "Стандарт";
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void guna2ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBoxType.SelectedItem != null)
            {
                string selectedType = guna2ComboBoxType.SelectedItem.ToString();

                guna2ComboBoxNumber.Enabled = true;
                guna2ComboBoxNumber.Items.Clear();

                // Удаляем все контролы из панели
                flowLayoutPanel1.Controls.Clear();

                UserControl controlToAdd = null;

                switch (selectedType)
                {
                    case "Стандарт":
                        guna2ComboBoxNumber.Items.AddRange(new string[] { "Стандарт1", "Стандарт2" });
                        controlToAdd = new StandartControl();
                        break;
                    case "Комфорт":
                        guna2ComboBoxNumber.Items.AddRange(new string[] { "Комфорт1", "Комфорт2" });
                        controlToAdd = new KomfortControl();
                        break;
                    case "Люкс":
                        guna2ComboBoxNumber.Items.AddRange(new string[] { "Люкс1", "Люкс2" });
                        controlToAdd = new LuksControl();
                        break;
                    default:
                        guna2ComboBoxNumber.Enabled = false;
                        break;
                }

                if (controlToAdd != null)
                {
                    controlToAdd.Location = new System.Drawing.Point(0, 290);
                    controlToAdd.Size = new System.Drawing.Size(993, 381);
                    flowLayoutPanel1.Controls.Add(controlToAdd);
                }
            }
        }

        private void Zayavki_Load(object sender, EventArgs e)
        {
            guna2ComboBoxNumber.Enabled = false;
            guna2ComboBoxType.SelectedItem = "Стандарт";
        }

        private void guna2GradientButtonCreatePrice_Click(object sender, EventArgs e)
        {
         var fio = guna2TextBoxFio.Text;
         var phone = guna2TextBoxNumber.Text;
            var count = guna2TextBoxCount.Text;
            var nomer = guna2ComboBoxNumber.SelectedItem.ToString();
            DateTime dateStart = monthCalendar1.SelectionStart;
            DateTime dateEnd = monthCalendar1.SelectionEnd;

            string addBookingQuery = $"INSERT INTO zayavki (fio, number_phone, nomer, date_start, date_end, count_chel) values ('{fio}', '{phone}', '{nomer}', '{dateStart:yyyy-MM-dd}', '{dateEnd:yyyy-MM-dd}', '{count}') ";
                            

            SqlCommand addBookingCommand = new SqlCommand(addBookingQuery, DataBases.getConnection());

            DataBases.OpenConnection();
            if (addBookingCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("ваша заявка успешно отправлена!");
            }
            else
            {
                MessageBox.Show("убедитесь что все введено правильно");
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }
    }
}
