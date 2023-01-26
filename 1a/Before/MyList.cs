
using System;
using System.Collections.Generic;

namespace OOP_Lab_1
{

    public class MyList<T> where T : IComparable
    {
       
        public class Node
        {

            private T data;
            public Node(T t)
            {
                next = null;
          
                data = t;
            }

            private Node? next;
           
            public Node? Next
            {
                get { return next; }
                set { next = value; }

            }
            

            public T Data
            {
                get { return data; }
                set { data = value; }
            }

            
        }
        
        public int Length { get; set; }
        private Node? head;
        public T this[int i]
        {
            get 
            {
               
                int it = 0 ;
                Node? current = head;
                while (it != i)
                {
                    current = current.Next;
                    it++;
                }
                return current.Data;
            }
            set
            {
             
                int it = 0;
                Node? current = head;
                while (it != i)
                {
                    current = current.Next;
                    it++;
                }
                current.Data = value;
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
            if (current.Data.CompareTo(value) == 0) return 0;
            while (current.Data.CompareTo(value) !=0)
            {
                current = current.Next;
                index++;
                if (index >= Length)
                    return -1;
              
            }
            return index;
            
        }
        public void AddHead(T t)
        {
            Node n = new Node(t);
            if (Length==0)
            {
                head = n;
             
            }
            else
            {
                Node? current = head;

                while (current != null)
                {
                    if (current.Next == null)
                    {
                        current.Next = n;
                        break;
                    }
                    current=current.Next;
                    
                   
                }
              
            }
            Length++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node? current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
      
    }
}
