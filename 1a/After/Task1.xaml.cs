using System;
using System.Windows;

namespace OOP_Lab_1
{
    /*! \mainpage Documentation of First OOP Lab. 
*
* \section intro_sec Task1
* • Task1
* 
* • MyList
* 
* • SortEventHandler
* 
* • ISortMethod
* 
* • InsertionSort
* 
* • QuickSort
* 
* • MergeSort
* 
* • BubbleSort
* 
* • SelectionSort
* 
* • BucketSort
* 
* \section install_sec Tast2
* • Task2
* 
* • Triangle
* 
* • Quadrilateral
* 
* • Pentagon
* 
* • Circle
* 
* • TextChecking
* 
*
* 
*/
    /// <summary>
    ///   **Class that contains tasks of part one of the exercise.**
    /// </summary>
    public partial class Task1 : Window
    {
        /// <summary>
        /// Main list to sort. This list are used for adding new elements, sorting by different methods.
        /// </summary>
        MyList<int> listToSort = new MyList<int> { };
        /// <summary>
        /// Sort event handler. Event for containing different sort methods.
        /// </summary>
        SortEventHandler<int> subscribeSortMethods = new SortEventHandler<int>();
        /// <summary>
        ///  Initialize UI and some elements.
        /// </summary>
        public Task1()
        {
            InitializeComponent();
         
        }
        /// <summary>
        /// Button method for adding new random elements in range (0,100) to list.
        /// </summary>
        /// <param name="sender">The element that called the method.</param>
        /// <param name="e">Contains state information and event data associated with a routed event.</param>
        //add element button
        private void Button_AddElement(object sender, RoutedEventArgs e)
        {

            Random random = new Random();
            int randomNumber = random.Next(100);
            listToSort.AddHead(randomNumber);
            textBox.Text += listToSort.length <= 1 ? randomNumber.ToString() : " " + randomNumber.ToString();


        }
        /// <summary>
        /// Button method for shuffling elements in the list.
        /// </summary>
        /// <param name="sender">The element that called the method.</param>
        /// <param name="e"> Contains state information and event data associated with a routed event.</param>
        //shuffle and print listToSort button 
        private void Button_ShuffleList(object sender, RoutedEventArgs e)
        {

            Random random = new Random();
            
            for (int i = 0; i < listToSort.length; i++)
            {
                listToSort[i] = random.Next(100);
               
            }

            PrintList();
        }
        /// <summary>
        /// The function that is used to subscribe the sort methods to the sort event.
        /// </summary>
        /// <param name="methodForSigning">Sort method that would be subscribed.</param>
        //function to subscribe sort methods and sort listToSort
        void SubscribeAndSort(ISortMethod<int> methodForSigning)
        {
            subscribeSortMethods.sortMethod += methodForSigning.Sort;
            subscribeSortMethods.Sort(listToSort);
            subscribeSortMethods.sortMethod -= methodForSigning.Sort;
            PrintList();
        }
        //print list to sort
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
        /// <summary>
        /// Button method that uses the print function.
        /// </summary>
        /// <param name="sender">The element that called the method.</param>
        /// <param name="e"> Contains state information and event data associated with a routed event.</param>
        private void Button_PrintList(object sender, RoutedEventArgs e)
        {
            PrintList();
        }
        //Different buttons that contain different sort methods 
        /// <summary>
        /// Button method that subscribes InsertionSort method on the sort event.
        /// </summary>
        /// <param name="sender">The element that called the method.</param>
        /// <param name="e"> Contains state information and event data associated with a routed event.</param>
        private void Button_InsertionSort(object sender, RoutedEventArgs e)
        {
            var insertion = new InsertionSort<int>();
            SubscribeAndSort(insertion);
        }
        /// <summary>
        /// Button method that subscribes QuickSort method on the sort event.
        /// </summary>
        /// <param name="sender">The element that called the method.</param>
        /// <param name="e"> Contains state information and event data associated with a routed event.</param>
        private void Button_QuickSort(object sender, RoutedEventArgs e)
        {
            var quickSort = new QuickSort<int>();
            SubscribeAndSort(quickSort);
        }
        /// <summary>
        ///*Button method that subscribes MergeSort method on the sort event.
        /// </summary>
        /// <param name="sender">The element that called the method.</param>
        /// <param name="e"> Contains state information and event data associated with a routed event.</param>
        private void Button_MergeSort(object sender, RoutedEventArgs e)
        {
            var mergeSort = new MergeSort<int>();
            SubscribeAndSort(mergeSort);
        }
        /// <summary>
        ///Button method that subscribes BubbleSort method on the sort event.
        /// </summary>
        /// <param name="sender">The element that called the method.</param>
        /// <param name="e"> Contains state information and event data associated with a routed event.</param>
        private void Button_BubbleSort(object sender, RoutedEventArgs e)
        {
            var bubbleSort = new BubbleSort<int>();
            SubscribeAndSort(bubbleSort);
        }
        /// <summary>
        /// Button method that subscribes SelectionSort method on the sort event.
        /// </summary>
        /// <param name="sender">The element that called the method.</param>
        /// <param name="e"> Contains state information and event data associated with a routed event.</param>
        private void Button_SelectionSort(object sender, RoutedEventArgs e)
        {
            var selectionSort = new SelectionSort<int>();
            SubscribeAndSort(selectionSort);
        }
        /// <summary>
        ///Button method that subscribes CountingSort method on the sort event.
        /// </summary>
        /// <param name="sender">The element that called the method.</param>
        /// <param name="e"> Contains state information and event data associated with a routed event.</param>
        private void Button_CountingSort(object sender, RoutedEventArgs e)
        {
            var countingSort = new CountingSort<int>();
            SubscribeAndSort(countingSort);
        }
        /// <summary>
        /// Button method that subscribes BucketSort method on the sort event.
        /// </summary>
        /// <param name="sender">The element that called the method.</param>
        /// <param name="e"> Contains state information and event data associated with a routed event.</param>
        private void Button_BucketSort(object sender, RoutedEventArgs e)
        {
            var bucketSort = new BucketSort<int>();
            SubscribeAndSort(bucketSort);
        }
        /// <summary>
        /// Button method that opens Task2 window.
        /// </summary>
        /// <param name="sender">The element that called the method.</param>
        /// <param name="e"> Contains state information and event data associated with a routed event.</param>
        private void Button_OpenTask2(object sender, RoutedEventArgs e)
        {

            Task2 Task2 = new Task2();
            Task2.Show();

        }

     
    }
}
