using System;
using System.Collections.Generic;

namespace OOP_Lab_1
{

    public class MyList<T> where T : IComparable
    {
       
        public class Node
        {

            private T data_;
            public Node(T t)
            {
                next_ = null;
          
                data_ = t;
            }

            private Node? next_;
           
            public Node? next
            {
                get { return next_; }
                set { next_ = value; }

            }
            

            public T data
            {
                get { return data_; }
                set { data_ = value; }
            }

            
        }
        
        public int length { get; set; }
        private Node? head;
        public T this[int i]
        {
            get 
            {
               
                int it = 0 ;
                Node? current = head;
                while (it != i)
                {
                    current = current.next;
                    it++;
                }
                return current.data;
            }
            set
            {
             
                int it = 0;
                Node? current = head;
                while (it != i)
                {
                    current = current.next;
                    it++;
                }
                current.data = value;
            }
        }
       
        public MyList()
        {
            head = null;
        }

       public int FindByValue(T value)
        {
            int index = 0;
            Node? current = head;
            if (current.data.CompareTo(value) == 0) return 0;
            while (current.data.CompareTo(value) !=0)
            {
                current = current.next;
                index++;
                if (index >= length)
                    return -1;
              
            }
            return index;
            
        }
        public void AddHead(T t)
        {
            Node n = new Node(t);
            if (length==0)
            {
                head = n;
             
            }
            else
            {
                Node? current = head;

                while (current != null)
                {
                    if (current.next == null)
                    {
                        current.next = n;
                        break;
                    }
                    current=current.next;
                    
                   
                }
              
            }
            length++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node? current = head;

            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }
      
    }
}
