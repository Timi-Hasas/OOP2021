using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class MyQueue<Item> : IEnumerable<Item>
    {
        private Item[] data;
        private int capacity;
        private int first = 0, last = -1;
        private const int DEFAULT_CAPACITY = 32;
        public int Size { get; private set; } = 0;

        public MyQueue()
        {
            data = new Item[DEFAULT_CAPACITY];
            capacity = DEFAULT_CAPACITY;
        }
        public MyQueue(int capacity)
        {
            this.capacity = capacity;
            data = new Item[capacity];
        }

        public void Enqueue(Item item)
        {
            if (IsFull())
                throw new QueueFullException("The queue is full.");
            else
            {
                last = (last + 1) % capacity;
                data[last] = item;
                Size++;
            }
        }

        public Item Dequeue()
        {
            if (IsEmpty())
                throw new QueueEmptyException("The queue is empty.");
            else
            {
                int temp = first;
                first = (first + 1) % capacity;
                Size--;
                return data[temp];
            }
        }

        public bool IsEmpty()
        {
            if (Size == 0)
                return true;
            return false;
        }

        public bool IsFull()
        {
            if (Size == capacity)
                return true;
            return false;
        }

        public void Clear()
        {
            first = 0;
            last = -1;
            Size = 0;
        }

        public Item Peek()
        {
            return data[first];
        }

        public IEnumerator<Item> GetEnumerator()
        {
            if (IsEmpty())
                throw new QueueEmptyException("The queue is empty.");
            else
            {
                int i, j = 0;
                for (i = first; j < Size;)
                {
                    yield return data[i];
                    i = (i + 1) % capacity;
                    j++;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
