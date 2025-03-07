
using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    [Serializable]
    class Rectangle : Figure
    {

        private PointFigure pointLeftUp;
        private PointFigure pointRightUp;
        private PointFigure pointLeftDown;
        private PointFigure pointRightDown;
        private double height;
        private double width;

        public override double Area()
        {
            return height * width;
        }

        public override double Perimeter()
        {
            return (height + width) * 2;
        }

        public Rectangle()
        {
            pointLeftUp = new PointFigure(-10, 10);
            pointLeftDown = new PointFigure(-10, -10);
            pointRightDown = new PointFigure(10, -10);
            pointRightUp = new PointFigure(10, 10);
        }

        public Rectangle(double x, double y, double height, double width)
        {
            this.x = x;
            this.y = y;
            this.pointLeftDown = new PointFigure(x - width / 2, y - height / 2);
            this.pointLeftUp = new PointFigure(x - width / 2, y + height / 2);
            this.pointRightDown = new PointFigure(x + width / 2, y - height / 2);
            this.pointRightUp = new PointFigure(x + width / 2, y + height / 2);
            this.height = height;
            this.width = width;
        }

        public Rectangle(Rectangle rect)
        {
            this.pointLeftDown = rect.pointLeftDown;
            this.pointLeftUp = rect.pointLeftUp;
            this.pointRightDown = rect.pointRightDown;
            this.pointRightUp = rect.pointRightUp;
        }

        public List<PointFigure> GetPoints()
        {
            List<PointFigure> listOfPoints = new List<PointFigure>() { pointLeftUp, pointRightUp, pointLeftDown, pointRightDown };
            return listOfPoints;
        }

        public List<Double> GetSize()
        {
            return new List<Double>() { height, width };
        }

    }
}