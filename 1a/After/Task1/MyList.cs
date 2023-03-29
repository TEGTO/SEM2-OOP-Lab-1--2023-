using System;
using System.Collections.Generic;

namespace Task1.MyList
{


/// <summary>
/// **Own list, which is used for all exercises of the first part.**
/// 
/// \details The class contains another class that is used for iterations.
/// </summary>
/// 
/// 

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
        /// <summary>
        /// Length of the list.
        /// </summary>
        public int length { get; set; }
    /// <summary>
    /// First element of the list.
    /// </summary>
        private Node? head;
    /// <summary>
    /// Operator [] overloading.
    /// </summary>
    /// <param name="i"> Index of element that we need to find.</param>
    /// <returns>If element was found returns data under index element. Otherwise throws error.</returns>
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
    /// <summary>
    /// Method for finding index by element.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Returns index of the element.</returns>
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
    /// <summary>
    /// Add element to top of list.
    /// </summary>
    /// <param name="element">Element that we want to add.</param>
    public void AddHead(T element)
        {
            Node n = new Node(element);
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
    /// <summary>
    /// Method for comparing two lists.
    /// </summary>
    /// <param name="obj">The object being tested to see if it is a list. </param>
    /// <returns>If lists are same returns true. Otherwise false.</returns>
    public override bool Equals(object obj)
        {
            var otherList = obj as MyList<T>;

            if (otherList == null)
                return false;

            if (otherList.length != length)
                return false;

            Node? currentThis = head;
            Node? currentOther = otherList.head;
            while (currentThis != null)
            {
                if (currentThis.data.CompareTo(currentOther.data) != 0)
                {
                    return false;
                }
                currentThis = currentThis.next;
                currentOther = currentOther.next;
            }

            return true;
        }
    /// <summary>
    /// The method are using in foreach.
    /// </summary>
    /// <returns></returns>
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