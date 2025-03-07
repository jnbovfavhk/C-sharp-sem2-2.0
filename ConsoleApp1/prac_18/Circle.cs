
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    [Serializable]
    class Circle : PointFigure
    {
        public double radius;

        public Circle()
        {
            this.x = 0;
            this.y = 0;
            this.radius = 10;
        }

        public Circle(double x, double y, double radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }
        public Circle(Circle c)
        {
            this.x = c.GetX();
            this.y = c.GetY();
            this.radius = c.getRadius();
        }

        public double getRadius()
        {
            return radius;
        }

        public override double Area()
        {
            return Math.PI * radius * radius;
        }
        public override double Perimeter()
        {
            return 2 * Math.PI * radius;
        }
    }
}