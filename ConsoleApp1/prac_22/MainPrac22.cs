using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.prac_22
{
    class MainPrac22
    {
        public static void Execute() {
            MyGraph graph = new MyGraph(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\prac_22\\input.txt"));

            Console.WriteLine("Задание 1. В входном файле указывается количество вершин графа/орграфа и матрица смежности:" +
                "\nДля заданного графа подсчитать количество вершин, смежных с данной");
            

            Console.WriteLine("Матрица смежности входного графа(номера вершин начинаются с нуля):");
            graph.Show();

            int v = GetInputInt(graph.Size());

            Console.WriteLine("Количество вершин, смежных с данной: " + graph.AdjacentElementsCount(v));
            Console.WriteLine("Задание 2. Найти все вершины графа, достижимые из данной");

            

            Console.WriteLine("Вершины, достижимые из данной: ");
            v = GetInputInt(graph.Size());
            graph.WriteReachableElements(v);

            Task3Execute();


        }

        public static int GetInputInt(int maxBorder)
        {
            Console.WriteLine("Введите вершину:");
            int u = int.Parse(Console.ReadLine());
            while ((u < 0) || (u >= maxBorder))
            {
                Console.WriteLine("Неправильный ввод. Еще раз:");
                u = int.Parse(Console.ReadLine());
            }
            return u;
        }

        public static void Task3Execute()
        {
            Console.WriteLine("Во входном файле задается: в первой сторке N – количество городов; начиная со" +
                "\nвторой строки через пробел названия N-городов и их координаты в декартовой системе; " +
                "\nс новой строки матрица смежности графа, описывающая схему дорог (вес ребра рассчитывается по координат городов).");
            
            Console.WriteLine(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\prac_22\\input223.txt")));
            
                // создаем граф и список сущностей с именами и координатами
                using (StreamReader file = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\prac_22\\input223.txt")))
                {
                int n = int.Parse(file.ReadLine());
                List<CityEntity> citiesList = new List<CityEntity>();

                for (int i = 0; i < n; i++)
                {
                    citiesList.Add(new CityEntity(file.ReadLine()));
                }
                int[,] listForGraph = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    string line = file.ReadLine();
                    string[] mas = line.Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        listForGraph[i, j] = int.Parse(mas[j]);
                    }
                }

                MyGraph graph = new MyGraph(listForGraph);

                // Заменяем в графе все 1 на расстояния между городами
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int distance = citiesList[i].Distance(citiesList[j]);

                        graph.ReplaceElementInMatrix(i, j, distance);
                        graph.ReplaceElementInMatrix(j, i, distance);
                    }
                }

                int idxA = GetValidCityIndex("A", citiesList);
                int idxB = GetValidCityIndex("B", citiesList);
                int idxC = GetValidCityIndex("C", citiesList);

                Console.WriteLine("Сначал найдем все кратчайшие пути из A");
                graph.Dijkstr(idxA);
                Console.WriteLine("\nТеперь найдем ответ на задачу\n");
                graph.PathFromAToBIncludingC(idxA, idxB, idxC);
            }

        }

        public static int GetValidCityIndex(string letter, List<CityEntity> citiesList)
        {
            Console.WriteLine("Введите " + letter);
            String a = Console.ReadLine();
            int idx = -1;
            bool isCity = false;
            while (!isCity)
            {
                for (int i = 0; i < citiesList.Count; i++)
                {
                    if (citiesList[i].GetName().Equals(a))
                    {
                        isCity = true;
                        idx = i;
                        break;
                    }
                }
                if (!isCity)
                {
                    Console.WriteLine("Такого города нет. Введите " + letter);
                    a = Console.ReadLine();
                }
            }
            return idx;
        }
    }
}
