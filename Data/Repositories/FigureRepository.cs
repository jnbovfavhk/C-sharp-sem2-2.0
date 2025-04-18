using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class FigureRepository
    {
        private FigureConverter converter;

        private List<Figure> figuresList;

        public void Add(Figure fig)
        {
            figuresList.Add(fig);
            Serialize();
        }

        public void Delete(Figure fig)
        {
            figuresList.Remove(fig);
            Serialize();
        }


        public String GetDescription()
        {
            StringBuilder outputString = new StringBuilder();
            foreach (Figure f in figuresList)
            {
                outputString.Append(f.ToString());
                outputString.Append("\n" + "Периметр - " + f.Perimeter());
                outputString.Append("\n" + "Площадь - " + f.Area());
            }

            return outputString.ToString();
        }

        public void ChangeByIndex(int idx, Figure fig)
        {
            figuresList[idx] = fig;
            Serialize();
        }

        public FigureRepository()
        {
            converter = new FigureConverter();
            figuresList = Deserialize();
        }


        private void Serialize()
        {
            // подготовка строки json для сериализации с конввертацией из FigureConverter
            var jsonString = JsonConvert.SerializeObject(figuresList, Formatting.Indented, converter);
            using (StreamWriter f = new StreamWriter("C:\\Users\\belonozhkoin\\source\\repos\\C-sharp-sem2-2.0\\ConsoleApp1\\prac_18\\data.json", false))
            //using (StreamWriter f = new StreamWriter("C:\\Users\\ilyab\\source\\repos\\ConsoleApp1\\prac_18\\data.json"))
            {
                f.Write(jsonString);
            }
            Console.WriteLine("Данные записаны");
        }


        private List<Figure> Deserialize()
        {
            List<Figure> figures = new List<Figure>();

            // Если файла нет, создать
            if (!File.Exists("C:\\Users\\belonozhkoin\\Source\\Repos\\C-sharp-sem2-2.0\\ConsoleApp1\\prac_18\\data.json"))
            //if (!File.Exists("C:\\Users\\ilyab\\source\\repos\\ConsoleApp1\\prac_18\\data.json"))
            {
                using (StreamWriter f = new StreamWriter("C:\\Users\\belonozhkoin\\Source\\Repos\\C-sharp-sem2-2.0\\ConsoleApp1\\prac_18\\data.json"))
                // using (StreamWriter f = new StreamWriter("C:\\Users\\ilyab\\source\\repos\\ConsoleApp1\\prac_18\\data.json"))
                {
                }
            }

            // считать и десериализовать
            using (StreamReader f = new StreamReader("C:\\Users\\belonozhkoin\\source\\repos\\C-sharp-sem2-2.0\\ConsoleApp1\\prac_18\\data.json"))
            // using (StreamReader f = new StreamReader("C:\\Users\\ilyab\\source\\repos\\ConsoleApp1\\prac_18\\data.json"))
            {
                String data = f.ReadToEnd();
                if (data.Length > 0)
                {
                    try
                    {
                        figures = JsonConvert.DeserializeObject<List<Figure>>(data, new FigureConverter());
                        Console.WriteLine("Данные взяты из файла data.json");
                    }
                    catch (NotSupportedException ex)
                    {
                        throw ex;
                    }
                }
            }
            return figures;
        }
    }
}
