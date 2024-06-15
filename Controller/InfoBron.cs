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
    public partial class InfoBron : UserControl
    {
        public InfoBron()
        {
            InitializeComponent();
        }

        public void AddStandartControl(StandartControl standartControl)
        {
            standartControl.Size = new Size(993, 370); // Задайте нужный размер
            standartControl.Location = new Point(0, 145); // Задайте нужное расположение
            this.Controls.Add(standartControl);
            standartControl.BringToFront();
        }

        public void AddKomfortControl(KomfortControl komfortControl)
        {
            komfortControl.Size = new Size(993, 370); // Задайте нужный размер
            komfortControl.Location = new Point(0, 145); // Задайте нужное расположение
            this.Controls.Add(komfortControl);
            komfortControl.BringToFront();
        }

        public void AddLuksControl (LuksControl luksControl)
        {
            luksControl.Size = new Size(993, 370); // Задайте нужный размер
            luksControl.Location = new Point(0, 145); // Задайте нужное расположение
            this.Controls.Add(luksControl);
            luksControl.BringToFront();
        }
    }
}
