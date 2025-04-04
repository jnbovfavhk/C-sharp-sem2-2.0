using ConsoleApp1.prac_21;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.prac_20
{
    class MainPrac20
    {
        public static void Execute()
        {
            Console.WriteLine("Реализовать типизированный однонаправленный список с тремя точками доступ (head, " +
                "\r\ntail, temp) для хранения и обработки целых чисел." +
                " Для списка должны быть реализованы \r\nбазовые операции: инициализация списка, добавление элемента в «хвост» списка, извлечение" +
                " \r\nэлемента из «головы» списка, просмотр элементов в списке, а также дополнительные \r\nоперации в соответствии поставленной задачей:" +
                "Удвоить вхождение каждого четного элемента в списке. ");

            MyList list = InputFromFile();
            Console.WriteLine("Извлекаем из файла и записываем в output.txt");
            WriteToFile(list);
            list.Print();

            Console.WriteLine("Добавляем 33, забираем один элемент, добавляем 0, 1, 2");
            list.Add(33);
            list.Take();
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Print();
            Console.WriteLine("Удваиваем четные элементы");
            list.DoubleEvenElements();

            list.Print();
            WriteToFile(list);
            Console.ReadLine();
        }

        public static MyList InputFromFile()
        {
            MyList list = new MyList();

            Char[] separators = new Char[] { ' ', '\n', '\r', '\t' };
            Console.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\prac_20\\input.txt"));
            String textFromFile = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\prac_20\\input.txt"));

            int[] numbers = textFromFile.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            foreach (int number in numbers)
            {
                list.Add(number);
            }

            return list;
        }

        public static void WriteToFile(MyList list)
        {
            File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\prac_20\\output.txt"), list.ToString());
        }
    }
}
