using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Task1.MyList;
using Task1.Sorting;
using Task1.SortingMethods;

namespace Task1.Invoker
{
    /// <summary>
    ///  **Class subscribes sort methods.**
    /// </summary>
    public class SortMethodsInvoker<T> where T : IComparable
    {
        /// <summary>
        /// List to sort. This list are used for adding new elements, sorting by different methods.
        /// </summary>
        public MyList<T> listToSort;
        /// <summary>
        /// Sort event handler. Event for containing different sort methods.
        /// </summary>
        public SortEventHandler<T> subscribeSortMethods = new SortEventHandler<T>();
        public TextBox textBox;
        /// <summary>
        /// The function that is used to subscribe the sort methods to the sort event.
        /// </summary>
        /// <param name="methodForSigning">Sort method that would be subscribed.</param>
        //function to subscribe sort methods and sort listToSort
        public void SubscribeAndSort(ISortMethod<T> methodForSigning)
        {
            subscribeSortMethods.sortMethod += methodForSigning.Sort;
            subscribeSortMethods.Sort(listToSort);
            subscribeSortMethods.sortMethod -= methodForSigning.Sort;
            PrintList();
        }
        /// <summary>
        ///Method for printing list.
        /// </summary>
        void PrintList()
        {
            textBox.Text = "";
            int iterator = 0;
            foreach (var item in listToSort)
            {
                textBox.Text += iterator == 0 ? item : " " + item;
                iterator++;

            }
        }
    }
}
