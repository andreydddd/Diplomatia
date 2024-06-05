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

namespace Diplomatia.Controller
{
    public partial class UserrControl : UserControl
    {
        DataBases DataBases = new DataBases();
        public UserrControl()
        {
            InitializeComponent();
            guna2VScrollBar1.Scroll += guna2VScrollBar1_Scroll;

            guna2VScrollBar1.Maximum = flowLayoutPanel1.VerticalScroll.Maximum; 
            guna2VScrollBar1.Minimum = 0;
            guna2VScrollBar1.SmallChange = 10;
            guna2VScrollBar1.LargeChange = flowLayoutPanel1.ClientSize.Height;
            guna2VScrollBar1.Value = flowLayoutPanel1.VerticalScroll.Value;

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void UserrControl_Load(object sender, EventArgs e)
        {

        }

        private void guna2VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.VerticalScroll.Value = guna2VScrollBar1.Value;
            flowLayoutPanel1.PerformLayout();
        }
    }
    }


