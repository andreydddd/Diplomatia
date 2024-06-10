using Diplomatia.Controller;
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

namespace Diplomatia
{
    public partial class AdminMain : Form
    {
        
        DataBases dataBases = new DataBases();
        public AdminMain()
        {
            InitializeComponent();
            
        }

        private void PrintListUserAdmin(UserrControl userControl)
        {
            dataBases.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand("select * from [guest]", dataBases.getConnection());
            SqlDataReader reader = sqlCommand.ExecuteReader();
            userControl.flowLayoutPanel1.Controls.Clear();
            int userCount = 0;
            while (reader.Read())
            {
                EIUserControl item = new EIUserControl();
                item.labelFio.Text += reader[1].ToString();
                item.labelPhone.Text += reader[2].ToString();
                item.labelPassport.Text += reader[3].ToString();

                userControl.flowLayoutPanel1.Controls.Add(item);
                userCount++;
            }
            reader.Close();
            dataBases.closeConnection();

        }

        private void PrintUser_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            /*PanelTypeNumber.Visible = true;
            PanelTypeNumber.Location = new System.Drawing.Point(3, 155);
            PanelMenu2Item.Location = new System.Drawing.Point(5, 287);
            */

            BronirovanieControl bronirovanieControl = new BronirovanieControl();
            bronirovanieControl.Location = new System.Drawing.Point(264, -3);
            bronirovanieControl.Size = new System.Drawing.Size(740, 545);
            this.Controls.Add((bronirovanieControl));
            bronirovanieControl.BringToFront();
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            PanelMenu2Item.Location = new Point(5, 153);
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            UserrControl userrControl = new UserrControl();
            userrControl.Location = new System.Drawing.Point(265, -6);
            userrControl.Size = new System.Drawing.Size(738, 538);
            this.Controls.Add(userrControl);
            userrControl.BringToFront();

            PrintListUserAdmin(userrControl);
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            UslugaControl userrControl = new UslugaControl();
            userrControl.Location = new System.Drawing.Point(265, -6);
            userrControl.Size= new System.Drawing.Size(738, 538);
            this.Controls.Add(userrControl);
            userrControl.BringToFront();

        }

        private void guna2PictureBox4_Click_1(object sender, EventArgs e)
        {
            Registration rg = new Registration();
            rg.Show();
            this.Hide();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }
    }
    
}

