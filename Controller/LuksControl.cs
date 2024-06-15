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
    public partial class LuksControl : UserControl
    {
        private List<Bitmap> images = new List<Bitmap>();
        private int currentIndex = 0;

        public LuksControl()
        {
            InitializeComponent();
            LoadImages();
            DisplayCurrentImage();

        }
        private void LoadImages()
        {
            // Загрузка изображений из файлов или из ресурсов
            images.Add(new Bitmap(Properties.Resources.l1));
            images.Add(new Bitmap(Properties.Resources.l2));
            images.Add(new Bitmap(Properties.Resources.l3));
            images.Add(new Bitmap(Properties.Resources.l4));
            images.Add(new Bitmap(Properties.Resources.l5));
            // Загрузите все необходимые изображения в список
        }

        private void DisplayCurrentImage()
        {

            guna2PictureBoxStandart.Image = images[currentIndex];
        }

        private void gunaGoButton_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % images.Count;
            DisplayCurrentImage();
        }

        private void gunaBackButton_Click(object sender, EventArgs e)
        {
            // Переход к предыдущему изображению
            currentIndex = (currentIndex - 1 + images.Count) % images.Count;
            DisplayCurrentImage();
        }
    }
}
