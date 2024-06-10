using GMap.NET.MapProviders;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsForms;

namespace Diplomatia
{
    public partial class MapInterest : Form
    {
        private List<Bitmap> images = new List<Bitmap>();

        public MapInterest()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = CzechTuristMapProvider.Instance;
            gMapControl1.CacheLocation = Application.StartupPath + @"\maps\OSMCache";
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.MouseWheelZoomEnabled = true;
            gMapControl1.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            gMapControl1.MinZoom = 10;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 15;
            gMapControl1.Position = new PointLatLng(56.419333, 40.448757);
            gMapControl1.ShowCenter = false;
            gMapControl1.OnMarkerClick += new MarkerClick(gMapControl1_OnMarkerClick); // Добавляем событие клика по маркеру
            Createmarker();
        }

        private void Createmarker()
        {
            GMapOverlay ListOfPlace = new GMapOverlay("Hotel");

            // Метка для "Ризоположенский женский монастырь"
            Bitmap originalImage = new Bitmap(Properties.Resources.monastyr);
            images.Add(originalImage);
            int newWidth = (int)(originalImage.Width * 0.1);
            int newHeight = (int)(originalImage.Height * 0.1);
            Bitmap resizedImage = new Bitmap(originalImage, new Size(newWidth, newHeight));
            GMarkerGoogle marker1 = new GMarkerGoogle(new PointLatLng(56.424123, 40.445963), resizedImage);
            marker1.ToolTip = new GMapRoundedToolTip(marker1);
            marker1.ToolTipText = "Ризоположенский женский монастырь";
            marker1.Tag = "Ризоположенский женский монастырь";
            ListOfPlace.Markers.Add(marker1);

            // Метка для "Парк 950-летия города Суздаля"
            Bitmap parkImage = new Bitmap(Properties.Resources.park);
            images.Add(parkImage);
            newWidth = (int)(parkImage.Width * 0.1);
            newHeight = (int)(parkImage.Height * 0.1);
            Bitmap resizedParkImage = new Bitmap(parkImage, new Size(newWidth, newHeight));
            GMarkerGoogle marker2 = new GMarkerGoogle(new PointLatLng(56.430270, 40.449008), resizedParkImage);
            marker2.ToolTip = new GMapRoundedToolTip(marker2);
            marker2.ToolTipText = "Парк 950-летия города Суздаля";
            marker2.Tag = "Парк 950-летия города Суздаля";
            ListOfPlace.Markers.Add(marker2);

            // Метка для "Суздальский Кремль"
            Bitmap kremlinImage = new Bitmap(Properties.Resources.monastyr);
            images.Add(kremlinImage);
            newWidth = (int)(kremlinImage.Width * 0.1);
            newHeight = (int)(kremlinImage.Height * 0.1);
            Bitmap resizedKremlinImage = new Bitmap(kremlinImage, new Size(newWidth, newHeight));
            GMarkerGoogle marker3 = new GMarkerGoogle(new PointLatLng(56.416562, 40.443367), resizedKremlinImage);
            marker3.ToolTip = new GMapRoundedToolTip(marker3);
            marker3.ToolTipText = "Суздальский Кремль";
            marker3.Tag = "Суздальский Кремль";
            ListOfPlace.Markers.Add(marker3);

            Bitmap eatImage = new Bitmap(Properties.Resources.eat);
            images.Add(eatImage);
            newWidth = (int)(eatImage.Width * 0.1);
            newHeight = (int)(eatImage.Height * 0.1);
            Bitmap resizedEatImage = new Bitmap(eatImage, new Size(newWidth, newHeight));
            GMarkerGoogle marker4 = new GMarkerGoogle(new PointLatLng(56.419986, 40.448101), resizedEatImage);
            marker4.ToolTip = new GMapRoundedToolTip(marker4);
            marker4.ToolTipText = "Точка питания";
            marker4.Tag = "Точка питания";
            ListOfPlace.Markers.Add(marker4);

            Bitmap eatImage1 = new Bitmap(Properties.Resources.eat);
            images.Add(eatImage);
            newWidth = (int)(eatImage1.Width * 0.1);
            newHeight = (int)(eatImage1.Height * 0.1);
            Bitmap resizedEatImage1 = new Bitmap(eatImage1, new Size(newWidth, newHeight));
            GMarkerGoogle marker5 = new GMarkerGoogle(new PointLatLng(56.421770, 40.449408), resizedEatImage1);
            marker5.ToolTip = new GMapRoundedToolTip(marker5);
            marker5.ToolTipText = "Точка питания";
            marker5.Tag = "Точка питания";
            ListOfPlace.Markers.Add(marker5);

            GMarkerGoogle marker11 = new GMarkerGoogle(new PointLatLng(56.421713, 40.453760), GMarkerGoogleType.red);
            marker11.ToolTip = new GMapRoundedToolTip(marker11);
            marker11.ToolTipText = "Местоположение Отеля";
            ListOfPlace.Markers.Add(marker11);

            gMapControl1.Overlays.Add(ListOfPlace);
        }

        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (item.Tag != null)
            {
                string tag = item.Tag.ToString();
                if (tag == "Ризоположенский женский монастырь")
                {
                    panel1.Visible = true;
                    panel2.Visible = false;
                    panel3.Visible = false;
                }
                else if (tag == "Парк 950-летия города Суздаля")
                {
                    panel2.Visible = true;
                    panel1.Visible = false;
                    panel3.Visible = false;
                }
                else if (tag == "Суздальский Кремль")
                {
                    panel3.Visible = true;
                    panel1.Visible = false;
                    panel2.Visible = false;
                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }
    }




}