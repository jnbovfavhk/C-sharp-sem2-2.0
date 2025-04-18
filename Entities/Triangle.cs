using System;
using System.Collections.Generic;




namespace Entities
{
    [Serializable]
    public class Triangle : Figure
    {
        private PointFigure point1;

        private PointFigure point2;

        private PointFigure point3;


        public override double Area()
        {
            double p = this.Perimeter() / 2;
            return Math.Sqrt(p * (p - Math.Sqrt(Math.Pow((point1.GetX() - point2.GetX()), 2) + Math.Pow((point1.GetY() - point2.GetY()), 2))) *
                (p - Math.Sqrt(Math.Pow((point2.GetX() - point3.GetX()), 2) + Math.Pow((point2.GetY() - point3.GetY()), 2))) *
                (p - Math.Sqrt(Math.Pow((point3.GetX() - point1.GetX()), 2) + Math.Pow((point3.GetY() - point1.GetY()), 2))));
        }


        public override double Perimeter()
        {
            return Math.Sqrt(Math.Pow((point1.GetX() - point2.GetX()), 2) + Math.Pow((point1.GetY() - point2.GetY()), 2)) +
                Math.Sqrt(Math.Pow((point2.GetX() - point3.GetX()), 2) + Math.Pow((point2.GetY() - point3.GetY()), 2)) +
                Math.Sqrt(Math.Pow((point3.GetX() - point1.GetX()), 2) + Math.Pow((point3.GetY() - point1.GetY()), 2));
        }

        // по умолчанию имеем правильный треугольник с вершиной (0, 0) и стороной, длина которой - 3, лежащей на оси x
        public Triangle()
        {
            this.point1 = new PointFigure(0, 0);
            this.point2 = new PointFigure(3, 0);
            this.point3 = new PointFigure(1.5, (3 * Math.Sqrt(3) / 2));
            this.x = 1.5;
            this.y = Math.Sqrt(3) / 2;
        }

        public Triangle(PointFigure p1, PointFigure p2, PointFigure p3)
        {
            this.point1 = p1;
            this.point2 = p2;
            this.point3 = p3;
            this.x = (p1.GetX() + p2.GetX() + p3.GetX()) / 3;
            this.y = (p1.GetY() + p2.GetY() + p3.GetY()) / 3;
        }


        public Triangle(double x_p1, double y_p1, double x_p2, double y_p2, double x_p3, double y_p3)
        {
            this.point1 = new PointFigure(x_p1, y_p1);
            this.point2 = new PointFigure(x_p2, y_p2);
            this.point3 = new PointFigure(x_p3, y_p3);
            this.x = (point1.GetX() + point2.GetX() + point3.GetX()) / 3;
            this.y = (point1.GetY() + point2.GetY() + point3.GetY()) / 3;
        }

        public List<PointFigure> GetPoints()
        {
            return new List<PointFigure>() { point1, point2, point3 };
        }
    }
}