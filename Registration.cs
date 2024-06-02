using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Diplomatia
{
    public partial class Registration : Form
    {
        DataBases dataBases = new DataBases();
        public Registration()
        {
            InitializeComponent();
            
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            var number = guna2TextBox1.Text;
            var fio = guna2TextBox2.Text;
            var passport = guna2TextBox3.Text;
            var roletxt = guna2TextBox4.Text;
            int roleINT;
            if (int.TryParse(roletxt, out roleINT))
            {
                string add = $"insert into guest ( number_phone, fio, passport, role) values ('{number}', '{fio}', '{passport}', '{roleINT}')";
                SqlCommand sqlCommand = new SqlCommand(add, dataBases.getConnection());
                dataBases.OpenConnection();
                {
                    if (sqlCommand.ExecuteNonQuery() ==1)
                    {
                        MessageBox.Show("пользователь зарегестрирован");
                        Authorization au = new Authorization();
                        au.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("что то пошло не так...");

                    }
                    dataBases.closeConnection();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Authorization au = new Authorization();
            au.Show();
            this.Hide();    
        }
    }
}
