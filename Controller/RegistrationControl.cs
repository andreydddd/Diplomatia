using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplomatia.Controller
{
    
    public partial class RegistrationControl : UserControl
    {
        
        public RegistrationControl()
        {
            InitializeComponent();
        }
        DataBases dataBases = new DataBases();

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            var number = guna2TextBox1.Text;
            var fio = guna2TextBox2.Text;
            var passport = guna2TextBox3.Text;

            int roleINT = 1;
            
                string add = $"insert into guest ( number_phone, fio, passport, role) values ('{number}', '{fio}', '{passport}', '{roleINT}')";
                SqlCommand sqlCommand = new SqlCommand(add, dataBases.getConnection());
                dataBases.OpenConnection();
                {
                    if (sqlCommand.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("пользователь зарегестрирован");

                    }
                    else
                    {
                        MessageBox.Show("что то пошло не так...");

                    }
                    dataBases.closeConnection();
                }
            
        }
    }
}

