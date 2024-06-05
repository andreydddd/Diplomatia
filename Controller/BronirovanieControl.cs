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
           // FillPassportComboBox();
           
        }
        private void FillPassportComboBox()
        { 
            try
            {
                // Создаем новое подключение к базе данных
                using (SqlConnection connection = dataBases.getConnection())
                {
                    // Открываем соединение с базой данных
                    dataBases.OpenConnection();

                    // Создаем запрос к базе данных для получения паспортов из таблицы guest
                    string query = "SELECT passport FROM guest";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Создаем ридер для выполнения запроса
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Очищаем список перед добавлением новых элементов
                        guna2ComboBoxPassport.Items.Clear();

                        // Перебираем результаты запроса и добавляем их в ComboBox
                        while (reader.Read())
                        {
                            double passport = reader.GetDouble(0);
                            guna2ComboBoxPassport.Items.Add(passport.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок, если они возникли при выполнении запроса
                MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Закрываем соединение с базой данных после выполнения запроса
                dataBases.closeConnection();
            }
        }


        private void guna2GradientButtonCreatePrice_Click(object sender, EventArgs e)
        {
            guna2GradientButton1.Enabled = true;
            // Обнуляем значение guna2TextBoxPrice перед началом нового расчета
            guna2TextBoxPrice.Text = "0";

            // Получаем значение из guna2ComboBoxType
            string typeText = guna2ComboBoxType.SelectedItem.ToString();

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
            var nomId = guna2ComboBoxNumber.SelectedItem.ToString();
         //  var guestId = guna2ComboBoxPassport.SelectedItem.ToString();  
            var guestId = guna2TextBoxGuest.Text;
            var countGuest = guna2TextBoxCountGuest.Text;
            var price = guna2TextBoxPrice.Text;

            // Получаем выбранные даты из monthCalendarBron
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


        private void guna2ComboBoxType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (guna2ComboBoxType.SelectedItem != null)
            {
                string selectedType = guna2ComboBoxType.SelectedItem.ToString();
                if (selectedType == "Стандарт" || selectedType == "Комфорт" || selectedType == "Люкс")
                {
                    // Если тип номера выбран из списка, разрешаем доступ к guna2ComboBoxNumber
                    guna2ComboBoxNumber.Enabled = true;

                    // Очищаем список номеров
                    guna2ComboBoxNumber.Items.Clear();

                    // Добавляем соответствующие номера в список в зависимости от выбранного типа
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
                    // Если выбрано неправильное значение, блокируем доступ к guna2ComboBoxNumber
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
