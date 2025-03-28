using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.prac_21
{
    class MyBinaryTree
    {
        private class Node
        {
            public object inf;
            public Node left;
            public Node right;

            public Node(object nodeInf)
            {
                inf = nodeInf;
                left = null;
                right = null;
            }

            public static void Add(ref Node r, object nodeInf)
            {
                if (r == null)
                {
                    r = new Node(nodeInf);
                }
                else
                {
                    if (((IComparable)(r.inf)).CompareTo(nodeInf) >= 0)
                    {
                        Add(ref r.left, nodeInf);
                    }
                    else
                    {
                        Add(ref r.right, nodeInf);
                    }
                }
            }

            public static void Preorder(Node r) //прямой обход дерева
            {
                if (r != null)
                {
                    Console.Write("{0} ", r.inf);
                    Preorder(r.left);
                    Preorder(r.right);
                    
                }
            }
            public static void Inorder(Node r) //симметричный обход дерева
            {
                if (r != null)
                {
                    Inorder(r.left);
                    Console.Write("{0} ", r.inf);
                    Inorder(r.right);
                }
            }
            public static void Postorder(Node r) //обратный обход дерева
            {
                if (r != null)
                {
                    Postorder(r.left);
                    Postorder(r.right);
                    Console.Write("{0} ", r.inf);
                }
            }

            //поиск ключевого узла в дереве
            // в item записываем значение key, r - узел, с которого ищем
            public static void Search(Node r, object key, out Node item)
            {
                if (r == null)
                {
                    item = null;
                }

                else
                {

                    if (((IComparable)(r.inf)).CompareTo(key) == 0)
                    {
                        item = r;
                    }

                    else
                    {

                        if (((IComparable)(r.inf)).CompareTo(key) > 0)
                        {
                            Search(r.left, key, out item);
                        }

                        else
                        {
                            Search(r.right, key, out item);
                        }
                    }
                }
            }

            // t - ссылка на корень, key - значение того, что удаляем
            public static void Delete(ref Node t, object key)
            {
                if (t == null)
                {
                    throw new Exception("Данное значение в дереве отсутствует");
                }
                else
                {
                    if (((IComparable)(t.inf)).CompareTo(key) > 0)
                    {
                        Delete(ref t.left, key);
                    }
                    else
                    {
                        if (((IComparable)(t.inf)).CompareTo(key) < 0)
                        {
                            Delete(ref t.right, key);
                        }
                        else
                        {
                            if (t.left == null)
                            {
                                t = t.right;
                            }
                            else
                            {
                                if (t.right == null)
                                {
                                    t = t.left;
                                }
                                else
                                {
                                    Del(t, ref t.left);
                                }
                            }
                        }
                    }

                }
            }

            //  на место удаляемого узла помещает самый правый узел в левом поддереве
            private static void Del(Node t, ref Node tr)
            {
                if (tr.right != null)
                {
                    Del(t, ref tr.right);
                }
                else
                {
                    t.inf = tr.inf;
                    tr = tr.left;
                }
            }

        } // конец вложенного класса

        Node tree; //ссылка на корень дерева
        public object Inf
        {
            set { tree.inf = value; }
            get { return tree.inf; }
        }
        public MyBinaryTree() //открытый конструктор
        {
            tree = null;
        }
        private MyBinaryTree(Node r) //закрытый конструктор
        {
            tree = r;
        }
        public void Add(object nodeInf) //добавление узла в дерево
        {
            Node.Add(ref tree, nodeInf);
        }


        //поиск ключевого узла в дереве
        public MyBinaryTree Search(object key)
        {
            Node r;
            Node.Search(tree, key, out r);
            MyBinaryTree t = new MyBinaryTree(r);
            return t;
        }

        public void Delete(object key)
        {
            Node.Delete(ref tree, key);
        }

        public void Preorder()
        {
            Node.Preorder(tree);
        }
        public void Inorder()
        {
            Node.Inorder(tree);
        }
        public void Postorder()
        {
            Node.Postorder(tree);
        }

        // найти сумму нечетных значений
        public double OddSum()
        {
            double sum = 0;
            FindOddSum(ref sum, tree);
            return sum;
        }

        private void FindOddSum(ref double currentSum, Node r)
        {
            if (r != null)
            {
                FindOddSum(ref currentSum, r.left);
                if (Math.Abs(double.Parse(r.inf.ToString())) % 2 == 1)
                {
                    currentSum += double.Parse(r.inf.ToString());
                }
                FindOddSum(ref currentSum, r.right);
            }
        }

        public int FindMaxDepth(int value)
        {
            return FindMaxDepthRecursive(tree, value, 0);
        }

        private int FindMaxDepthRecursive(Node node, int value, int depth)
        {
            if (node == null)
            {
                return -1;
            }

            int currentDepth = -1;

            // Проверяем текущий узел
            if (double.Parse(node.inf.ToString()) == value)
            {
                currentDepth = depth; // Сохраняем текущую глубину, если значение совпадает
            }

            int leftDepth = FindMaxDepthRecursive(node.left, value, depth + 1);
            int rightDepth = FindMaxDepthRecursive(node.right, value, depth + 1);

            // Возвращаем максимальную глубину из найденных
            return Math.Max(currentDepth, Math.Max(leftDepth, rightDepth));

        }
    }
}
