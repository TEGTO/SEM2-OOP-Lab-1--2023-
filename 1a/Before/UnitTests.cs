using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_1
{
    class UnitTestsSortingMethods
    {
        static MyList<int> listToSort;
        static Sorting<int> sortingMethods = new Sorting<int>();
        public static string[] statusMessages = new string[8];
        static uint it = 0;
        public static void unitTestStart()
        {
            Insertion<int> insertionSort = new Insertion<int>();
            test(insertionSort, "insertionSort");
            QuickSort<int> quickSort = new QuickSort<int>();
            test(quickSort, "quickSort");
            MergeSort<int> mergeSort = new MergeSort<int>();
            test(mergeSort, "mergeSort");
            BubbleSort<int> bubbleSort = new BubbleSort<int>();
            test(bubbleSort, "bubbleSort");
            SelectionSort<int> selectionSort = new SelectionSort<int>();
            test(selectionSort, "selectionSort");
            CountingSort<int> countingSort = new CountingSort<int>();
            test(countingSort, "countingSort");
            BucketSort<int> bucketSort = new BucketSort<int>();
            test(bucketSort, "bucketSort");
            statusMessages[7] = statusMessages[7]?.Length <= 0 || statusMessages[7] == null ? "Unit Test is successfully completed" : statusMessages[7];

        }
        static void test(SortMethod<int> foo, string sortMethod)
        {
            fillList(500);
            try
            {
                SubscribeSortMethod(foo);
            }
            catch (Exception)
            {
                statusMessages[it] = sortMethod + " error";
                statusMessages[7] = "Unit Test is failed";
                it++;
                throw new Exception(statusMessages[it]);
            }
            statusMessages[it] = sortMethod + " is fine";
            it++;
        }
        static void SubscribeSortMethod(SortMethod<int> foo)
        {

            //throw new Exception(statusMessages[it]);
            sortingMethods.SortMethods += foo.Sort;
            sortingMethods.Sort(listToSort);
            sortingMethods.SortMethods -= foo.Sort;

        }
        static void fillList(int size)
        {
            try
            {
                listToSort = new MyList<int>();
                for (int i = 0; i < size; i++)
                {
                    Random random = new Random();
                    int randomNumber = random.Next(250);
                    listToSort.AddHead(randomNumber);
                }
            }
            catch (Exception)
            {


                throw new Exception("A list filling error"); ;
            }

        }
    }
}
