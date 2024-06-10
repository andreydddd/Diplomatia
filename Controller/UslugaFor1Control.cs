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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Diplomatia.Controller
{
    public partial class UslugaFor1Control : UserControl
    {
        private List<DateTime> bookedDates;
        private System.Windows.Forms.ToolTip toolTip1; // Явно указываем пространство имен
        private int uslugaId;
        DataBases databases = new DataBases();

        public UslugaFor1Control(int uslugaId)
        {
            InitializeComponent();
            this.uslugaId = uslugaId;
            this.bookedDates = GetBookedDates(uslugaId);
            this.toolTip1 = new System.Windows.Forms.ToolTip(); // Явно указываем пространство имен

            guna2GradientButtonShowUsluga.Click += guna2GradientButtonShowUsluga_Click;
            guna2GradientButtonZapis.Click += guna2GradientButtonZapis_Click_1;
            guna2DateTimePickerBronUslug.ValueChanged += guna2DateTimePickerBronUslug_ValueChanged;

            CheckBookedDates(guna2DateTimePickerBronUslug.Value.Date); // Проверка начальной выбранной даты
        }

        private void guna2GradientButtonShowUsluga_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
            }
        }

        private void guna2GradientButtonZapis_Click_1(object sender, EventArgs e)
        {
            DateTime selectedDate = guna2DateTimePickerBronUslug.Value.Date; // Используем Date для точного сравнения дат
            int guestId = CurrentUser.GuestId;

            databases.OpenConnection();

            // Проверка существования записи для конкретного пользователя, услуги и даты
            string userCheckQuery = "SELECT COUNT(*) FROM bron_uslug WHERE uslugi_id = @uslugi_id AND date_uslug = @date_uslug AND guest_id = @guest_id";
            SqlCommand userCheckCommand = new SqlCommand(userCheckQuery, databases.getConnection());

            userCheckCommand.Parameters.AddWithValue("@uslugi_id", uslugaId);
            userCheckCommand.Parameters.AddWithValue("@date_uslug", selectedDate);
            userCheckCommand.Parameters.AddWithValue("@guest_id", guestId);

            int userExistingRecords = (int)userCheckCommand.ExecuteScalar();

            if (userExistingRecords > 0)
            {
                MessageBox.Show("Вы уже записаны на эту услугу на выбранную дату.");
                databases.closeConnection();
                return;
            }

            // Проверка существования записи для конкретной услуги и даты
            string checkQuery = "SELECT COUNT(*) FROM bron_uslug WHERE uslugi_id = @uslugi_id AND date_uslug = @date_uslug";
            SqlCommand checkCommand = new SqlCommand(checkQuery, databases.getConnection());

            checkCommand.Parameters.AddWithValue("@uslugi_id", uslugaId);
            checkCommand.Parameters.AddWithValue("@date_uslug", selectedDate);

            int existingRecords = (int)checkCommand.ExecuteScalar();

            if (existingRecords > 0)
            {
                MessageBox.Show("Эта услуга уже забронирована на выбранную дату.");
                databases.closeConnection();
                return;
            }

            // Вставка новой записи
            string insertQuery = "INSERT INTO bron_uslug (uslugi_id, guest_id, date_uslug) VALUES (@uslugi_id, @guest_id, @date_uslug)";
            SqlCommand insertCommand = new SqlCommand(insertQuery, databases.getConnection());

            insertCommand.Parameters.AddWithValue("@uslugi_id", uslugaId);
            insertCommand.Parameters.AddWithValue("@guest_id", guestId);
            insertCommand.Parameters.AddWithValue("@date_uslug", selectedDate);

            try
            {
                insertCommand.ExecuteNonQuery();
                MessageBox.Show("Вы успешно записались на услугу!");

                // Обновляем список забронированных дат
                bookedDates.Add(selectedDate);
                CheckBookedDates(selectedDate); // Обновляем подсказки после успешной записи
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при записи на услугу: " + ex.Message);
            }
            finally
            {
                databases.closeConnection();
            }
        }



        private void CheckBookedDates(DateTime selectedDate)
        {
            bool isBooked = bookedDates.Contains(selectedDate);

            if (isBooked)
            {
                toolTip1.SetToolTip(guna2DateTimePickerBronUslug, "Эта дата уже забронирована.");
            }
            else
            {
                toolTip1.SetToolTip(guna2DateTimePickerBronUslug, "");
            }
        }

        private void guna2DateTimePickerBronUslug_ValueChanged(object sender, EventArgs e)
        {
            CheckBookedDates(guna2DateTimePickerBronUslug.Value.Date);
        }

        private List<DateTime> GetBookedDates(int uslugaId)
        {
            List<DateTime> bookedDates = new List<DateTime>();

            databases.OpenConnection();
            string query = "SELECT date_uslug FROM bron_uslug WHERE uslugi_id = @uslugi_id";
            SqlCommand command = new SqlCommand(query, databases.getConnection());
            command.Parameters.AddWithValue("@uslugi_id", uslugaId);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                bookedDates.Add(reader.GetDateTime(0).Date);
            }

            reader.Close();
            databases.closeConnection();

            return bookedDates;
        }
    }
}

