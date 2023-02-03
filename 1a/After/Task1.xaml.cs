using System;
using System.Windows;

namespace OOP_Lab_1
{
    public partial class Task1 : Window
    {

        MyList<int> listToSort = new MyList<int> { };
        SortEventHandler<int> subscribeSortMethods = new SortEventHandler<int>();
        public Task1()
        {
            InitializeComponent();

        }

        //add element button
        private void Button_AddElement(object sender, RoutedEventArgs e)
        {

            Random random = new Random();
            int randomNumber = random.Next(100);
            listToSort.AddHead(randomNumber);
            textBox.Text += listToSort.length <= 1 ? randomNumber.ToString() : " " + randomNumber.ToString();


        }
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
        //function to subscribe sort methods and sort listToSort
        void SubscribeAndSort(ISortMethod<int> foo)
        {
            subscribeSortMethods.sortMethod += foo.Sort;
            subscribeSortMethods.Sort(listToSort);
            subscribeSortMethods.sortMethod -= foo.Sort;
            PrintList();
        }
        //print list to sort
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

        private void Button_PrintList(object sender, RoutedEventArgs e)
        {
            PrintList();
        }
        //Different buttons that contain different sort methods 
        private void Button_InsertionSort(object sender, RoutedEventArgs e)
        {
            var insertion = new Insertion<int>();
            SubscribeAndSort(insertion);
        }

        private void Button_QuickSort(object sender, RoutedEventArgs e)
        {
            var quickSort = new QuickSort<int>();
            SubscribeAndSort(quickSort);
        }
        private void Button_MergeSort(object sender, RoutedEventArgs e)
        {
            var mergeSort = new MergeSort<int>();
            SubscribeAndSort(mergeSort);
        }

        private void Button_BubbleSort(object sender, RoutedEventArgs e)
        {
            var bubbleSort = new BubbleSort<int>();
            SubscribeAndSort(bubbleSort);
        }

        private void Button_SelectionSort(object sender, RoutedEventArgs e)
        {
            var selectionSort = new SelectionSort<int>();
            SubscribeAndSort(selectionSort);
        }

        private void Button_CountingSort(object sender, RoutedEventArgs e)
        {
            var countingSort = new CountingSort<int>();
            SubscribeAndSort(countingSort);
        }

        private void Button_BucketSort(object sender, RoutedEventArgs e)
        {
            var bucketSort = new BucketSort<int>();
            SubscribeAndSort(bucketSort);
        }

        private void Button_OpenTask2(object sender, RoutedEventArgs e)
        {

            Task2 Task2 = new Task2();
            Task2.Show();

        }

     
    }
}
