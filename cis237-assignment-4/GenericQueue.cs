using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_4
{
    internal class GenericQueue<T>
    {
        // Add to back



        // Remove from front

        // Make node clas as an inner class
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        // A couple of pointers to the head and tail of the linked list.
        protected Node _head;
        protected Node _tail;
        protected int _size;

        public bool IsEmpty
        {
            get
            {
                // To check whether or not it is empty we can check to see if the head pointer is null. If so, there are no nodes in the list, so it must be empty.
                return _head == null;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        // This has a big O of O(1)
        public void Enqueue(T Data)
        {
            // Make a pointer to the tail called oldTail
            Node oldTail = _tail;

            // Make a new node and assign it to the tail variable
            _tail = new Node();

            //Assign the data and set the next pointer
            _tail.Data = Data;
            _tail.Next = null;

            // Check to see if the list is empty. If so, make the head point to the same location as the tail
            if (IsEmpty)
            {
                _head = _tail;
            }
            // We need to take the oldTail and make it's next property point to the tail that we just created
            else
            {
                oldTail.Next = _tail;
            }

            // Increment the size
            _size++;
        }

        // This has a big O of O(1)
        public T Dequeue()
        {
            // If it is empty throw an error
            if (IsEmpty)
            {
                throw new Exception("List is empty");
            }

            // Let's ge the data to return
            T returnData = _head.Data;

            // Move the head pointer to the next in the list
            _head = _head.Next;

            // Decrease the size
            _size--;

            // Check to see if we just removed the last node from the list
            if (IsEmpty)
            {
                _tail = null;
            }

            // Return the returnData we pulled out from the first node
            return returnData;
        }

    }
}
