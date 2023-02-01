using System;
using System.Linq;

namespace OOP_Lab_1
{
    enum TriangleTypes
    {
        InvalidType = -1,
        Scalene = 0,
        Equilateral = 1,
        Isosceles = 2,
        Right = 3,


    }
    static class Triangle
    {


        static public float sirstSide { get; set; } = 0;
        static public float secondSide { get; set; } = 0;
        static public float thirdSide { get; set; } = 0;
        static public float firstAngle { get; set; } = 0;
        static public float secondAngle { get; set; } = 0;
        static public float thirdAngle { get; set; } = 0;
        static public float Perimeter() => DefineType() == (int)TriangleTypes.InvalidType ? 0 : (float)(sirstSide + secondSide + thirdSide);
        static public float Area()
        {

            double halfP = (sirstSide + secondSide + thirdSide) / 2;
            double area = Math.Sqrt(halfP * (halfP - sirstSide) * (halfP - secondSide) * (halfP - thirdSide));
            return DefineType() == -1 ? 0 : (float)area;
        }

        static public int DefineType()
        {
            double[] sides = new double[3] { sirstSide, secondSide, thirdSide };
            double[] angles = new double[3] { firstAngle, thirdAngle, secondAngle };
            if (angles.Sum() != 180)
                return (int)TriangleTypes.InvalidType;


            bool check = Array.Exists(sides, x => x == 0);
            if (check) return (int)TriangleTypes.InvalidType;

            double maxSide = sides.Max();
            double[] legs = sides.Where(x => x != maxSide).ToArray();
            angles = angles.Distinct().ToArray();
            sides = sides.Distinct().ToArray();

            switch (sides.Length)
            {
                case (int)TriangleTypes.Equilateral:
                    return (int)TriangleTypes.Equilateral;
                case (int)TriangleTypes.Isosceles:
                    if (angles.Length == 2) return (int)TriangleTypes.Isosceles;
                    else return (int)TriangleTypes.InvalidType;
                default:
                    break;
            }

            check = Array.Exists(angles, x => x == 90);
            if (check)
            {
                if (Math.Pow(legs[0], 2) + Math.Pow(legs[1], 2) == Math.Pow(maxSide, 2))
                {
                    return (int)TriangleTypes.Right;
                }
                else return (int)TriangleTypes.InvalidType;


            }


            return (int)TriangleTypes.Scalene;
        }

    }



    enum QuadrilateralTypes
    {
        InvalidType = -1,
        FreeQuadrilateral,
        Rectangle,
        Square,
        Rhombus,
        Parallelogram,
        Trapezoid,
        TrapezoidRight,
        TrapezoidIsosceles

    }

