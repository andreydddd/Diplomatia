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
using Guna.UI2.WinForms;

namespace Diplomatia
{
    public partial class Authorization : Form
    {
        DataBases dataBases = new DataBases();

        public Authorization()
        {
            InitializeComponent();
            
        }
     
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            var number = guna2TextBox1.Text;
            var fio = guna2TextBox2.Text;
            var passport = guna2TextBox3.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select number_phone, fio, passport, role from guest where number_phone = '{number}' and fio ='{fio}' and passport = '{passport}' ";

            SqlCommand command = new SqlCommand(querystring, dataBases.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                int role = Convert.ToInt32(table.Rows[0]["role"]);
                switch (role)
                {
                    case 1:
                        MessageBox.Show("вы успешно вошли");
                        Main mn = new Main();
                        mn.Show();
                        this.Hide();
                        break;

                    case 2:
                        MessageBox.Show("вы вошли как администратор");
                        AdminMain mne = new AdminMain();
                        mne.Show();
                        this.Hide();
                        break;
                }
            }
            else
            {
                MessageBox.Show("убедитесь что все введено правильно");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Registration rg = new Registration();   
            rg.Show();
            this.Hide();
        }
    }
}
