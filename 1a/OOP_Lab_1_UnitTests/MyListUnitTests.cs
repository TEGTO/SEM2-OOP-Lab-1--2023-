using OOP_Lab_1;

namespace MyListUnitTests
{

    public class MyListUnitTests
    {
        private MyList<double> actualList;
        private MyList<double> expectedResultList;
        [SetUp]
        public void Setup()
        {
            //Assign
            actualList = new MyList<double>();
            expectedResultList = new MyList<double>();
        }
        [Test]
        public void AddHeadTestExpectedCorrectAdding()
        {
            //Act
            actualList.AddHead(1);
            actualList.AddHead(2);
            actualList.AddHead(3);
            actualList.AddHead(4);
            actualList.AddHead(5);
            //Assert
            Assert.AreEqual(5, actualList.length);
            int expectedElement = 1;
            foreach (var actualElement in actualList)
            {
                Assert.AreEqual(expectedElement, actualElement);
                expectedElement++;
            }
        }
        [Test]
        public void EqualsTestExpectedEqual()
        {
            //Act
            actualList.AddHead(1);
            actualList.AddHead(2);
            expectedResultList.AddHead(1);
            expectedResultList.AddHead(2);
            //Assert
           Assert.IsTrue(actualList.Equals(expectedResultList));
        }
        [Test]
        public void EqualsTestExpectedNonEqual()
        {
            //Act
            actualList.AddHead(1);
            actualList.AddHead(2);
        
            //Assert
            Assert.IsFalse(actualList.Equals(expectedResultList));
        }
        [Test]
        public void FindByValueTestExpectedSuccess()
        {
            //Act
            actualList.AddHead(1);
            actualList.AddHead(2);
            actualList.AddHead(3);

            //Assert
            Assert.AreEqual(3, actualList[actualList.FindByValue(3)]);    
        }
        [Test]
        public void FindByValueTestExpectedFailureReturnMinusOne()
        {
            //Act
            actualList.AddHead(1);
            actualList.AddHead(2);
         
            //Assert
            
            Assert.AreEqual(-1, actualList.FindByValue(3));
        }
    }
}
