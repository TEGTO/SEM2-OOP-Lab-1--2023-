using System;
using System.Linq;

namespace OOP_Lab_1
{
    public enum TriangleTypes
    {
        InvalidType = -1,
        Scalene = 0,
        Equilateral = 1,
        Isosceles = 2,
        Right = 3,


    }
    public static class Triangle
    {


        static public float sirstSide { get; set; } = 0;
        static public float secondSide { get; set; } = 0;
        static public float thirdSide { get; set; } = 0;
        static public float firstAngle { get; set; } = 0;
        static public float secondAngle { get; set; } = 0;
        static public float thirdAngle { get; set; } = 0;
        static public float Perimeter()
        {
            if (DefineType() == (int)TriangleTypes.InvalidType)
            {
                throw new Exception();
            }
            return (float)(sirstSide + secondSide + thirdSide);
        }
        static public float Area()
        {

            double halfP = (sirstSide + secondSide + thirdSide) / 2;
            double area = Math.Sqrt(halfP * (halfP - sirstSide) * (halfP - secondSide) * (halfP - thirdSide));
            if (DefineType() == (int)TriangleTypes.InvalidType)
            {
                throw new Exception();
            }
            return (float)area;
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



    public enum QuadrilateralTypes
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

    public static class Quadrilateral
    {
        static public float firstSide { get; set; } = 0;
        static public float secondSide { get; set; } = 0;
        static public float thirdSide { get; set; } = 0;
        static public float fourthSide { get; set; } = 0;
        static public float firstAngle { get; set; } = 0;
        static public float secondAngle { get; set; } = 0;
        static public float thirdAngle { get; set; } = 0;
        static public float fourthAngle { get; set; } = 0;
        static public float Perimeter()
        {

            if (DefineType() == (int)QuadrilateralTypes.InvalidType)
            {
                throw new Exception();
            }
            return (float)(firstSide + secondSide + thirdSide + fourthSide);

        }
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

                        double alphaAngle = angles[0] < angles[1] ? angles[0] : angles[1];//alpha is acute 

                        firstDiagonal = sides[0] * Math.Sqrt(2 + 2 * Math.Cos(Math.PI / 180 * alphaAngle));
                        secondDiagonal = sides[0] * Math.Sqrt(2 - 2 * Math.Cos(Math.PI / 180 * alphaAngle));
                        float buffer = (float)(Math.Pow(firstDiagonal, 2) + Math.Pow(secondDiagonal, 2));
                        if (4 * Math.Pow(sides[0], 2) == buffer)
                            return (int)QuadrilateralTypes.Rhombus;

                    }
                    break;
                case 2:
                    if (angles.Length == 1)
                        if (angles[0] == 90)
                            return (int)QuadrilateralTypes.Rectangle;
                    if (angles.Length == 2)
                    {

                        firstDiagonal = Math.Sqrt(sides[0] * sides[0] + sides[1] * sides[1] + 2 * sides[0] * sides[1] * Math.Cos(Math.PI / 180 * angles[0]));
                        secondDiagonal = Math.Sqrt(sides[0] * sides[0] + sides[1] * sides[1] - 2 * sides[0] * sides[1] * Math.Cos(Math.PI / 180 * angles[0]));
                        float buffer = (float)(Math.Pow(firstDiagonal, 2) + Math.Pow(secondDiagonal, 2));
                        if (buffer == 2 * (sides[0] * sides[0] + sides[1] * sides[1]))
                        {
                            return (int)QuadrilateralTypes.Parallelogram;
                        }

                    }
                    break;
                default:
                    double biggestBase = fourthSide > secondSide ? fourthSide : secondSide;
                    double smallestBase = biggestBase == fourthSide ? secondSide : fourthSide;
                    firstDiagonal = (float)Math.Sqrt(firstSide * firstSide + biggestBase * smallestBase - (biggestBase * (firstSide * firstSide - thirdSide * thirdSide)) / (biggestBase - smallestBase));
                    secondDiagonal = (float)Math.Sqrt(thirdSide * thirdSide + biggestBase * smallestBase - (biggestBase * (thirdSide * thirdSide - firstSide * firstSide)) / (biggestBase - smallestBase));
                    if (angles.Length == 2)
                        if (sides.Length != 3)
                            return (int)QuadrilateralTypes.InvalidType;
                    if (firstDiagonal * firstDiagonal + secondDiagonal * secondDiagonal == 2 * fourthSide * secondSide + thirdSide * thirdSide + firstSide * firstSide)
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
            double firstDiagonal, secondDiagonal, S;
            switch (DefineType())
            {
                case (int)QuadrilateralTypes.Rectangle:
                    S = (sides[0] * sides[1]);
                    return (float)S;
                case (int)QuadrilateralTypes.Square:
                    S = (sides[0] * sides[0]);
                    return (float)S;
                case (int)QuadrilateralTypes.Rhombus:
                    double alphaAngle = angles[0] < angles[1] ? angles[0] : angles[1];//alpha is acute 

                    firstDiagonal = sides[0] * Math.Sqrt(2 + 2 * Math.Cos(Math.PI / 180 * alphaAngle));
                    secondDiagonal = sides[0] * Math.Sqrt(2 - 2 * Math.Cos(Math.PI / 180 * alphaAngle));
                    S = ((firstDiagonal * secondDiagonal) / 2);
                    return (float)S;
                case (int)QuadrilateralTypes.Parallelogram:
                    S=(sides[0] * sides[1] * Math.Sin(Math.PI / 180 * angles[0]));
                    return (float)S;
                case (int)QuadrilateralTypes.Trapezoid:
                case (int)QuadrilateralTypes.TrapezoidRight:
                case (int)QuadrilateralTypes.TrapezoidIsosceles:
                    double biggestBase = fourthSide > secondSide ? fourthSide : secondSide;
                    double smallestBase = biggestBase == fourthSide ? secondSide : fourthSide;
                    double h = firstSide * Math.Sin(Math.PI / 180 * firstAngle);
                    S = ((biggestBase + smallestBase) /2)* h;
                    return (float)S;
                case (int)QuadrilateralTypes.FreeQuadrilateral:
                    //Quadrilateral area 
                    //p - HalfPerimeter,  delta - (∠Any + ∠TheOtherAny)/2
                    double p = (firstSide + secondSide + thirdSide + fourthSide) / 2;
                    double delta = (firstAngle + thirdAngle) / 2;
                     S = Math.Sqrt((p - firstSide) * (p - secondSide) * (p - thirdSide) * (p - fourthSide) - firstSide * secondSide * thirdSide * fourthSide * Math.Pow(Math.Cos(Math.PI / 180 * delta), 2));
                    return (float)S;
                case (int)QuadrilateralTypes.InvalidType:
                    throw new Exception(); 
                default:
                    break;
            }
            return 0;
        }
    }


    public static class Pentagon
    {
        static public float side { get; set; }
        static public float Perimeter()
        {
            if (side==0|| side == float.NaN) 
               throw new Exception();
          
            return (float)(5 * side);
        }
        static public float Area()
        {
            if (side == 0 ||side ==float.NaN)
                throw new Exception();
           
            return  (float)((5 * Math.Pow(side, 2)) / (4 * Math.Tan(Math.PI / 180 * 36)));
        }
        

    }
   public static class Circle
    {
        static public float radius { get; set; }
        static public float Perimeter()
        {
            if (radius == 0 || radius == float.NaN)
                throw new Exception();
            return (float)(Math.PI * 2 * radius); 
        }

        static public float Area()
        {
            if (radius == 0 || radius == float.NaN)
                throw new Exception();
            return (float)(Math.PI * Math.Pow(radius, 2));
        }
    }
}
