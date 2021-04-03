using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueList<int> queue = new QueueList<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            
            foreach(int i in queue)
                Console.WriteLine(i);

            Console.WriteLine(queue.Count);
        }
    }
}
