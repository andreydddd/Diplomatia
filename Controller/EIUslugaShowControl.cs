using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplomatia.Controller
{
    public partial class EIUslugaShowControl : UserControl
    {
        public EIUslugaShowControl()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }
        public void SetImage(byte[] imageData)
        {
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                guna2PictureBoxUslugi.Image = Image.FromStream(ms);
            }
        }
    }
}
