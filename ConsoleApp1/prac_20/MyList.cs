using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.prac_20
{
    class MyList
    {
        private Node head;
        private Node temp;
        private Node tail;

        public MyList()
        {
            head = null;
            tail = null;
            temp = null;
        }

        public void Add(object obj)
        {
            Node r = new Node(obj);
            if (head == null)
            {
                head = r;
                tail = r;
            } else
            {
                tail.Next = r;
                tail = r;
            }
        }

        public object Take()
        {
            if (head == null)
            {
                throw new Exception("Список пуст");
            }
            else
            {
                Node r = head;
                head = head.Next;
                if (head == null)
                {
                    tail = null;
                }
                return r.Inf;
            }
        }

        public bool isEmpty()
        {
                return (head == null);
        }

        public void Print()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            temp = head;
            output.Append("[");
            while (temp != null)
            {
                if (temp.Next == null)
                {
                    output.Append(temp.Inf);
                    temp = temp.Next;
                }
                else
                {
                    output.Append(temp.Inf + ", ");
                    temp = temp.Next;
                }
            }

            output.Append("]\n");
            return output.ToString();
        }

        // удалить вхождение каждого четного элемента в списке
        public void DeleteEvenElements()
        {
            if (head.Inf is int || head.Inf is long || head.Inf is short)
            {

                while (Convert.ToInt32(head.Inf) % 2 == 0)
                {
                    //Console.WriteLine(head.Inf);
                    head = head.Next;

                }
            }
                temp = head;


                while (temp.Next != null)
                {
                    if (head.Inf is int || head.Inf is long || head.Inf is short)
                    {
                        if ((Convert.ToInt32(temp.Next.Inf) % 2) == 0)
                        {
                            while (temp.Next != null && Convert.ToInt32(temp.Next.Inf) % 2 == 0)
                            {
                                temp.Next = temp.Next.Next;

                            }
                        }
                        temp = temp.Next;
                    }
                    else
                    {
                        throw new Exception("Объекты внутри списка не являются целыми числами");
                    }
            }
            
        }

        public void DoubleEvenElements()
        {
            temp = head;

            while (temp != null)
            {

                if (temp.Next != null)
                {

                    while (temp != null && Convert.ToInt32(temp.Inf) % 2 == 0)
                    {
                        Node r2 = new Node(temp.Inf);
                        r2.Next = temp.Next;
                        temp.Next = r2;
                        temp = temp.Next.Next;
                        // Console.WriteLine(r.Inf);
                    }

                    // Если temp достиг последнего.Next
                    if (temp != null) 
                    { 
                        temp = temp.Next;
                    }

                }

                // Если temp стал последним
                else
                {
                    if (Convert.ToInt32(temp.Inf) % 2 == 0)
                    {
                        temp.Next = new Node(temp.Inf);
                        temp = temp.Next;
                        tail = temp;
                    }
                    temp = temp.Next;
                    
                }
            }
        }
    }
}
