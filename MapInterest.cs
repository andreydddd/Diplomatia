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
using Diplomatia.MapControl;

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
            gMapControl1.OnMarkerClick += new MarkerClick(gMapControl1_OnMarkerClick); 
            Createmarker();
        }
        private void Createmarker()
        {
            GMapOverlay ListOfPlace = new GMapOverlay("Hotel");

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

            
            Bitmap kremlinImage = new Bitmap(Properties.Resources.Hram);
            images.Add(kremlinImage);
            newWidth = (int)(kremlinImage.Width * 0.08);
            newHeight = (int)(kremlinImage.Height * 0.08);
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

            Bitmap eatImage2 = new Bitmap(Properties.Resources.eat);
            images.Add(eatImage2);
            newWidth = (int)(eatImage2.Width * 0.1);
            newHeight = (int)(eatImage2.Height * 0.1);
            Bitmap resizedEatImage123 = new Bitmap(eatImage2, new Size(newWidth, newHeight));
            GMarkerGoogle marker123 = new GMarkerGoogle(new PointLatLng(56.418226, 40.445467), resizedEatImage123);
            marker123.ToolTip = new GMapRoundedToolTip(marker123);
            marker123.ToolTipText = "Точка питания";
            marker123.Tag = "Точка питания";
            ListOfPlace.Markers.Add(marker123);

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
            marker11.Tag = "Местоположение Отеля";
            ListOfPlace.Markers.Add(marker11);

            Bitmap soborImage = new Bitmap(Properties.Resources.soborn);
            images.Add(soborImage);
            newWidth = (int)(soborImage.Width * 0.06);
            newHeight = (int)(soborImage.Height * 0.06);
            Bitmap resizedSoborImage = new Bitmap(soborImage, new Size(newWidth, newHeight));
            GMarkerGoogle marker12 = new GMarkerGoogle(new PointLatLng(56.429056, 40.437234), resizedSoborImage);
            marker12.ToolTip = new GMapRoundedToolTip(marker12);
            marker12.ToolTipText = "Покровский собор";
            marker12.Tag = "Покровский собор";
            ListOfPlace.Markers.Add(marker12);

           
            Bitmap museiImage = new Bitmap(Properties.Resources.ms);
            images.Add(museiImage);
            newWidth = (int)(museiImage.Width * 0.1);
            newHeight = (int)(museiImage.Height * 0.1);
            Bitmap resizedMuseiImage = new Bitmap(museiImage, new Size(newWidth, newHeight));
            GMarkerGoogle marker13 = new GMarkerGoogle(new PointLatLng(56.425084, 40.439253), resizedMuseiImage);
            marker13.ToolTip = new GMapRoundedToolTip(marker13);
            marker13.ToolTipText = "Ларец";
            marker13.Tag = "Ларец";
            ListOfPlace.Markers.Add(marker13);

            gMapControl1.Overlays.Add(ListOfPlace);
        }


        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            HotelControl hotelControl = new HotelControl();
            MonastyrControl monastyrControl = new MonastyrControl();
           ChurchControl churchControl = new ChurchControl();
            ParkControl parkControl = new ParkControl();
            SoborControl soborControl = new SoborControl();
            MusemControl musemControl = new MusemControl();

            if (item.Tag != null)
            {
                string tag = item.Tag.ToString();
                if (tag == "Ризоположенский женский монастырь")
                {
                    monastyrControl.Location = new Point(317, 111);
                    monastyrControl.Size = new Size(446, 453);
                    this.Controls.Add(monastyrControl);
                    monastyrControl.BringToFront();
                }
                else if (tag == "Парк 950-летия города Суздаля")
                {
                    parkControl.Location = new Point(317, 111);
                    parkControl.Size = new Size(446, 453);
                    this.Controls.Add(parkControl);
                    parkControl.BringToFront();
                }
                else if (tag == "Суздальский Кремль")
                {
                    churchControl.Location = new Point(317, 111);
                    churchControl.Size = new Size(446, 453);
                    this.Controls.Add(churchControl);
                    churchControl.BringToFront();
                }
                else if (tag == "Местоположение Отеля")
                {
                    hotelControl.Location = new Point(317, 111);
                    hotelControl.Size = new Size(446, 453);
                    this.Controls.Add(hotelControl); 
                    hotelControl.BringToFront();
                }
                else if (tag == "Покровский собор")
                {
                    soborControl.Location = new Point(317, 111);
                    soborControl.Size = new Size(446, 453);
                    this.Controls.Add(soborControl);
                    soborControl.BringToFront();
                }
                else if (tag == "Ларец")
                {
                    musemControl.Location = new Point(317, 111);
                    musemControl.Size = new Size(446, 453);
                    this.Controls.Add(musemControl);
                    musemControl.BringToFront();
                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }
    }




}