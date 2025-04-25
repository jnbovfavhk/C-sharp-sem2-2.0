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

        private String filePath;
        public int Length
        {
            get
            {
                return figuresList.Count;
            }
        }

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
                outputString.Append("\n");
            }

            return outputString.ToString();
        }

        public void DeleteByIndex(int idx)
        {
            figuresList.RemoveAt(idx);
        }

        public void ChangeByIndex(int idx, Figure fig)
        {
            figuresList[idx] = fig;
            Serialize();
        }

        public FigureRepository()
        {
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..\\..\\data\\data.json");
            converter = new FigureConverter();
            figuresList = Deserialize();
        }


        private void Serialize()
        {
            // подготовка строки json для сериализации с конввертацией из FigureConverter
            var jsonString = JsonConvert.SerializeObject(figuresList, Formatting.Indented, converter);
            using (StreamWriter f = new StreamWriter(filePath, false))
            {
                f.Write(jsonString);
            }
            
        }


        private List<Figure> Deserialize()
        {
            List<Figure> figures = new List<Figure>();

            // Если файла нет, создать
            if (!File.Exists(filePath))
            {
                using (StreamWriter f = new StreamWriter(filePath))
                {
                }
            }

            // считать и десериализовать
            using (StreamReader f = new StreamReader(filePath))
            {
                String data = f.ReadToEnd();
                if (data.Length > 0)
                {
                    try
                    {
                        figures = JsonConvert.DeserializeObject<List<Figure>>(data, new FigureConverter());
                        
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
