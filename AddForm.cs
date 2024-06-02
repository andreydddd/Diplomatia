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

namespace Diplomatia
{

    public partial class AddForm : Form
    {
        DataBases dataBases = new DataBases();

        public AddForm()
        {
            InitializeComponent();
        }

        private void guna2GradientButtonAddPicture_Click(object sender, EventArgs e)
        {
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

        private void AddForm_Load(object sender, EventArgs e)
        {
            // Вызываем метод OpenConnection вашего класса для открытия соединения с базой данных
            dataBases.OpenConnection();

            // SQL запрос для выборки данных с изображением
            string sqlQuery = "SELECT image_uslugi FROM Uslugi";

            // Создаем команду SQL
            using (SqlCommand command = new SqlCommand(sqlQuery, dataBases.getConnection()))
            {
                // Выполняем команду и получаем данные
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Получение бинарных данных изображения из базы данных
                        byte[] imageData = (byte[])reader["image_uslugi"];

                        // Преобразование бинарных данных в изображение
                        Image image;
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            image = Image.FromStream(ms);
                        }

                        // Установка изображения в PictureBox1
                        pictureBox1.Image = image;
                    }
                }
            }

            // Закрываем соединение с базой данных
            dataBases.closeConnection();
        }

    }
}