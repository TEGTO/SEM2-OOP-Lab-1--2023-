using OOP_Lab_1;
using Task1.MyList;
using Task1.Sorting;
using Task1.SortingMethods;

namespace SortingMethodsUnitTests
{
    public class InsertionTests
    {
        private SortingEventArgs<double> actualList;
        private MyList<double> expectedResultList;
        InsertionSort<double> insertionSort;
        [SetUp]
        public void Setup()
        {
            //Assign
            insertionSort = new InsertionSort<double>();
            actualList = new SortingEventArgs<double>();
            actualList.myList = new MyList<double>();
            expectedResultList = new MyList<double>();
            for (int i = 500; i >= 0; i--)
            {

                actualList.myList.AddHead(i);
            }
            for (int i = 0; i <= 500; i++)
            {
                expectedResultList.AddHead(i);
            }
        }

        [Test]
        public void SortListExpectedSortedListEqual()
        {


            //Act
            insertionSort.Sort(this, actualList);
            //Assert
            Assert.AreEqual(expectedResultList, actualList.myList);
        }
        [Test]
        public void SortListExpectedSortedListNotEqual()
        {
            //Assign

            expectedResultList = new MyList<double>();
            //Act
            insertionSort.Sort(this, actualList);
            //Assert
            Assert.AreNotEqual(expectedResultList, actualList.myList);
        }
        [Test]
        public void SortListExpectedSortedListEqualString()
        {
            //Assign
            SortingEventArgs<string> charActualList = new SortingEventArgs<string>();
            MyList<string> charExpectedResultList = new MyList<string>();
            InsertionSort<string> charInsertionSort = new InsertionSort<string>();
            charActualList.myList = new MyList<string>();
            charActualList.myList.AddHead("C");
            charActualList.myList.AddHead("B");
            charActualList.myList.AddHead("A");

            charExpectedResultList.AddHead("A");
            charExpectedResultList.AddHead("B");
            charExpectedResultList.AddHead("C");
            //Act
            charInsertionSort.Sort(this, charActualList);
            //Assert
            Assert.AreEqual(charExpectedResultList, charActualList.myList);
        }
        [Test]
        public void SortListExpectedThrowing()
        {
            //Act + Assert
            Assert.Throws<NullReferenceException>(() => insertionSort.Sort(this, null));
        }
    }
    public class QuickSortTests
    {
        private SortingEventArgs<double> actualList;
        private MyList<double> expectedResultList;
        QuickSort<double> quickSort;
        [SetUp]
        public void Setup()
        {
            //Assign
            quickSort = new QuickSort<double>();
            actualList = new SortingEventArgs<double>();
            actualList.myList = new MyList<double>();
            expectedResultList = new MyList<double>();
            for (int i = 500; i >= 0; i--)
            {

                actualList.myList.AddHead(i);
            }
            for (int i = 0; i <= 500; i++)
            {
                expectedResultList.AddHead(i);
            }
        }

        [Test]
        public void SortListExpectedSortedListEqual()
        {


            //Act
            quickSort.Sort(this, actualList);
            //Assert
            Assert.AreEqual(expectedResultList, actualList.myList);
        }
        [Test]
        public void SortListExpectedSortedListNotEqual()
        {
            //Assign   
            expectedResultList = new MyList<double>();
            //Act
            quickSort.Sort(this, actualList);
            //Assert
            Assert.AreNotEqual(expectedResultList, actualList.myList);
        }
        [Test]
        public void SortListExpectedSortedListEqualString()
        {
            //Assign
            SortingEventArgs<string> charActualList = new SortingEventArgs<string>();
            MyList<string> charExpectedResultList = new MyList<string>();
            QuickSort<string> charQuickSort = new QuickSort<string>();
            charActualList.myList = new MyList<string>();
            charActualList.myList.AddHead("C");
            charActualList.myList.AddHead("B");
            charActualList.myList.AddHead("A");

            charExpectedResultList.AddHead("A");
            charExpectedResultList.AddHead("B");
            charExpectedResultList.AddHead("C");
            //Act
            charQuickSort.Sort(this, charActualList);
            //Assert
            Assert.AreEqual(charExpectedResultList, charActualList.myList);
        }
        [Test]
        public void SortListExpectedThrowing()
        {


            //Act + Assert
            Assert.Throws<NullReferenceException>(() => quickSort.Sort(this, null));
        }
    }
    public class MergeSortTests
    {
        private SortingEventArgs<double> actualList;
        private MyList<double> expectedResultList;
        MergeSort<double> mergeSort;
        [SetUp]
        public void Setup()
        {
            //Assign
            mergeSort = new MergeSort<double>();
            actualList = new SortingEventArgs<double>();
            actualList.myList = new MyList<double>();
            expectedResultList = new MyList<double>();
            for (int i = 500; i >= 0; i--)
            {

                actualList.myList.AddHead(i);
            }
            for (int i = 0; i <= 500; i++)
            {
                expectedResultList.AddHead(i);
            }
        }