    static class Quadrilateral
    {
        static public float firstSide { get; set; } = 0;
        static public float secondSide { get; set; } = 0;
        static public float thirdSide { get; set; } = 0;
        static public float fourthSide { get; set; } = 0;
        static public float firstAngle { get; set; } = 0;
        static public float secondAngle { get; set; } = 0;
        static public float thirdAngle { get; set; } = 0;
        static public float fourthAngle { get; set; } = 0;
        static public float Perimeter() => DefineType() == (int)QuadrilateralTypes.InvalidType ? 0 : (float)(firstSide + secondSide + thirdSide + fourthSide);
        static public int DefineType()
        {
            double[] sides = new double[4] { firstSide, secondSide, thirdSide, fourthSide };
            double[] angles = new double[4] { firstAngle, thirdAngle, secondAngle, fourthAngle };
            if (angles.Sum() != 360 || angles.Max() >= 180)
                return (int)QuadrilateralTypes.InvalidType;
            if (sides.Max() > (sides.Sum() - sides.Max())) return (int)QuadrilateralTypes.InvalidType;

            bool nullCheck = Array.Exists(sides, x => x == 0);
            if (nullCheck) return (int)QuadrilateralTypes.InvalidType;

            var duplicates = sides.GroupBy(x => x).Where(g => g.Count() == 3).Select(y => y.Key).ToArray();
            angles = angles.Distinct().ToArray();
            sides = sides.Distinct().ToArray();

            if (angles.Length == 1)
                if (sides.Length > 2 || duplicates.Length == 1) return (int)QuadrilateralTypes.InvalidType;
            double firstDiagonal, secondDiagonal;
            switch (sides.Length)
            {
                case 1:
                    if (angles.Length == 1)
                        if (angles[0] == 90)
                            return (int)QuadrilateralTypes.Square;
                    if (angles.Length == 2)
                    {
                        if (firstAngle != thirdAngle) return (int)QuadrilateralTypes.InvalidType;
                        double alphaAngle = angles[0] < angles[1] ? angles[0] : angles[1];//alpha is acute 

                        firstDiagonal = 2 * sides[0] * Math.Cos(Math.PI / 180 * (alphaAngle / 2));
                        secondDiagonal = 2 * sides[0] * Math.Sin(Math.PI / 180 * (alphaAngle / 2));
                        if (4 * Math.Pow(sides[0], 2) == Math.Pow(firstDiagonal, 2) + Math.Pow(secondDiagonal, 2))
                            return (int)QuadrilateralTypes.Rhombus;

                    }
                    break;
                case 2:
                    if (angles.Length == 1)
                        if (angles[0] == 90)
                            return (int)QuadrilateralTypes.Rectangle;
                    if (angles.Length == 2)
                    {
                        if (firstAngle != thirdAngle || firstSide != secondSide || thirdSide != fourthSide) return (int)QuadrilateralTypes.InvalidType;
                        return (int)QuadrilateralTypes.Parallelogram;
                    }
                    break;
                default:
                    double biggestBase = firstSide > secondSide ? firstSide : secondSide;
                    double smallestBase = biggestBase == firstSide ? secondSide : firstSide;
                    firstDiagonal = Math.Sqrt(smallestBase * biggestBase + fourthSide * fourthSide + (biggestBase * (thirdSide * thirdSide - fourthSide * fourthSide)) / (biggestBase - smallestBase));
                    secondDiagonal = Math.Sqrt(smallestBase * biggestBase + thirdSide * thirdSide - (biggestBase * (thirdSide * thirdSide - fourthSide * fourthSide)) / (biggestBase - smallestBase));
                    if (angles.Length == 2)
                        if (sides.Length != 3)
                            return (int)QuadrilateralTypes.InvalidType;
                    if (firstDiagonal * firstDiagonal + secondDiagonal * secondDiagonal == 2 * firstSide * secondSide + thirdSide * thirdSide + fourthSide * fourthSide)
                    {
                        if (angles.Length == 2)
                            if (sides.Length == 3)
                                return (int)QuadrilateralTypes.TrapezoidIsosceles;
                        if (angles.Length == 3)
                            if (angles.Contains(90))
                                return (int)QuadrilateralTypes.TrapezoidRight;

                        return (int)QuadrilateralTypes.Trapezoid;


                    }

                    break;
            }
            return (int)QuadrilateralTypes.FreeQuadrilateral;
        }
        static public float Area()
        {
            double[] sides = new double[4] { firstSide, secondSide, thirdSide, fourthSide };
            double[] angles = new double[4] { firstAngle, thirdAngle, secondAngle, fourthAngle };
            angles = angles.Distinct().ToArray();
            sides = sides.Distinct().ToArray();
            double firstDiagonal, secondDiagonal;
            switch (DefineType())
            {
                case (int)QuadrilateralTypes.Rectangle:
                    return (float)(sides[0] * sides[1]);
                case (int)QuadrilateralTypes.Square:
                    return (float)(sides[0] * sides[0]);
                case (int)QuadrilateralTypes.Rhombus:
                    double alphaAngle = angles[0] < angles[1] ? angles[0] : angles[1];//alpha is acute 
                    firstDiagonal = 2 * sides[0] * Math.Cos(Math.PI / 180 * (alphaAngle / 2));
                    secondDiagonal = 2 * sides[0] * Math.Sin(Math.PI / 180 * (alphaAngle / 2));
                    return (float)((firstDiagonal * secondDiagonal) / 2);
                case (int)QuadrilateralTypes.Parallelogram:
                    return (float)(secondSide * thirdSide * Math.Sin(Math.PI / 180 * firstAngle));
                case (int)QuadrilateralTypes.Trapezoid:
                case (int)QuadrilateralTypes.TrapezoidRight:
                case (int)QuadrilateralTypes.TrapezoidIsosceles:
                    double height = Math.Sqrt(thirdSide * thirdSide - (1 / 4) * Math.Pow((((thirdSide * thirdSide - fourthSide * fourthSide) / (secondSide - firstSide)) + secondSide - firstSide), 2));
                    return (float)(((firstSide + secondSide) / 2) * height);
                case (int)QuadrilateralTypes.FreeQuadrilateral:
                    //Quadrilateral area 
                    //p - HalfPerimeter,  delta - (∠Any + ∠TheOtherAny)/2
                    double p = (firstSide + secondSide + thirdSide + fourthSide) / 2;
                    double delta = (firstAngle + thirdAngle) / 2;
                    double S = Math.Sqrt((p - firstSide) * (p - secondSide) * (p - thirdSide) * (p - fourthSide) - firstSide * secondSide * thirdSide * fourthSide * Math.Pow(Math.Cos(Math.PI / 180 * delta), 2));
                    return (float)S;
                default:
                    break;
            }
            return 0;
        }
    }


    static class Pentagon
    {
        static public float side { get; set; } = 0;
        static public float Perimeter() => (float)(5 * side);
        static public float Area() => (float)((5 * Math.Pow(side, 2)) / (4 * Math.Tan(Math.PI / 180 * 36)));

    }
    static class Circle
    {
        static public float Radius { get; set; } = 0;
        static public float Perimeter() => (float)(Math.PI * 2 * Radius);
        static public float Area() => (float)(Math.PI * Math.Pow(Radius, 2));
    }
}
