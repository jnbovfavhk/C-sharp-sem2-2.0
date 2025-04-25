using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    [Serializable]
    public class Figure : IComparable<Figure>
    {
        // Координаты середины фигуры

        public double x;
        public double y;



        public virtual double Area()
        {
            return 0;
        }
        public virtual double Perimeter()
        {
            return 0;
        }

        public override string ToString()
        {
            String output = this.GetType().ToString() + "(" + x + ", " + y + ")";
            return output.Split('.').Last();
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            if (this.ToString().Equals(obj.ToString()))
            {
                return true;
            }
            return false;
        }


        public double GetX()
        {
            return x;
        }
        public double GetY()
        {
            return y;
        }

        public int CompareTo(Figure figure)
        {
            return this.Area().CompareTo(figure.Area());
        }

    }

}