using OOP_Lab_1;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// **Interface of all sort methods.**
/// </summary>

interface ISortMethod<T> where T : IComparable
{
    public void Sort(object source, SortingEventArgs<T> arg);
}

/// <summary>
/// Insertion sort class implements the interface. Contains insertion method for sorting.
/// </summary>

public class InsertionSort<T> : ISortMethod<T> where T: IComparable
{
      void Sorting(MyList<T> arr)
    {
        
        int n = arr.length;
       for (int i = 1; i < n; ++i)
        {
            var key = arr[i];
            int j = i - 1;
      
            while (j >= 0 && key.CompareTo(arr[j]) < 0)
            {

                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
      
    }
    public void Sort(object source, SortingEventArgs<T> arg)
    {
        Sorting(arg.myList);

    }

}
/// <summary>
/// Quick sort class implements the interface. Contains quick method for sorting.
/// </summary>
public class QuickSort<T> : ISortMethod<T> where T : IComparable
{

 
     int Partition(MyList<T> array, int minIndex, int maxIndex)
    {
        var pivot = minIndex - 1;
        T buffer;
        for (var i = minIndex; i < maxIndex; i++)
        {
            if (array[i].CompareTo(array[maxIndex]) <0)
            {
                pivot++;
                buffer = array[pivot];
                array[pivot] = array[i];
                array[i] = buffer; 
            }
        }

        pivot++;
        buffer = array[pivot];
        array[pivot] = array[maxIndex];
        array[maxIndex] = buffer;
        return pivot;
    }

     MyList<T>Sorting(MyList<T> array, int minIndex, int maxIndex)
    {
        if (minIndex >= maxIndex)
        {
            return array;
        }

        var pivotIndex = Partition(array, minIndex, maxIndex);
        Sorting(array, minIndex, pivotIndex - 1);
        Sorting(array, pivotIndex + 1, maxIndex);

        return array;
    }

    public void Sort(object source, SortingEventArgs<T> arg)
    {
         Sorting(arg.myList, 0, arg.myList.length - 1);
        
    }
}

/// <summary>
/// Merge sort class implements the interface. Contains merge method for sorting.
/// </summary>
public class MergeSort<T> : ISortMethod<T> where T : IComparable
{
    void Merge(MyList<T> arr, int l, int m, int r)
    {

        int n1 = m - l + 1;
        int n2 = r - m;
        T[] L = new T[n1];
        T[] R = new T[n2];
        int i, j;

        for (i = 0; i < n1; ++i)
            L[i] = arr[l + i];
        for (j = 0; j < n2; ++j)
            R[j] = arr[m + 1 + j];
        i = 0;
        j = 0;
        int k = l;
        while (i < n1 && j < n2)
        {
            if (L[i].CompareTo(R[j]) <= 0)
            {
                arr[k] = L[i];
                i++;
            }
            else
            {
                arr[k] = R[j];
                j++;
            }
            k++;
        }
        while (i < n1)
        {
            arr[k] = L[i];
            i++;
            k++;
        }
        while (j < n2)
        {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    void Sorting(MyList<T> arr, int l, int r)
    {
        if (l < r)
        {

            int m = l + (r - l) / 2;

            Sorting(arr, l, m);
            Sorting(arr, m + 1, r);
            Merge(arr, l, m, r);
        }
    }
   public void Sort(object source, SortingEventArgs<T> arg)
    {
        Sorting(arg.myList, 0, arg.myList.length - 1);
    }
}

/// <summary>
/// Bubble sort class implements the interface. Contains bubble method for sorting.
/// </summary>
public class BubbleSort<T> : ISortMethod<T> where T : IComparable
{
     void bubbleSort(MyList<T> arr)
    {
        int n = arr.length;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (arr[j].CompareTo(arr[j+1]) >0)
                {
                    // swap temp and arr[i]
                    var temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
    }
    public void Sort(object source, SortingEventArgs<T> arg)
    {
        bubbleSort(arg.myList);
    }


}

/// <summary>
/// Selection sort class implements the interface. Contains selection method for sorting.
/// </summary>
public class SelectionSort<T> : ISortMethod<T> where T : IComparable
{
     void Sorting(MyList<T> arr)
    {
        int n = arr.length;

     
        for (int i = 0; i < n - 1; i++)
        {
          
            int min_idx = i;
            for (int j = i + 1; j < n; j++)
                if (arr[j].CompareTo(arr[min_idx]) <0)
                    min_idx = j;

            var temp = arr[min_idx];
            arr[min_idx] = arr[i];
            arr[i] = temp;
        }


    }
    public void Sort(object source, SortingEventArgs<T> arg)
    {
        Sorting(arg.myList);
    }

}

/// <summary>
/// Counting sort class implements the interface. Contains counting method for sorting.
/// </summary>

public class CountingSort<T> : ISortMethod<T> where T : IComparable
{
     T FindMax(MyList<T> arr)
    {
        if (arr.length == 0)
        {
            throw new Exception("Array is empty");
        }
        var maxVal = arr[0];
        for (int i = 1; i < arr.length; i++)
            if (arr[i].CompareTo(maxVal) >0)
                maxVal = arr[i];
        return maxVal;
    }
      int FindMin(MyList<T> arr)
    {
        if (arr.length == 0)
        {
            throw new Exception("Array is empty");
        }

        int min = int.MaxValue;
        foreach (var i in arr)
        {
            if (i.CompareTo(min) < 0)
            {
                min =Convert.ToInt32(i);
            }
        }
        return min;
    }

  
    void Sorting(MyList<T> arr)
    {
        if (typeof(T) != typeof(int))
        {
            throw new NotSupportedException();
        }
    
        int max = Convert.ToInt32(FindMax(arr));
        int min = Convert.ToInt32(FindMin(arr));
        int range = max - min + 1;
        int[] count = new int[range];
        T[] output = new T[arr.length];
        for (int i = 0; i < arr.length; i++)
        {
            count[Convert.ToInt32(arr[i]) - min]++;
        }
        for (int i = 1; i < count.Length; i++)
        {
            count[i] += count[i - 1];
        }
        for (int i = arr.length - 1; i >= 0; i--)
        {
            output[count[Convert.ToInt32(arr[i]) - min] - 1] =arr[i];
            count[Convert.ToInt32(arr[i]) - min]--;
        }
        for (int i = 0; i < arr.length; i++)
        {
            arr[i] =output[i];
        }
    }
    public void Sort(object source, SortingEventArgs<T> arg)
    {
       
        Sorting(arg.myList);
    }
   
}
/// <summary>
/// Bucket sort class implements the interface. Contains bucket method for sorting.
/// </summary>

public class BucketSort<T> : ISortMethod<T> where T : IComparable
{
     void Sorting(MyList<T> arr)
    {
        int n = arr.length;
        if (n <= 0)
            return;

       List<T>[] buckets = new List<T>[n];

        for (int i = 0; i < n; i++)
        {
            buckets[i] = new List<T>();
        }
        for (int i = 0; i < n; i++)
        {
        float idx = n / 2;
          buckets[(int)idx].Add(arr[i]);
        }  
        for (int i = 0; i < n; i++)
        {
            buckets[i].Sort();
        }
        int index = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < buckets[i].Count; j++)
            {
                arr[index++] = buckets[i][j];
            }
        }
    }
    public void Sort(object source, SortingEventArgs<T> arg)
    {

        Sorting(arg.myList);
    }
}
