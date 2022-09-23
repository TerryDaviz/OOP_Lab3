using System;
using System.Collections.Generic;

namespace lab3
{
    public static class StatisticOperation
    {
        private static int qLength;

        static StatisticOperation()
        {
            qLength = 0;
        }

        public static int GetDif(Q<int> q1)
        {
            int max = getMax(q1);
            int min = getMin(q1);
            return max - min;
        }

        public static int GetFirstPoint(this Q<string> q1)
        {
            int i = 0;
            foreach (string x in q1.queue)
            {
                i++;
                if (x == ".")
                {
                    return i;
                }
            }
            return -1;
        }

        public static string GetFLastStringElement(this Q<string> q1)
        {
            return q1.queue[q1.queue.Count - 1];
        }

        public static int GetLength(Q<int> q1)
        {
            return qLength = q1.queue.Count;
        }

        public static int GetSum(Q<int> q1)
        {
            int max = getMax(q1);
            int min = getMin(q1);
            return max + min;
        }

        private static int getMax(Q<int> q1)
        {
            int max = q1.queue[0];
            foreach (int x in q1.queue)
            {
                if (x > max)
                {
                    max = x;
                }
            }
            return max;
        }

        private static int getMin(Q<int> q1)
        {
            int min = q1.queue[0];
            foreach (int x in q1.queue)
            {
                if (x < min)
                {
                    min = x;
                }
            }
            return min;
        }
    }

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

        public class Date
        {
            private DateTime dat;

            public Date()
            {
                this.dat = DateTime.Now;
            }

            public DateTime date => this.dat;
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
            int q5Length = (int)q5;
            Console.WriteLine("q5 length: " + q5Length);

            Q<byte>.Owner owning = q5.GetOwner;
            Console.WriteLine("Owner: " + owning.DefaultName + ",\nId:" + owning.Id);
            Console.WriteLine("StatisticOperation: sum = " + StatisticOperation.GetSum(q3));
            Console.WriteLine("StatisticOperation: sub = " + StatisticOperation.GetDif(q3));
            Console.WriteLine("StatisticOperation: sub = " + StatisticOperation.GetDif(q3));
            Console.WriteLine("StatisticOperation: length = " + StatisticOperation.GetLength(q3));
            Q<string> q6 = new Q<string>();
            q6.AddElement("aboba");
            q6.AddElement(".");
            Console.WriteLine("StatisticOperation: first point index: " + StatisticOperation.GetFirstPoint(q6));
            Console.WriteLine("StatisticOperation: last string element: " + StatisticOperation.GetFLastStringElement(q6));
        }
    }
}