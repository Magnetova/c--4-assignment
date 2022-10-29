using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_4
{
    internal class GenericStack<T>
    {

        // Add to front

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
        public void Push(T Data)
        {
            // Make a new variable to also reference the head of the list
            Node oldHead = _head;

            // Make a new node and assign it to the head variable
            _head = new Node();

            // Set the data on the new node
            _head.Data = Data;

            // Make the next property of the new node point to the old head
            _head.Next = oldHead;

            // Increment the size of the list
            _size++;

            // Ensure that if we are adding the very first node to the list that the tail will be pointing to the new node we create. But only on first add.
            if (_size == 1)
            {
                _tail = _head;
            }
        }

 
        // This has a big O of O(1)
        public T Pop()
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
