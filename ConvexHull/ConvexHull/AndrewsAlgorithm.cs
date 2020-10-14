using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ConvexHull
{
    static class AndrewsAlgorithm
    {
         public static double cross(Point O, Point A, Point B)
        {
            return (A.X - O.X) * (B.Y - O.Y) - (A.Y - O.Y) * (B.X - O.X);
        }

        public static List<Point> ConvexHull(List<Point> points)
        {
            if (points == null)
                return null;

            if (points.Count() <= 1)
                return points;

            int n = points.Count(), k = 0;
            List<Point> hull = new List<Point>(new Point[2 * n]);

            points.Sort((a, b) => a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));

            //lower
            for (int i = 0; i < n; ++i)
            {
                while (k >= 2 && cross(hull[k - 2], hull[k - 1], points[i]) <= 0)
                    k--;
                hull[k++] = points[i];
            }

            //upper
            for (int i = n - 2, t = k + 1; i >= 0; i--)
            {
                while (k >= t && cross(hull[k - 2], hull[k - 1], points[i]) <= 0)
                    k--;
                hull[k++] = points[i];
            }

            return hull.Take(k - 1).ToList();
        }      
    }
}
