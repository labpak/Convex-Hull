using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ConvexHull
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Point> m_Points = new List<Point>();

        private void button1_Click(object sender, EventArgs e)
        {
            m_Points = new List<Point>();
            this.Invalidate();
        }

        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            m_Points.Add(new Point(e.X, e.Y));
            this.Invalidate();
        }
        
        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            List<Point> hull = null;
            if (m_Points.Count >= 3)
                hull = AndrewsAlgorithm.ConvexHull(m_Points);               

            foreach (Point pt in m_Points)
                e.Graphics.DrawEllipse(Pens.Black, pt.X - 3, pt.Y - 3, 6, 6);

            if (m_Points.Count >= 3)
            {
                Point[] hull_points = new Point[hull.Count];
                hull.CopyTo(hull_points);
                e.Graphics.DrawPolygon(Pens.Blue, hull_points);
            }
        }
    }
}