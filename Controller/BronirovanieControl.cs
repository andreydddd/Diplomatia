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

        }
        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой или клавишей Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Если это не цифра и не Backspace, то отменяем ввод
                e.Handled = true;

                // Дополнительно вы можете добавить визуальное отличие, например, изменить цвет рамки
                guna2TextBoxNumber.BorderColor = Color.Red;
            }
            else
            {
                // Возвращаем обычный цвет рамки, если ввод корректный
                guna2TextBoxNumber.BorderColor = Color.Gray;
            }
        }


        private void guna2GradientButtonCreatePrice_Click(object sender, EventArgs e)
        {
            // Обнуляем значение guna2TextBoxPrice перед началом нового расчета
            guna2TextBoxPrice.Text = "0";

            // Получаем значение из guna2TextBoxType
            string typeText = guna2TextBoxType.Text;

            // Получаем количество гостей из guna2TextBoxCountGuest
            int countGuest;
            if (!int.TryParse(guna2TextBoxCountGuest.Text, out countGuest))
            {
                // Если введено некорректное значение, выводим сообщение об ошибке
                MessageBox.Show("Введите корректное количество гостей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверяем максимальное количество гостей для выбранного типа номера
            int maxGuests;
            switch (typeText)
            {
                case "1":
                    maxGuests = 2;
                    break;
                case "2":
                    maxGuests = 4;
                    break;
                case "3":
                    maxGuests = 6;
                    break;
                default:
                    // Если тип не определен, выводим сообщение об ошибке
                    MessageBox.Show("Выберите тип номера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Проверяем, не превышает ли введенное количество гостей максимальное
            if (countGuest > maxGuests)
            {
                // Если количество гостей превышает максимальное, выводим сообщение об ошибке
                MessageBox.Show($"Максимальное количество гостей для типа номера {typeText} - {maxGuests}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Вычисляем цену за гостя в зависимости от введенного типа
            int pricePerGuest;
            switch (typeText)
            {
                case "1":
                    pricePerGuest = 3000;
                    break;
                case "2":
                    pricePerGuest = 5000;
                    break;
                case "3":
                    pricePerGuest = 7500;
                    break;
                default:
                    // Если тип не определен, выводим сообщение об ошибке
                    MessageBox.Show("Выберите тип номера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Получаем выбранные даты начала и конца проживания
            DateTime dateStart = monthCalendarBron.SelectionStart;
            DateTime dateEnd = monthCalendarBron.SelectionEnd;

            // Вычисляем количество выбранных дней
            int selectedDays = (int)(dateEnd - dateStart).TotalDays + 1;

            // Проверяем, чтобы дата окончания была после даты начала
            if (selectedDays < 1)
            {
                MessageBox.Show("Выберите корректные даты проживания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Вычисляем стоимость за первый день
            int totalPrice = countGuest * pricePerGuest;

            // Если выбраны более одного дня, добавляем 2000 за каждый день после первого
            if (selectedDays > 1)
            {
                totalPrice += 2000 * (selectedDays - 1);
            }

            // Устанавливаем значение в guna2TextBoxPrice
            guna2TextBoxPrice.Text = totalPrice.ToString();
        }




        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            var nomId = guna2TextBoxNumber.Text;
            var guestId = guna2TextBoxGuest.Text;
            var countGuest = guna2TextBoxCountGuest.Text;
            var price = guna2TextBoxPrice.Text;

            // Получаем выбранные даты из monthCalendarBron
            DateTime dateStart = monthCalendarBron.SelectionStart;
            DateTime dateEnd = monthCalendarBron.SelectionEnd;

            // Проверяем, есть ли уже бронирование для этого номера на указанные даты
            string checkBookingQuery = $"SELECT COUNT(*) FROM bronirovanie WHERE nomer_id = '{nomId}' " +
                                       $"AND ((date_start >= '{dateStart:yyyy-MM-dd}' AND date_start <= '{dateEnd:yyyy-MM-dd}') " +
                                       $"OR (date_end >= '{dateStart:yyyy-MM-dd}' AND date_end <= '{dateEnd:yyyy-MM-dd}'))";

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

            // Если бронирование не найдено, продолжаем с созданием новой записи
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
    }
}
