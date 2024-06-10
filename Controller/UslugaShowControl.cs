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
    public partial class UslugaShowControl : UserControl
    {
        public UslugaShowControl()
        {
            InitializeComponent();

            guna2VScrollBar1.Dock = DockStyle.Right; // Размещаем ScrollBar справа от flowLayoutPanel1
            guna2VScrollBar1.Scroll += guna2VScrollBar1_Scroll; // Подписываемся на событие Scroll
            flowLayoutPanel1.Scroll += flowLayoutPanel1_Scroll;
        }

        private void guna2VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.VerticalScroll.Value = e.NewValue;

        }
        private void flowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            // При прокрутке панели обновляем позицию прокрутки в ScrollBar
            guna2VScrollBar1.Maximum = flowLayoutPanel1.VerticalScroll.Maximum;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
