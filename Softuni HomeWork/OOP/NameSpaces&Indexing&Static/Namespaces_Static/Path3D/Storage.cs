using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Namespaces_Static;
using DistanceCalc;
using System.IO;

namespace Path3D
{
    class Storage
    {

        public static void SavePath(string fileName, params Path3D[] paths)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                using (sw)
                {
                    foreach (Path3D path in paths)
                    {
                        sw.Write(path);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
        }

        public static Path3D LoadPath(string fileName)
        {
            List<Point3D> points = new List<Point3D>();
            Path3D path;

            try
            {
                StreamReader sr = new StreamReader(fileName);
                using (sr)
                {
                    String line = sr.ReadLine();
                    while (line != null)
                    {
                        double[] coordinates = PointExtractor(line);
                        Point3D p = new Point3D(coordinates[0], coordinates[1], coordinates[2]);
                        points.Add(p);
                        line = sr.ReadLine();
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            path = new Path3D(points);
            return path;
        }

        private static double[] PointExtractor(string line)
        {
            double[] pointCoordinates = new double[3];
            string[] data = line.Split(',');

            for (int i = 0; i < data.Length; i++)
            {
                pointCoordinates[i] = double.Parse(data[i]);
            }

            return pointCoordinates;
        }

    }
}