        [Test]
        public void SortListExpectedSortedListEqual()
        {


            //Act
            mergeSort.Sort(this, actualList);
            //Assert
            Assert.AreEqual(expectedResultList, actualList.myList);
        }
        [Test]
        public void SortListExpectedSortedListNotEqual()
        {
            //Assign   
            expectedResultList = new MyList<double>();
            //Act
            mergeSort.Sort(this, actualList);
            //Assert
            Assert.AreNotEqual(expectedResultList, actualList.myList);
        }

        [Test]
        public void SortListExpectedSortedListEqualString()
        {
            //Assign
            SortingEventArgs<string> charActualList = new SortingEventArgs<string>();
            MyList<string> charExpectedResultList = new MyList<string>();
            MergeSort<string> charMergeSort = new MergeSort<string>();
            charActualList.myList = new MyList<string>();
            charActualList.myList.AddHead("C");
            charActualList.myList.AddHead("B");
            charActualList.myList.AddHead("A");

            charExpectedResultList.AddHead("A");
            charExpectedResultList.AddHead("B");
            charExpectedResultList.AddHead("C");
            //Act
            charMergeSort.Sort(this, charActualList);
            //Assert
            Assert.AreEqual(charExpectedResultList, charActualList.myList);
        }
        [Test]
        public void SortListExpectedThrowing()
        {


            //Act + Assert
            Assert.Throws<NullReferenceException>(() => mergeSort.Sort(this, null));
        }
    }

    public class SelectionSortTests
    {
        private SortingEventArgs<double> actualList;
        private MyList<double> expectedResultList;
        SelectionSort<double> selectionSort;
        [SetUp]
        public void Setup()
        {
            //Assign
            selectionSort = new SelectionSort<double>();
            actualList = new SortingEventArgs<double>();
            actualList.myList = new MyList<double>();
            expectedResultList = new MyList<double>();
            for (int i = 500; i >= 0; i--)
            {

                actualList.myList.AddHead(i);
            }
            for (int i = 0; i <= 500; i++)
            {
                expectedResultList.AddHead(i);
            }
        }

        [Test]
        public void SortListExpectedSortedListEqual()
        {


            //Act
            selectionSort.Sort(this, actualList);
            //Assert
            Assert.AreEqual(expectedResultList, actualList.myList);
        }
        [Test]
        public void SortListExpectedSortedListEqualString()
        {
            //Assign
             SortingEventArgs<string> charActualList = new SortingEventArgs<string>();
            MyList<string> charExpectedResultList = new MyList<string>();
            SelectionSort<string> charSelectionSort = new SelectionSort<string>();
            charActualList.myList = new MyList<string>();
            charActualList.myList.AddHead("C");
            charActualList.myList.AddHead("B");
            charActualList.myList.AddHead("A");

            charExpectedResultList.AddHead("A");
            charExpectedResultList.AddHead("B");
            charExpectedResultList.AddHead("C");
            //Act
            charSelectionSort.Sort(this, charActualList);
            //Assert
            Assert.AreEqual(charExpectedResultList, charActualList.myList);
        }
        [Test]
        public void SortListExpectedSortedListNotEqual()
        {
            //Assign   
            expectedResultList = new MyList<double>();
            //Act
            selectionSort.Sort(this, actualList);
            //Assert
            Assert.AreNotEqual(expectedResultList, actualList.myList);
        }
        [Test]
        public void SortListExpectedThrowing()
        {


            //Act + Assert
            Assert.Throws<NullReferenceException>(() => selectionSort.Sort(this, null));
        }
    }
    public class CountingSortTests
    {
        private SortingEventArgs<int> actualList;
        private MyList<int> expectedResultList;
        CountingSort<int> countingSort;
        [SetUp]
        public void Setup()
        {
            //Assign
            countingSort = new CountingSort<int>();
            actualList = new SortingEventArgs<int>();
            actualList.myList = new MyList<int>();
            expectedResultList = new MyList<int>();
            for (int i = 500; i >= 0; i--)
            {

                actualList.myList.AddHead(i);
            }
            for (int i = 0; i <= 500; i++)
            {
                expectedResultList.AddHead(i);
            }
        }

