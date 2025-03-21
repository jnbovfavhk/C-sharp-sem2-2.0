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
            private object inf;
            private Node left;
            private Node right;

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
                if (((IComparable)(r.inf)).CompareTo(nodeInf) > 0)
                    {
                        Add(ref r.left, nodeInf);
                    }
                    else
                    {
                        Add(ref r.right, nodeInf);
                    }
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

            //поиск ключевого узла в дереве
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


        }
    }
}
