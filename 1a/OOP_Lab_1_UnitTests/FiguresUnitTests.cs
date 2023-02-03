using OOP_Lab_1;
namespace FiguresUnitTests
{
    public class TriangleUnitTests
    {
        [Test]
        public void DefineTypeTestExpectedScaleneType()
        {
            //Assign
            Triangle.firstAngle = 50;
            Triangle.secondAngle =60;
            Triangle.thirdAngle = 70;
            Triangle.sirstSide = 5;
            Triangle.secondSide = 6;
            Triangle.thirdSide =8;
            //Act + Assert 
            Assert.AreEqual((int)TriangleTypes.Scalene, Triangle.DefineType());
        }

        [Test]
        public void DefineTypeTestExpectedEquilateralType()
        {
            //Assign
            Triangle.firstAngle = 60;
            Triangle.secondAngle = 60;
            Triangle.thirdAngle = 60;
            Triangle.sirstSide = 5;
            Triangle.secondSide = 5;
            Triangle.thirdSide = 5;
            //Act + Assert 
            Assert.AreEqual((int)TriangleTypes.Equilateral, Triangle.DefineType());
        }
        [Test]
        public void DefineTypeTestExpectedIsoscelesType()
        {
            //Assign
            Triangle.firstAngle = 50;
            Triangle.secondAngle = 50;
            Triangle.thirdAngle = 80;
            Triangle.sirstSide = 5;
            Triangle.secondSide = 5;
            Triangle.thirdSide = 8;
            //Act + Assert 
            Assert.AreEqual((int)TriangleTypes.Isosceles, Triangle.DefineType());
        }
        [Test]
        public void DefineTypeTestExpectedRightType()
        {
            //Assign
            Triangle.firstAngle = 90;
            Triangle.secondAngle = 50;
            Triangle.thirdAngle = 40;
            Triangle.sirstSide = 3;
            Triangle.secondSide = 4;
            Triangle.thirdSide = 5;
            //Act + Assert 
            Assert.AreEqual((int)TriangleTypes.Right, Triangle.DefineType());
        }
        [Test]
        public void DefineTypeTestExpectedInvalidType()
        {
            //Assign
            Triangle.firstAngle = 500;
            Triangle.secondAngle = 500;
            Triangle.thirdAngle = 40;
            Triangle.sirstSide = 3;
            Triangle.secondSide = 4;
            Triangle.thirdSide = 5;
            //Act + Assert 
            Assert.AreEqual((int)TriangleTypes.InvalidType, Triangle.DefineType());

            //Assign
            Triangle.firstAngle = 10;
            Triangle.secondAngle = 10;
            Triangle.thirdAngle = 40;
            Triangle.sirstSide = 3;
            Triangle.secondSide = 20;
            Triangle.thirdSide = 5;
            //Act + Assert 
            Assert.AreEqual((int)TriangleTypes.InvalidType, Triangle.DefineType());

            //Assign
            Triangle.firstAngle = 90;
            Triangle.secondAngle = 40;
            Triangle.thirdAngle = 50;
            Triangle.sirstSide = 3;
            Triangle.secondSide = 20;
            Triangle.thirdSide = 5;
            //Act + Assert 
            Assert.AreEqual((int)TriangleTypes.InvalidType, Triangle.DefineType());
        }
        [Test]
        public void AreaTestExpectedResultSix()
        {
            //Assign
            Triangle.firstAngle = 90;
            Triangle.secondAngle = 50;
            Triangle.thirdAngle = 40;
            Triangle.sirstSide = 3;
            Triangle.secondSide = 4;
            Triangle.thirdSide = 5;
            //Act + Assert 
            Assert.AreEqual(6, Triangle.Area());
        }
        [Test]
        public void AreaTestExpectedThrowing()
        {
            //Assign
            Triangle.firstAngle = 900;
            Triangle.secondAngle = 50;
            Triangle.thirdAngle = 40;
            Triangle.sirstSide = 3;
            Triangle.secondSide = 4;
            Triangle.thirdSide = 5;
            //Act + Assert 
            Assert.Throws<Exception>(() => Triangle.Area());
        }
        [Test]
        public void PerimetrTestExpectedResult12()
        {
            //Assign
            Triangle.firstAngle = 90;
            Triangle.secondAngle = 50;
            Triangle.thirdAngle = 40;
            Triangle.sirstSide = 3;
            Triangle.secondSide = 4;
            Triangle.thirdSide = 5;
            //Act + Assert 
            Assert.AreEqual(12, Triangle.Perimeter());
        }
        [Test]
        public void PerimetrTestExpectedThrowing()
        {
            //Assign
            Triangle.firstAngle = 900;
            Triangle.secondAngle = 50;
            Triangle.thirdAngle = 40;
            Triangle.sirstSide = 3;
            Triangle.secondSide = 4;
            Triangle.thirdSide = 5;
            //Act + Assert 
            Assert.Throws<Exception>(() => Triangle.Perimeter());
        }

    }
    public class QuadrilateralTests
    {
        [Test]
        public void DefineTypeTestExpectedFreeQuadrilateralType()
        {
            //Assign
            Quadrilateral.firstSide = 10;
            Quadrilateral.secondSide = 6;
            Quadrilateral.thirdSide = 7;
            Quadrilateral.fourthSide = 4;
            Quadrilateral.firstAngle = 50;
            Quadrilateral.secondAngle = 130;
            Quadrilateral.thirdAngle = 80;
            Quadrilateral.fourthAngle = 100;
            //Act + Assert 
            Assert.AreEqual((int)QuadrilateralTypes.FreeQuadrilateral, Quadrilateral.DefineType());
        }
        [Test]
        public void DefineTypeTestExpectedRectangleType()
        {
            //Assign
            Quadrilateral.firstSide = 5;
            Quadrilateral.secondSide = 5;
            Quadrilateral.thirdSide = 4;
            Quadrilateral.fourthSide = 4;
            Quadrilateral.firstAngle = 90;
            Quadrilateral.secondAngle = 90;
            Quadrilateral.thirdAngle = 90;
            Quadrilateral.fourthAngle = 90;
            //Act + Assert 
            Assert.AreEqual((int)QuadrilateralTypes.Rectangle, Quadrilateral.DefineType());
        }
        [Test]
        public void DefineTypeTestExpectedSquareType()
        {
            //Assign
            Quadrilateral.firstSide = 5;
            Quadrilateral.secondSide = 5;
            Quadrilateral.thirdSide = 5;
            Quadrilateral.fourthSide = 5;
            Quadrilateral.firstAngle = 90;
            Quadrilateral.secondAngle = 90;
            Quadrilateral.thirdAngle = 90;
            Quadrilateral.fourthAngle = 90;
            //Act + Assert 
            Assert.AreEqual((int)QuadrilateralTypes.Square, Quadrilateral.DefineType());
        }
        [Test]
        public void DefineTypeTestExpectedRhombusType()
        {
            //Assign
            Quadrilateral.firstSide = 5;
            Quadrilateral.secondSide = 5;
            Quadrilateral.thirdSide = 5;
            Quadrilateral.fourthSide = 5;
            Quadrilateral.firstAngle = 50;
            Quadrilateral.secondAngle = 50;
            Quadrilateral.thirdAngle = 130;
            Quadrilateral.fourthAngle = 130;
            //Act + Assert 
            Assert.AreEqual((int)QuadrilateralTypes.Rhombus, Quadrilateral.DefineType());
        }
        [Test]
        public void DefineTypeTestExpectedParallelogramType()
        {
            //Assign
            Quadrilateral.firstSide = 5;
            Quadrilateral.secondSide = 5;
            Quadrilateral.thirdSide = 10;
            Quadrilateral.fourthSide = 10;
            Quadrilateral.firstAngle = 50;
            Quadrilateral.secondAngle = 50;
            Quadrilateral.thirdAngle = 130;
            Quadrilateral.fourthAngle = 130;
            //Act + Assert 
            Assert.AreEqual((int)QuadrilateralTypes.Parallelogram, Quadrilateral.DefineType());
        }
        [Test]
        public void DefineTypeTestExpectedTrapezoidType()
        {
            //Assign
            Quadrilateral.firstSide = 5;
            Quadrilateral.secondSide = 15;
            Quadrilateral.thirdSide = 8;
            Quadrilateral.fourthSide = 12;
            Quadrilateral.firstAngle = 50;
            Quadrilateral.secondAngle = 60;
            Quadrilateral.thirdAngle = 130;
            Quadrilateral.fourthAngle = 120;
            //Act + Assert 
            Assert.AreEqual((int)QuadrilateralTypes.Trapezoid, Quadrilateral.DefineType());
        }
        [Test]
        public void DefineTypeTestExpectedTrapezoidRightType()
        {
            //Assign
            Quadrilateral.firstSide = 5;
            Quadrilateral.secondSide = 15;
            Quadrilateral.thirdSide = 8;
            Quadrilateral.fourthSide = 12;
            Quadrilateral.firstAngle = 90;
            Quadrilateral.secondAngle = 90;
            Quadrilateral.thirdAngle = 130;
            Quadrilateral.fourthAngle = 50;
            //Act + Assert 
            Assert.AreEqual((int)QuadrilateralTypes.TrapezoidRight, Quadrilateral.DefineType());
        }
        [Test]
        public void DefineTypeTestExpectedTrapezoidIsoscelesType()
        {
            //Assign
            Quadrilateral.firstSide = 5;
            Quadrilateral.secondSide = 7;
            Quadrilateral.thirdSide = 5;
            Quadrilateral.fourthSide = 8;
            Quadrilateral.firstAngle = 120;
            Quadrilateral.secondAngle = 60;
            Quadrilateral.thirdAngle = 60;
            Quadrilateral.fourthAngle = 120;
            //Act + Assert 
            Assert.AreEqual((int)QuadrilateralTypes.TrapezoidIsosceles, Quadrilateral.DefineType());
        }
        [Test]
        public void DefineTypeTestExpectedInvalidType()
        {
            //Assign
            Quadrilateral.firstSide = 5;
            Quadrilateral.secondSide = 7;
            Quadrilateral.thirdSide = 5;
            Quadrilateral.fourthSide = 8;
            Quadrilateral.firstAngle = 120;
            Quadrilateral.secondAngle = 60;
            Quadrilateral.thirdAngle = 60;
            Quadrilateral.fourthAngle = 500;
            //Act + Assert 
            Assert.AreEqual((int)QuadrilateralTypes.InvalidType, Quadrilateral.DefineType());

            //Assign
            Quadrilateral.firstSide = 5;
            Quadrilateral.secondSide = 7;
            Quadrilateral.thirdSide = 5;
            Quadrilateral.fourthSide = 10;
            Quadrilateral.firstAngle = 120;
            Quadrilateral.secondAngle = 60;
            Quadrilateral.thirdAngle = 60;
            Quadrilateral.fourthAngle = 50;
            //Act + Assert 
            Assert.AreEqual((int)QuadrilateralTypes.InvalidType, Quadrilateral.DefineType());
            //Assign
            Quadrilateral.firstSide = 5;
            Quadrilateral.secondSide = 5;
            Quadrilateral.thirdSide = 20;
            Quadrilateral.fourthSide = 5;
            Quadrilateral.firstAngle = 90;
            Quadrilateral.secondAngle = 90;
            Quadrilateral.thirdAngle = 89;
            Quadrilateral.fourthAngle = 91;
            //Act + Assert 
            Assert.AreEqual((int)QuadrilateralTypes.InvalidType, Quadrilateral.DefineType());
            //Assign
            Quadrilateral.firstSide = 0;
            Quadrilateral.secondSide = 5;
            Quadrilateral.thirdSide = 20;
            Quadrilateral.fourthSide = 5;
            Quadrilateral.firstAngle = 90;
            Quadrilateral.secondAngle = 90;
            Quadrilateral.thirdAngle = 89;
            Quadrilateral.fourthAngle = 91;
            //Act + Assert 
            Assert.AreEqual((int)QuadrilateralTypes.InvalidType, Quadrilateral.DefineType());
        }
        [Test]
        public void AreaTestExpectedResult25()
        {
            //Assign
            Quadrilateral.firstSide = 5;
            Quadrilateral.secondSide = 5;
            Quadrilateral.thirdSide = 5;
            Quadrilateral.fourthSide = 5;
            Quadrilateral.firstAngle = 90;
            Quadrilateral.secondAngle = 90;
            Quadrilateral.thirdAngle = 90;
            Quadrilateral.fourthAngle = 90;
            //Act + Assert 
            Assert.AreEqual(25, Quadrilateral.Area());
        }
        [Test]
        public void AreaTestExpectedResult24()
        {
            //Assign
            Quadrilateral.firstSide = 4;
            Quadrilateral.secondSide = 6;
            Quadrilateral.thirdSide = 4;
            Quadrilateral.fourthSide = 6;
            Quadrilateral.firstAngle = 90;
            Quadrilateral.secondAngle = 90;
            Quadrilateral.thirdAngle = 90;
            Quadrilateral.fourthAngle = 90;
            //Act + Assert 
            Assert.AreEqual(24, Quadrilateral.Area());
        }
        [Test]
        public void AreaTestExpectedResult19()
        {
            //Assign
            Quadrilateral.firstSide = 5;
            Quadrilateral.secondSide = 5;
            Quadrilateral.thirdSide = 5;
            Quadrilateral.fourthSide = 5;
            Quadrilateral.firstAngle = 50;
            Quadrilateral.secondAngle = 50;
            Quadrilateral.thirdAngle = 130;
            Quadrilateral.fourthAngle = 130;
            //Act + Assert 
            Assert.AreEqual(19, (int)Quadrilateral.Area());
        }
        [Test]
        public void AreaTestExpectedResult51()
        {
            //Assign
            Quadrilateral.firstSide = 5;
            Quadrilateral.secondSide = 15;
            Quadrilateral.thirdSide = 8;
            Quadrilateral.fourthSide = 12;
            Quadrilateral.firstAngle = 50;
            Quadrilateral.secondAngle = 60;
            Quadrilateral.thirdAngle = 120;
            Quadrilateral.fourthAngle = 130;
            //Act + Assert 
            Assert.AreEqual(51, (int)Quadrilateral.Area());
        }
        [Test]
        public void AreaTestExpectedThrowing()
        {
            //Assign
            Quadrilateral.firstSide = 0;
            Quadrilateral.secondSide = 5;
            Quadrilateral.thirdSide = 20;
            Quadrilateral.fourthSide = 5;
            Quadrilateral.firstAngle = 90;
            Quadrilateral.secondAngle = 90;
            Quadrilateral.thirdAngle = 89;
            Quadrilateral.fourthAngle = 91;
            //Act + Assert 
            Assert.Throws<Exception>(() => Quadrilateral.Area());
          
        }
        [Test]
        public void PerimetrTestExpected20()
        {
            //Assign
            Quadrilateral.firstSide = 5;
            Quadrilateral.secondSide = 5;
            Quadrilateral.thirdSide = 5;
            Quadrilateral.fourthSide = 5;
            Quadrilateral.firstAngle = 90;
            Quadrilateral.secondAngle = 90;
            Quadrilateral.thirdAngle = 90;
            Quadrilateral.fourthAngle = 90;
            //Act + Assert 
            Assert.AreEqual(20, (int)Quadrilateral.Perimeter());

        }
        [Test]
        public void PerimetrTestExpectedThrowing()
        {
            //Assign
            Quadrilateral.firstSide = 0;
            Quadrilateral.secondSide = 5;
            Quadrilateral.thirdSide = 20;
            Quadrilateral.fourthSide = 5;
            Quadrilateral.firstAngle = 90;
            Quadrilateral.secondAngle = 90;
            Quadrilateral.thirdAngle = 89;
            Quadrilateral.fourthAngle = 91;
            //Act + Assert 
            Assert.Throws<Exception>(() => Quadrilateral.Perimeter());

        }
    }
    public class PentagonTests
    {
        [Test]
        public void AreaTestExpectedResult43()
        {
            //Assign
            Pentagon.side = 5;
            //Act + Assert 
            Assert.AreEqual(43, (int)Pentagon.Area());
        }
        [Test]
        public void AreaTestExpectedThrowing()
        {
            
            
            //Act + Assert 
            Assert.Throws<Exception>(() => Pentagon.Area());

        }
        [Test]
        public void PerimetrTestExpected25()
        {
            //Assign
            Pentagon.side = 5;
            //Act + Assert 
            Assert.AreEqual(25, (int)Pentagon.Perimeter());

        }
        [Test]
        public void PerimetrTestExpectedThrowing()
        {
            
            //Act + Assert 
            Assert.Throws<Exception>(() => Pentagon.Perimeter());

        }

    }
    public class CircleTests
    {
        [Test]
        public void AreaTestExpectedResult78()
        {
            //Assign
            Circle.radius = 5;
            //Act + Assert 
            Assert.AreEqual(78, (int)Circle.Area());
        }
        [Test]
        public void AreaTestExpectedThrowing()
        {


            //Act + Assert 
            Assert.Throws<Exception>(() => Circle.Area());

        }
        [Test]
        public void PerimetrTestExpected31()
        {
            //Assign
            Pentagon.side = 5;
            //Act + Assert 
            Assert.AreEqual(31, (int)Circle.Perimeter());

        }
        [Test]
        public void PerimetrTestExpectedThrowing()
        {

            //Act + Assert 
            Assert.Throws<Exception>(() => Circle.Perimeter());

        }

    }
}
