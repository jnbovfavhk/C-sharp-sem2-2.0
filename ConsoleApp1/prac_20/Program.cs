using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.prac_20
{
    class Program
    {
        public static void Main(String[] args)
        {
            MyList list = InputFromFile();

            list.Print();

            list.Add(33);
            list.Take();
            list.Add(0);
            list.Add(1);

            list.DeleteEvenElements();

            list.Print();
            WriteToFile(list);
        }

        public static MyList InputFromFile()
        {
            MyList list = new MyList();

            Char[] separators = new Char[] { ' ', '\n', '\r', '\t' };

            String context = File.ReadAllText("C:\\Users\\ilyab\\Source\\Repos\\C-sharp-sem2-2.0\\ConsoleApp1\\prac_20\\input.txt");

            int[] numbers = context.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            foreach (int number in numbers)
            {
                list.Add(number);
            }

            return list;
        }

        public static void WriteToFile(MyList list)
        {
            File.WriteAllText("C:\\Users\\ilyab\\Source\\Repos\\C-sharp-sem2-2.0\\ConsoleApp1\\prac_20\\output.txt", list.ToString());
        }
    }
}
