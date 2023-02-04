using OOP_Lab_1;
using System;
public class SortingEventArgs<T> : EventArgs where T : IComparable
{
    public MyList<T> myList;
   

}

/// <summary>
/// The sort class that contains different sort subscribers
/// </summary>

public class SortEventHandler<T> where T : IComparable
{
    /// <summary>
    /// **Event for subscribing different sort methods**
    /// </summary>
    public event EventHandler<SortingEventArgs<T>> sortMethod;
    /// <summary>
    /// **The method for sorting MyList list.**
    /// </summary>

    public void Sort(MyList <T> list)
        {
            StartSorting(list);
      
        }

        protected virtual void StartSorting(MyList<T> list)
        {
        sortMethod?.Invoke(this, new SortingEventArgs <T>{ myList = list });
        }
}

