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
using System.Web.UI;
using System.Windows.Forms;

namespace Diplomatia
{
    public partial class AdminMain : Form
    {
        
        DataBases dataBases = new DataBases();
        public AdminMain()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
            
        }

        private void PrintListUserAdmin(UserrControl userControl)
        {
            dataBases.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand("select * from [bronirovanie]", dataBases.getConnection());
            SqlDataReader reader = sqlCommand.ExecuteReader();
            userControl.flowLayoutPanel1.Controls.Clear();
            int userCount = 0;
            while (reader.Read())
            {
                EIUserControl item = new EIUserControl();
                item.gunaName.Text += reader[2].ToString();
                item.gunaNomer.Text += reader[1].ToString();
                item.gunaDateStart.Text = reader.GetDateTime(3).ToString("yyyy-MM-dd");
                item.gunaDateEnd.Text = reader.GetDateTime(4).ToString("yyyy-MM-dd");
                item.gunaCount.Text = reader[5].ToString();
                item.gunaPrice.Text = reader[6].ToString();

                userControl.flowLayoutPanel1.Controls.Add(item);
                userCount++;
            }
            reader.Close();
            dataBases.closeConnection();

        }

        private void PrintListZayavki (ZayavkaControl zayavkaControl)
        {
            dataBases.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand("select * from [zayavki]", dataBases.getConnection());
            SqlDataReader reader = sqlCommand.ExecuteReader();
            zayavkaControl.flowLayoutPanel1.Controls.Clear();
            while (reader.Read())
            {
                EIZayavki item = new EIZayavki();
                item.guna2HtmlLabelFio.Text += reader[1].ToString();
                item.guna2HtmlLabelPhone.Text += reader[2].ToString();
                item.guna2HtmlLabelNomer.Text += reader[3].ToString();
                item.guna2HtmlLabelDateS.Text = reader.GetDateTime(4).ToString("yyyy-MM-dd");
                item.guna2HtmlLabelDateN.Text = reader.GetDateTime(5).ToString("yyyy-MM-dd");
                item.guna2HtmlLabelCount.Text += reader[6].ToString();
                zayavkaControl.flowLayoutPanel1.Controls.Add(item);
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
            userrControl.Size = new System.Drawing.Size(751, 537);
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

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void guna2PictureBox4_Click_2(object sender, EventArgs e)
        {
            RegistrationControl rg = new RegistrationControl();
            rg.Location = new System.Drawing.Point(265, -6);
            rg.Size = new System.Drawing.Size(738,587);
            this.Controls.Add(rg);

            rg.BringToFront();
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            ZayavkaControl zayavkaControl = new ZayavkaControl();
            zayavkaControl.Location = new System.Drawing.Point(265, -6);
            zayavkaControl.Size = new System.Drawing.Size(730, 541);
            this.Controls.Add(zayavkaControl);
            zayavkaControl.BringToFront();

            PrintListZayavki(zayavkaControl);
        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    
}

