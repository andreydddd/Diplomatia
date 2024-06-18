using Guna.UI2.WinForms;
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

namespace Diplomatia.Controller
{
    public partial class BronirovanieControl : UserControl
    {
        DataBases dataBases = new DataBases();

        public BronirovanieControl()
        {
            InitializeComponent();
        }

        private void BronirovanieControl_Load(object sender, EventArgs e)
        {
           guna2ComboBoxNumber.Enabled = false;
            guna2GradientButton1.Enabled = false;
          
           
        }


        private void guna2GradientButtonCreatePrice_Click(object sender, EventArgs e)
        {
            guna2GradientButton1.Enabled = true;
            guna2TextBoxPrice.Text = "0";

            string typeText = guna2ComboBoxType.SelectedItem.ToString();

            int countGuest;
            if (!int.TryParse(guna2TextBoxCountGuest.Text, out countGuest))
            {
                MessageBox.Show("Введите корректное количество гостей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maxGuests;
            switch (typeText)
            {
                case "Стандарт":
                    maxGuests = 2;
                    break;
                case "Комфорт":
                    maxGuests = 4;
                    break;
                case "Люкс":
                    maxGuests = 6;
                    break;
                default:
                    MessageBox.Show("Выберите тип номера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            if (countGuest > maxGuests)
            {
                MessageBox.Show($"Максимальное количество гостей для типа номера {typeText} - {maxGuests}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int pricePerGuest;
            switch (typeText)
            {
                case "Стандарт":
                    pricePerGuest = 3000;
                    break;
                case "Комфорт":
                    pricePerGuest = 5000;
                    break;
                case "Люкс":
                    pricePerGuest = 7500;
                    break;
                default:
                    MessageBox.Show("Выберите тип номера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            DateTime dateStart = monthCalendarBron.SelectionStart;
            DateTime dateEnd = monthCalendarBron.SelectionEnd;

            int selectedDays = (int)(dateEnd - dateStart).TotalDays + 1;

            if (selectedDays < 1)
            {
                MessageBox.Show("Выберите корректные даты проживания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int totalPrice = countGuest * pricePerGuest;

            if (selectedDays > 1)
            {
                totalPrice += 2000 * (selectedDays - 1);
            }

            guna2TextBoxPrice.Text = totalPrice.ToString();
        }





        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            var nomId = guna2ComboBoxNumber.SelectedItem.ToString();
            var guestId = guna2TextBoxGuest.Text;
            var countGuest = guna2TextBoxCountGuest.Text;
            var price = guna2TextBoxPrice.Text;

            DateTime dateStart = monthCalendarBron.SelectionStart;
            DateTime dateEnd = monthCalendarBron.SelectionEnd;

            // Проверяем, есть ли уже бронирование для этого номера на указанные даты
            string checkBookingQuery = $"SELECT COUNT(*) FROM bronirovanie WHERE nomer_id = '{nomId}' " +
                                       $"AND ((date_start >= '{dateStart:yyyy-MM-dd}' AND date_start <= '{dateEnd:yyyy-MM-dd}') " +
                                       $"OR (date_end >= '{dateStart:yyyy-MM-dd}' AND date_end <= '{dateEnd:yyyy-MM-dd}')" +
                                       $"OR (date_start <= '{dateStart:yyyy-MM-dd}' AND date_end >= '{dateEnd:yyyy-MM-dd}'))";

            SqlCommand checkBookingCommand = new SqlCommand(checkBookingQuery, dataBases.getConnection());
            dataBases.OpenConnection();

            try
            {
                int bookingCount = (int)checkBookingCommand.ExecuteScalar();

                if (bookingCount > 0)
                {
                    MessageBox.Show("Этот номер уже забронирован на указанные даты. Выберите другие даты или другой номер.", "Ошибка бронирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке бронирования: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                dataBases.closeConnection();
            }

            string addBookingQuery = $"INSERT INTO bronirovanie (nomer_id, guest_id, count_chel, summar, date_start, date_end) " +
                                     $"VALUES ('{nomId}', '{guestId}', '{countGuest}', '{price}', '{dateStart:yyyy-MM-dd}', '{dateEnd:yyyy-MM-dd}')";

            SqlCommand addBookingCommand = new SqlCommand(addBookingQuery, dataBases.getConnection());
            dataBases.OpenConnection();

            try
            {
                if (addBookingCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Пользователь успешно забронирован");
                }
                else
                {
                    MessageBox.Show("Что-то пошло не так...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при бронировании: {ex.Message}");
            }
            finally
            {
                dataBases.closeConnection();
            }
        }


        private void guna2ComboBoxType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (guna2ComboBoxType.SelectedItem != null)
            {
                string selectedType = guna2ComboBoxType.SelectedItem.ToString();
                if (selectedType == "Стандарт" || selectedType == "Комфорт" || selectedType == "Люкс")
                {
                    guna2ComboBoxNumber.Enabled = true;

                    guna2ComboBoxNumber.Items.Clear();

                    switch (selectedType)
                    {
                        case "Стандарт":
                            guna2ComboBoxNumber.Items.AddRange(new string[] { "Стандарт1", "Стандарт2" });
                            break;
                        case "Комфорт":
                            guna2ComboBoxNumber.Items.AddRange(new string[] { "Комфорт1", "Комфорт2" });
                            break;
                        case "Люкс":
                            guna2ComboBoxNumber.Items.AddRange(new string[] { "Люкс1", "Люкс2" });
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    guna2ComboBoxNumber.Enabled = false;
                }
            }
        }

        private void guna2TextBoxGuest_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
