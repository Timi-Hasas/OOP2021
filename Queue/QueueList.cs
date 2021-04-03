using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class QueueList<Item> : IEnumerable<Item>
    {
        private class Node
        {
            public Item data;
            public Node next;
        }

        private Node first = null;
        private Node last = null;
        public Item First { get => first.data;}
        public Item Last { get => last.data;}
        public int Count { get; private set; } = 0;
        public void Enqueue(Item data)
        {
            if (IsEmpty())
            {
                first = new Node();
                first.data = data;
                first.next = null;
                last = first;
            }
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;
                last.next = toAdd;
                last = last.next;
            }
            Count++;
        }

        public Item Dequeue()
        {
            if (IsEmpty())
                throw new QueueEmptyException("The queue is empty");
            else
            {
                Count--;
                Node toReturn = first;
                first = first.next;
                return toReturn.data;
            }
        }
        public bool IsEmpty()
        {
            if (first == null)
                return true;
            return false;
        }
        public IEnumerator<Item> GetEnumerator()
        {
            Node current = first;
            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
