using System;
using System.Collections.Generic;

namespace lab3
{
    public class Q<T>
    {
        private List<T> q;

        public Q()
        {
            this.q = new List<T>(1)
            {
            };
        }

        public List<T> queue => this.q;

        public List<T> AddElement(T element)
        {
            this.q.Insert(0, element);
            Q<T> q1 = this;
            return q1.q;
        }

        public void ShowQ()
        {
            foreach (T x in this.q)
            {
                Console.WriteLine(x);
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Q<int> q1 = new Q<int>();
            q1.AddElement(1);
            q1.AddElement(2);
            q1.AddElement(3);
            Console.WriteLine("test 1");
            q1.ShowQ();
        }
    }
}