        [Test]
        public void SortListExpectedSortedListEqual()
        {


            //Act
            countingSort.Sort(this, actualList);
            //Assert
            Assert.AreEqual(expectedResultList, actualList.myList);
        }
        [Test]
        public void SortListExpectedSortedListNotEqual()
        {
            //Assign   
            expectedResultList = new MyList<int>();
            //Act
            countingSort.Sort(this, actualList);
            //Assert
            Assert.AreNotEqual(expectedResultList, actualList.myList);
        }
        [Test]
        public void SortListExpectedThrowing()
        {


            //Act + Assert
            Assert.Throws<NullReferenceException>(() => countingSort.Sort(this, null));
        }
        [Test]
        public void SortListExpectedWrongTypeThrowing()
        {
            //Assign
              SortingEventArgs<double> wrongTypeList = new SortingEventArgs<double>();
            wrongTypeList.myList = new MyList<double>();
            CountingSort<double> countingSortBuffer = new CountingSort<double>();
            //Act + Assert
            Assert.Throws<NotSupportedException>(() => countingSortBuffer.Sort(this, wrongTypeList));
        }
    }
    public class BucketSortTests
    {
        private SortingEventArgs<double> actualList;
        private MyList<double> expectedResultList;
        private BucketSort<double> bucketSort;
        [SetUp]
        public void Setup()
        {
            //Assign
            bucketSort = new BucketSort<double>();
            actualList = new SortingEventArgs<double>();
            actualList.myList = new MyList<double>();
            expectedResultList = new MyList<double>();
            for (int i = 500; i >= 0; i--)
            {

                actualList.myList.AddHead(i);
            }
            for (int i = 0; i <= 500; i++)
            {
                expectedResultList.AddHead(i);
            }
        }

        [Test]
        public void SortListExpectedSortedListEqual()
        {


            //Act
            bucketSort.Sort(this, actualList);
            //Assert
            Assert.AreEqual(expectedResultList, actualList.myList);
        }
        [Test]
        public void SortListExpectedSortedListEqualString()
        {
            //Assign
            SortingEventArgs<string> charActualList = new SortingEventArgs<string>();
            MyList<string> charExpectedResultList = new MyList<string>();
            SelectionSort<string> charSelectionSort = new SelectionSort<string>();
            charActualList.myList = new MyList<string>();
            charActualList.myList.AddHead("C");
            charActualList.myList.AddHead("B");
            charActualList.myList.AddHead("A");

            charExpectedResultList.AddHead("A");
            charExpectedResultList.AddHead("B");
            charExpectedResultList.AddHead("C");
            //Act
            charSelectionSort.Sort(this, charActualList);
            //Assert
            Assert.AreEqual(charExpectedResultList, charActualList.myList);
        }
        [Test]
        public void SortListExpectedSortedListNotEqual()
        {
            //Assign   
            expectedResultList = new MyList<double>();
            //Act
            bucketSort.Sort(this, actualList);
            //Assert
            Assert.AreNotEqual(expectedResultList, actualList.myList);
        }
        [Test]
        public void SortListExpectedThrowing()
        {


            //Act + Assert
            Assert.Throws<NullReferenceException>(() => bucketSort.Sort(this, null));
        }
    }

}