using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Logic;

namespace ConsoleUI
{
    class ConsoleInterface
    {
        private List<String> possibleFigureTypes = new List<string>() { "круг", "треугольник", "точка", "прямоугольник"};
        private FigureService figureService = new FigureService();
        
        public void Start()
        {
            FigureService serv = new FigureService();

            Console.WriteLine("То, что у вас в контейнере:");
            Console.WriteLine(serv.GetDescription());
            while (true)
            {
                Console.WriteLine("Выберите действие: \n" +
                    "1 Добавить фигуру\n" +
                    "2 Вывести все фигуры\n" +
                    "3 Удалить фигуру по индексу\n" +
                    "4 Изменить фигуру по индексу\n" +
                    "5 Выйти\n");

                String option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddFigure();
                        break;
                    case "2":
                        PrintAll();
                        break;
                    case "3":
                        DeleteByIndex();
                        break;
                    case "4":
                        ChangeByIndex();
                        break;
                    case "5":
                        return;
                }
            }
        }

        private void ChangeByIndex()
        {
            try
            {
                Console.WriteLine("Введите индекс");
                int idx = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите тип(круг, точка, прямоугольник, треугольник)");
                String figureType = Console.ReadLine();
                if (!possibleFigureTypes.Contains(figureType))
                {
                    Console.WriteLine("Такого типа нет");
                    return;
                }

                Figure fig;
                switch (figureType)
                {

                    case "точка":
                        fig = GetPoint();
                        break;

                    case "прямоугольник":
                        fig = GetRectangle();
                        break;

                    case "круг":
                        fig = GetCircle();
                        break;

                    case "треугольник":
                        fig = GetTriangle();
                        break;

                    default:
                        Console.WriteLine("Некорректный тип");
                        return;
                }

                figureService.ChangeByIndex(idx, fig);
            } catch (FormatException)
            {
                Console.WriteLine("Данные неправильного формата");
                return;
            }
        }

        private void DeleteByIndex()
        {
            try
            {
                Console.WriteLine("Введите индекс");
                int idx = int.Parse(Console.ReadLine());

                figureService.DeleteByIndex(idx);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Данные неправильного формата");
                return;
            }
        }

        private void PrintAll()
        {
            Console.WriteLine(figureService.GetDescription());
        }

        public void AddFigure()
        {
            Console.WriteLine("Введите тип(круг, точка, прямоугольник, треугольник)");
            String figureType = Console.ReadLine();
            if (!possibleFigureTypes.Contains(figureType))
            {
                Console.WriteLine("Такого типа фигуры нет");
                return;
            }

            if (figureType.Equals("круг"))
            {
                Circle circle = GetCircle();
                if (circle != null)
                {
                    figureService.Add(circle);
                }
            }

            if (figureType.Equals("точка"))
            {
                PointFigure point = GetPoint();
                if (point != null)
                {
                    figureService.Add(point);
                }
            }
            if (figureType.Equals("прямоугольник"))
            {
                Rectangle rect = GetRectangle();
                if (rect != null)
                {
                    figureService.Add(rect);
                } 
            }
            if (figureType.Equals("треугольник"))
            {
                Triangle triangle = GetTriangle();
                if (triangle != null)
                {
                    figureService.Add(triangle);
                }
            }
        }

        private Circle GetCircle()
        {
            try
            {
                Console.WriteLine("Введите X середины круга");
                double x = double.Parse(Console.ReadLine());


                Console.WriteLine("Введите Y середины круга");
                double y = double.Parse(Console.ReadLine());
            

                Console.WriteLine("Введите радиус");
                double radius = double.Parse(Console.ReadLine());

                return new Circle(x, y, radius);
                
            }
            catch (FormatException e)
            {
                Console.WriteLine("Данные неправильного формата");
                
                return null;
            }
        }

        private PointFigure GetPoint()
        {
            try
            {
                Console.WriteLine("Введите X середины точки");
                double x = double.Parse(Console.ReadLine());


                Console.WriteLine("Введите Y середины точки");
                double y = double.Parse(Console.ReadLine());

                return new PointFigure(x, y);
            }

            catch (FormatException e)
            {
                Console.WriteLine("Данные неправильного формата");
                
                return null;
            }
        }

        private Rectangle GetRectangle()
        {
            try
            {
                Console.WriteLine("Введите X середины прямоугольника");
                double x = double.Parse(Console.ReadLine());


                Console.WriteLine("Введите Y середины прямоугольника");
                double y = double.Parse(Console.ReadLine());

                Console.WriteLine("Введите высоту");
                double height = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите ширину");
                double width = double.Parse(Console.ReadLine());

                
                return new Rectangle(x, y, height, width);
            }

            catch (FormatException e)
            {
                Console.WriteLine("Данные неправильного формата");
                
                return null;
            }
        }

        private Triangle GetTriangle()
        {
            try
            {
                Console.WriteLine("Введите X первой точки");
                double x1 = double.Parse(Console.ReadLine());


                Console.WriteLine("Введите Y перваой точки");
                double y1 = double.Parse(Console.ReadLine());

                Console.WriteLine("Введите X второй точки");
                double x2 = double.Parse(Console.ReadLine());


                Console.WriteLine("Введите Y второй точки");
                double y2 = double.Parse(Console.ReadLine());

                Console.WriteLine("Введите X третьей точки");
                double x3 = double.Parse(Console.ReadLine());


                Console.WriteLine("Введите Y третьей точки");
                double y3 = double.Parse(Console.ReadLine());


                return new Triangle(x1, y1, x2, y2, x3, y3);
            }

            catch (FormatException e)
            {
                Console.WriteLine("Данные неправильного формата");
                return null;
            }
        }
    }
}
