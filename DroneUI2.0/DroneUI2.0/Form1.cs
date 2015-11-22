using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using GMap.NET.CacheProviders;
using GMap.NET.Internals;
using GMap.NET.ObjectModel;
using GMap.NET.Projections;
using GMap.NET.Properties;





namespace DroneUI2._0
{
    public partial class Form1 : Form
    {
        public Xbee xbee;
        private int numMarkers = 0;

        GMap.NET.PointLatLng lastPoint;
        public Form1()
        {
            InitializeComponent();
            gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.Position = new GMap.NET.PointLatLng(42.292315, -83.715531);
            lastPoint = new GMap.NET.PointLatLng(42.292315, -83.715531);
            gmap.MouseDoubleClick += new MouseEventHandler(MainMap_MouseDoubleClick);
            DroneTerminal.AppendText("Drone Battery: 98%" + Environment.NewLine);
            xbee = new Xbee(this);
        }

        public void UpdateValues()
        {
            //Print current GPS position to the terminal
            DroneTerminal.AppendText("Current GPS: " + SharedVars.sensorData.currentGPS.x + ","  + SharedVars.sensorData.currentGPS.y + "," + SharedVars.sensorData.currentGPS.z);
            //Update flight mode value
            textBox1.Text = "Current Flight Mode: " + SharedVars.flightMode.ToString();
            //Update Live video feed pic
            liveVideoFeedBox.Image = SharedVars.videoFeedImage;
            //Jump to current GPS position on map
            gmap.Position = new GMap.NET.PointLatLng(SharedVars.sensorData.currentGPS.x, SharedVars.sensorData.currentGPS.y);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Current Flight Mode: Return to Operator";
            DroneTerminal.AppendText("Drone Returning to operator" + Environment.NewLine);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "Current Flight Mode: Computer Vision";
            DroneTerminal.AppendText("Entering Computer Vision Mode" + Environment.NewLine);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "Current Flight Mode: GPS Waypoint";
            DroneTerminal.AppendText("Entering GPS Waypoint Mode" + Environment.NewLine);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "Current Flight Mode: Manual Flight";
            DroneTerminal.AppendText("Entering Manual Flight" + Environment.NewLine);
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        void MainMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GMap.NET.PointLatLng point = gmap.FromLocalToLatLng(e.X, e.Y);
            addMarker(point.Lat, point.Lng);

            sendGpsPoint(point.Lng, point.Lat);

        }

        private void addMarker(double X, double Y)
        {
            GMap.NET.PointLatLng coors =  new GMap.NET.PointLatLng(X, Y);
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerCross marker = new GMarkerCross(coors);
            gmap.UpdateMarkerLocalPosition(marker);
            markersOverlay.Markers.Add(marker);
            gmap.Overlays.Add(markersOverlay);

            double lat = coors.Lat;
            double lng = coors.Lng;
            string coordinates = ++numMarkers + ") " + lat.ToString() + "," + lng.ToString();
            futurePointsList.TopIndex = futurePointsList.Items.Add(coordinates);

            GMapOverlay polyOverlay = new GMapOverlay("polygons");
            List<GMap.NET.PointLatLng> points = new List<GMap.NET.PointLatLng>();
            points.Add(lastPoint);
            points.Add(coors);
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            polygon.Stroke = new Pen(Color.Red, 1);
            polyOverlay.Polygons.Add(polygon);
            gmap.Overlays.Add(polyOverlay);
            lastPoint = coors;
            gmap.Zoom++;
            gmap.Zoom--;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[picList.SelectedIndex];
        }

        private void futurePointsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] coordinate = futurePointsList.SelectedItem.ToString().Split(',',')');
            gmap.Position = new GMap.NET.PointLatLng(Convert.ToDouble(coordinate[1]), Convert.ToDouble(coordinate[2]));
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog dia1= new SaveFileDialog();
            dia1.DefaultExt = "txt";
            dia1.Filter =
            "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (dia1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream S = File.Open(dia1.FileName, FileMode.CreateNew))
                {
                    using (StreamWriter st = new StreamWriter(S))
                    {
                        foreach (var aa in futurePointsList.Items)
                            st.WriteLine(aa.ToString());
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ManWayX.Text != "" && ManWayY.Text != "")
            {
                double xVal = Double.Parse(ManWayX.Text);
                double yVal = Double.Parse(ManWayY.Text);
                addMarker(xVal, yVal);
            }
        }
        
        private void sendGpsPoint(double x, double y)
        {
            Coordinate toSend;
            toSend.x = x;
            toSend.y = y;
            toSend.z = 0;
            Console.WriteLine("Sending GPS point");
            xbee.send<Coordinate>(toSend, 'g');



        }
    }
}
