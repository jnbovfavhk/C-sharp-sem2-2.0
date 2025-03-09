using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.prac_20
{
    class Node
    {
        private object info;
        private Node next;

        public object Inf
        {
            get { return info; }
        }
        public Node Next
        {
            get { return next; }
            set { next = value; }
        }

        public Node(object info)
        {
            this.info = info;
            next = null;
        }
    }
}
