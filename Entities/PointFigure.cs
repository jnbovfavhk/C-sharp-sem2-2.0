using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class PointFigure : Figure
    {
        public override double Area()
        {
            return 0;
        }

        public override double Perimeter()
        {
            return 0;
        }



        public PointFigure()
        {
            this.x = 0;
            this.y = 0;

        }

        public PointFigure(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public PointFigure(PointFigure point)
        {
            this.x = point.GetX();
            this.y = point.GetY();
        }
        public PointFigure(String str)
        {
            str = str.Replace("PointFigure", "");
            str = str.Trim('(', ')');
            String strX = str.Split(' ')[0];
            String strY = str.Split(' ')[1];
            this.x = double.Parse(strX.Substring(0, strX.Length - 1));
            this.y = double.Parse(strY);
        }

        // расстояние до центра фигуры
        public double distanceTo(Figure figure)
        {
            return Math.Sqrt(Math.Pow(x - figure.GetX(), 2) + Math.Pow(y - figure.GetY(), 2));
        }
    }
}