using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplomatia.Controller
{
    public partial class StandartControl : UserControl
    {
        private List<Bitmap> images = new List<Bitmap>();
        private int currentIndex = 0;
        public StandartControl()
        {
            InitializeComponent();
            LoadImages();
            DisplayCurrentImage();
        }

        private void LoadImages ()
        {
            images.Add(new Bitmap(Properties.Resources.number1));
            images.Add(new Bitmap(Properties.Resources.number2));
            images.Add(new Bitmap(Properties.Resources.number3));
        }

        private void DisplayCurrentImage()
        {

            guna2PictureBoxStandart.Image = images[currentIndex];
        }

        private void gunaBackButton_Click(object sender, EventArgs e)
        {
            // Переход к предыдущему изображению
            currentIndex = (currentIndex - 1 + images.Count) % images.Count;
            DisplayCurrentImage();
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void StandartControl_Load(object sender, EventArgs e)
        {

        }

        private void gunaGoButton_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % images.Count;
            DisplayCurrentImage();
        }
    }
}
