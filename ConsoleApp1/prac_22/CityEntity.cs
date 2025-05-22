using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.prac_22
{
    class CityEntity
    {
        private String name;
        private int x;
        private int y;
        public CityEntity(String inputString)
        {
            char[] separators = { ' ', '\n' };
            string[] components = inputString.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            name = components[0];
            x = int.Parse(components[1]);
            y = int.Parse(components[2]);

        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public String GetName()
        {
            return name;
        }

        public int Distance(CityEntity city)
        {
            int d = (int)Math.Sqrt(Math.Pow(city.GetX() - GetX(), 2) + Math.Pow(city.GetY() - GetY(), 2));
            return d;
        }
    }
}
