using System;

using Queues.Models;
namespace Queues
{
    internal class Program
    {

        public static bool IsAscending(Queue<int> q)
        {
            Queue<int> copy = Copy(q);
            int x = copy.Remove();
            while (!copy.IsEmpty())
            {
                int y = copy.Remove();
                if (x > y)
                    return false;
                x=copy.Remove();
            }
            return true;
        }

        public static Queue<T> Copy<T>(Queue<T> original)
        {
            Queue<T> copy = new Queue<T>();
            Queue<T> temp = new Queue<T>();
            while (!original.IsEmpty())
            {
                temp.Insert(original.Remove());

            }
            while (!temp.IsEmpty())
            {
                copy.Insert(temp.Head());
                original.Insert(temp.Remove());
            }
            return copy;

        }

        public static int MinVal(Queue<int> q)
        {
            int min = int.MaxValue;
            Queue<int> copy = Copy(q);
            while (!copy.IsEmpty())
            {
                int val = copy.Remove();
                if ( val < min)
                    min = val;   
            }
            return min;

        }

        public static void RemoveMinVal(Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();
            int min = MinVal(q);
            while(!q.IsEmpty())
            {
                if (q.Head() != min)
                    temp.Insert(q.Remove());
                else
                    q.Remove();
            }
            while(!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
        }
        static void Main(string[] args)
        {
            Queue<int> q1= new Queue<int>();    
            q1.Insert(1);
            q1.Insert(2);
            q1.Insert(3);
            q1.Insert(4);
            q1.Insert(5);
            Console.WriteLine(q1);
            Console.WriteLine(QueueHelper.Count(q1));
            Console.WriteLine(IsAscending(q1));
            Console.WriteLine(MinVal(q1));
            RemoveMinVal(q1);
            Console.WriteLine(q1);
        }
    }
}