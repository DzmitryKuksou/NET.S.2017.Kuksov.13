using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("qqqqq");
            queue.Enqueue("aaaaa");
            queue.Enqueue("bbbbbb");
            Console.WriteLine(queue.Peek());
            if (queue.Contains("qqqqq")) Console.WriteLine("There are this el.");
            if (queue.Contains("qqqq")) Console.WriteLine("There are this el.");
            queue.Clear();
            queue.Enqueue("ww");
            queue.Enqueue("www");
            queue.Enqueue("ccc");
            queue.Enqueue("rrr");
            queue.Dequeue();
            Console.WriteLine(queue.Peek());
            Queue<string> queue1 = new Queue<string>(queue);
            Console.WriteLine(queue.ToString());
            Console.WriteLine(queue1.ToString());
            if (queue == queue1) Console.WriteLine("Is equal!");
            Console.ReadLine();
        }
    }
}
