using OOP_Lab_1;
using System;
public class SortingEventArgs<T> : EventArgs where T : IComparable
{
    public MyList<T> myList;
   

}
public  class SortEventHandler<T> where T : IComparable
{
    
        public event EventHandler<SortingEventArgs<T>> sortMethod;
        public void Sort(MyList <T> list)
        {
            StartSorting(list);
      
        }

        protected virtual void StartSorting(MyList<T> list)
        {
        sortMethod?.Invoke(this, new SortingEventArgs <T>{ myList = list });
        }
}

