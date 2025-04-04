using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.prac_21
{
    class MainPrac21
    {
        public static void Execute()
        {
            Console.WriteLine("В файле input.txt хранится последовательность целых чисел. По входной\n" +
"последовательности построить дерево бинарного поиска и найти для негo сумму нечетных значений узлов дерева");

            MyBinaryTree tree = InputFromFile();

            tree.Preorder();
            Console.ReadLine();
            Console.WriteLine("Сумма нечетных элементов - " + tree.OddSum());
            

            Console.ReadLine();

            Console.WriteLine("Является ли дерево сбалансированным: " + tree.IsBalanced());

            Console.ReadLine();
        }

        public static MyBinaryTree InputFromFile()
        {
            MyBinaryTree tree = new MyBinaryTree();

            Char[] separators = new Char[] { ' ', '\n', '\r', '\t' };

            String textFromFile = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\prac_21\\input.txt"));

            int[] numbers = textFromFile.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            foreach (int number in numbers)
            {
                tree.Add(number);
            }

            return tree;
        }
    }
}
