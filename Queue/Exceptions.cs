using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class QueueEmptyException : Exception
    {
        public QueueEmptyException()
        {

        }

        public QueueEmptyException(string message)
            : base(message)
        {

        }

        public QueueEmptyException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }

    class QueueFullException : Exception
    {
        public QueueFullException()
        {

        }
        public QueueFullException(string message)
            : base(message)
        {

        }

        public QueueFullException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
