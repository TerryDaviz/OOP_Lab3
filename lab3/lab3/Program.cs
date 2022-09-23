using System;
using System.Collections.Generic;

namespace lab3
{
    public class Q<T>
    {
        private Owner own = new Owner();
        private List<T> q;

        public Q()
        {
            this.q = new List<T>(1)
            {
            };
        }

        public Owner GetOwner => this.own;
        public List<T> queue => this.q;

        public static implicit operator int(Q<T> q1)
        {
            return q1.q.Capacity;
        }

        public static Q<T> operator --(Q<T> q1)
        {
            T lastElem = q1.q[q1.q.Count - 1];
            q1.q.RemoveAt(q1.q.Count - 1);
            return q1;
        }

        public static Q<T> operator +(Q<T> q1, T element)
        {
            q1.q.Insert(0, element);
            return new Q<T> { };
        }

        public static Q<T> operator <(Q<T> q1, Q<T> q2)
        {
            q2.q.Sort();
            q2.q.Reverse();
            List<T> bro = q2.q;
            q1.q.InsertRange(q1.q.Count, bro);
            return new Q<T> { };
        }

        public static Q<T> operator >(Q<T> q1, Q<T> q2)
        {
            return new Q<T> { };
        }

        public static bool operator false(Q<T> q1)
        {
            return q1.q.Count != 0;
        }

        public static bool operator true(Q<T> q1)
        {
            return q1.q.Count == 0;
        }

        public List<T> AddElement(T element)
        {
            this.q.Insert(0, element);
            Q<T> q1 = this;
            return q1.q;
        }

        public void ShowQ()
        {
            this.q.Reverse();
            foreach (T x in this.q)
            {
                Console.WriteLine(x);
            }
        }

        public class Owner
        {
            private readonly int id;
            private string name;

            public Owner()
            {
                Random random = new Random();
                this.id = random.Next(100);
                this.name = "Damege, Inc.";
            }

            public string DefaultName => this.name;
            public int Id => this.id;

            public string NewName(string value)
            {
                return this.name = value;
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
            Q<int> q2 = new Q<int>();
            for (int i = 3; i < 8; i++)
            {
                _ = q2 + i;
            }
            Console.WriteLine("testing + operator");
            q2.ShowQ();
            Console.WriteLine("testing -- operator");
            --q2;
            q2.ShowQ();
            Console.WriteLine("testing < operator");
            Q<int> q3 = new Q<int>();
            _ = q3 < q2;
            q3.ShowQ();
            Console.WriteLine("testing true operator");
            Q<int> q4 = new Q<int>();
            if (q4)
            {
                Console.WriteLine("queue is empty");
            }
            else
            {
                Console.WriteLine("queue is not empty");
            }
            Q<byte> q5 = new Q<byte>();
            q5.AddElement(3);
            _ = (int)q5;

            Q<byte>.Owner owning = q5.GetOwner;
            Console.WriteLine("Owner: " + owning.DefaultName + ",\nId:" + owning.Id);
        }
    }
}