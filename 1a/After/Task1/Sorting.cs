using System;
using Task1.MyList;

namespace Task1.Sorting
{


    public class SortingEventArgs<T> : EventArgs where T : IComparable
    {
        public MyList<T> myList;


    }

    /// <summary>
    /// The sort class that will contain different sort subscribers.
    /// </summary>

    public class SortEventHandler<T> where T : IComparable
    {
        /// <summary>
        /// Event for subscribing different sort methods.
        /// </summary>
        public event EventHandler<SortingEventArgs<T>> sortMethod;
        /// <summary>
        /// The method for sorting **MyList list.**
        /// </summary>

        public void Sort(MyList<T> list)
        {
            StartSorting(list);

        }
        /// <summary>
        /// Protected method where the **MyList list** connects to the class.
        /// </summary>
        /// <param name="list">List for sorting.</param>
        protected virtual void StartSorting(MyList<T> list)
        {
            sortMethod?.Invoke(this, new SortingEventArgs<T> { myList = list });
        }
    }

}