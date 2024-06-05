using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplomatia.Controller
{
    public partial class UslugaControl : UserControl
    {
        DataBases dataBases = new DataBases();
        public UslugaControl()
        {
            InitializeComponent();
        }
        private void SaveImageToDatabase(string connectionString, byte[] imageBytes)
        {
            string query = "INSERT INTO Uslugi (image_uslugi) VALUES (@Image)";

            SqlConnection connection = null;
            SqlCommand command = null;

            try
            {
                connection = new SqlConnection(connectionString);
                command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Image", imageBytes);

                connection.Open();
                command.ExecuteNonQuery();

                MessageBox.Show("Image saved to database successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                }
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                try
                {
                    // Проверка размера файла
                    FileInfo fileInfo = new FileInfo(imagePath);
                    if (fileInfo.Length > 10485760) // 10 MB для примера
                    {
                        MessageBox.Show("The image file is too large. Please select a smaller file.");
                        return;
                    }

                    // Использование потоков для загрузки изображения
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        pictureBoxUslugi.Image = Image.FromStream(fs);
                    }

                    // Преобразуем изображение в массив байтов
                    byte[] imageBytes = File.ReadAllBytes(imagePath);

                    // Ваша строка подключения
                    string connectionString = "Data Source = DESKTOP-I9IF6HI;Initial Catalog=diplomat;Integrated Security=True;";

                    // Сохраняем изображение в базу данных
                    SaveImageToDatabase(connectionString, imageBytes);
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("The image file is too large or not a valid image format.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            // Открытие диалогового окна для выбора изображения
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                try
                {
                    // Проверка размера файла
                    FileInfo fileInfo = new FileInfo(imagePath);
                    if (fileInfo.Length > 10485760) // 10 MB для примера
                    {
                        MessageBox.Show("The image file is too large. Please select a smaller file.");
                        return;
                    }

                    // Использование потоков для загрузки изображения
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        pictureBoxUslugi.Image = Image.FromStream(fs);
                    }

                    // Преобразуем изображение в массив байтов
                    byte[] imageBytes = File.ReadAllBytes(imagePath);

                    // Ваша строка подключения
                    string connectionString = "Data Source=DESKTOP-I9IF6HI;Initial Catalog=diplomat;Integrated Security=True;";

                    // Сохранение текстовых данных и изображения в базу данных
                    var name = guna2TextBoxName.Text;
                    var time = guna2TextBoxTime.Text;
                    var discr = guna2TextBoxDiscryption.Text;
                    var price = guna2TextBoxPrice.Text;

                    string add = $"INSERT INTO uslugi (name, discr, seans_time, price, image_uslugi) VALUES (@name, @discr, @time, @price, @image)";
                    using (SqlCommand sqlCommand = new SqlCommand(add, new SqlConnection(connectionString)))
                    {
                        sqlCommand.Parameters.AddWithValue("@name", name);
                        sqlCommand.Parameters.AddWithValue("@discr", discr);
                        sqlCommand.Parameters.AddWithValue("@time", time);
                        sqlCommand.Parameters.AddWithValue("@price", price);
                        sqlCommand.Parameters.AddWithValue("@image", imageBytes);

                        sqlCommand.Connection.Open();
                        if (sqlCommand.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Услуга добавлена");
                        }
                        else
                        {
                            MessageBox.Show("Что-то пошло не так...");
                        }
                    }
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("The image file is too large or not a valid image format.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                // Если изображение не выбрано, сохраняем только текстовые данные
                var name = guna2TextBoxName.Text;
                var time = guna2TextBoxTime.Text;
                var discr = guna2TextBoxDiscryption.Text;
                var price = guna2TextBoxPrice.Text;

                string add = $"INSERT INTO uslugi (name, discr, seans_time, price) VALUES (@name, @discr, @time, @price)";
                using (SqlCommand sqlCommand = new SqlCommand(add, new SqlConnection("Data Source=DESKTOP-I9IF6HI;Initial Catalog=diplomat;Integrated Security=True;")))
                {
                    sqlCommand.Parameters.AddWithValue("@name", name);
                    sqlCommand.Parameters.AddWithValue("@discr", discr);
                    sqlCommand.Parameters.AddWithValue("@time", time);
                    sqlCommand.Parameters.AddWithValue("@price", price);

                    sqlCommand.Connection.Open();
                    if (sqlCommand.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Услуга добавлена");
                    }
                    else
                    {
                        MessageBox.Show("Что-то пошло не так...");
                    }
                }
            }
        }

    }
}
