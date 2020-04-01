using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShootingForms
{
    public class Enemy :   Button
    {

        public double coordinateX { get; set; }
        public double coordinateY { get; set; }
        double dirX;
        double dirY;
        double speed = 4.0;

        //private int timeToLive = 500;
        public Enemy(double x, double y, Point startPoint) : base()
        {
            coordinateX = startPoint.X;
            coordinateY = startPoint.Y;
            double xVec = x - startPoint.X;
            double yVec = y - startPoint.Y;

            dirX = (speed) / Math.Sqrt((yVec * yVec) / (xVec * xVec) + 1.0);
            dirY = (speed) / Math.Sqrt((xVec * xVec) / (yVec * yVec) + 1.0);

            if (xVec < 0)
            {
                dirX *= -1;
            }
            if (yVec < 0)
            {
                dirY *= -1;
            }
        }
        public void ChangeLocation()
        {
            Point l = Location;
            l.X = (int)(coordinateX += dirX);
            l.Y = (int)(coordinateY += dirY);
            Location = l;
            this.Show();

        }
    }
}
