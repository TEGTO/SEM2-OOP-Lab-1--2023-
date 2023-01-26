using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

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


        static public double FirstSide {get; set;} = 0;
        static public double SecondSide {get; set;} = 0;
        static public double ThirdSide  {get; set;} = 0;
        static public double FirstAngle {get ;set;}  = 0;
        static public double SecondAngle {get; set;} = 0;
        static public double ThirdAngle {get; set;} = 0;
        static public float Perimeter() => DefineType()==(int)TriangleTypes.InvalidType?0:(float)(FirstSide + SecondSide + ThirdSide);
        static public float Area()
        {

            double halfP = (FirstSide + SecondSide + ThirdSide) / 2;
            double area = Math.Sqrt(halfP * (halfP - FirstSide) * (halfP - SecondSide) * (halfP - ThirdSide));
            return DefineType() == -1 ? 0: (float)area;
        }

        static public int DefineType()
        {
            double[] sides = new double[3] { FirstSide, SecondSide, ThirdSide };
            double[] angles = new double[3] { FirstAngle, ThirdAngle, SecondAngle };
            if (angles.Sum()!=180)         
                return (int)TriangleTypes.InvalidType;

         
            bool check = Array.Exists(sides, x => x == 0);
            if (check) return (int)TriangleTypes.InvalidType;

            double maxSide = sides.Max();
            double [] legs = sides.Where(x => x != maxSide).ToArray();
            angles = angles.Distinct().ToArray();
            sides = sides.Distinct().ToArray();

            switch (sides.Length)
            {
                case (int)TriangleTypes.Equilateral:
                    return (int)TriangleTypes.Equilateral;
                case (int)TriangleTypes.Isosceles:
                    if (angles.Length == 2) return (int)TriangleTypes.Isosceles;
                    else return(int)TriangleTypes.InvalidType;        
                default:
                    break;
            }     
            
            check = Array.Exists(angles, x => x == 90);
            if (check)
            {
                if (Math.Pow(legs[0],2) + Math.Pow(legs[1], 2) == Math.Pow(maxSide, 2))
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
        Rectangle ,
        Square,
        Rhombus,
        Parallelogram,
        Trapezoid,
        TrapezoidRight,
        TrapezoidIsosceles

    }

    static class Quadrilateral
    {
        static public double A { get; set; } = 0;
        static public double B { get; set; } = 0;
        static public double C { get; set; } = 0;
        static public double D { get; set; } = 0;
        static public double AngleBetweenCB { get; set; } = 0;
        static public double AngleBetweenBD { get; set; } = 0;
        static public double AngleBetweenDA { get; set; } = 0;
        static public double AngleBetweenAC { get; set; } = 0;
        static public float Perimeter() => DefineType() == (int)QuadrilateralTypes.InvalidType?0:(float)(A+B+C+D);
        static public int DefineType()
        {
            double[] sides = new double[4] { A, B, C, D };
            double[] angles = new double[4] { AngleBetweenCB, AngleBetweenDA, AngleBetweenBD, AngleBetweenAC };
            if (angles.Sum() != 360|| angles.Max()>=180)      
                return (int)QuadrilateralTypes.InvalidType;
            if (sides.Max() > (sides.Sum() - sides.Max())) return (int)QuadrilateralTypes.InvalidType;

            bool nullCheck = Array.Exists(sides, x => x == 0);
            if(nullCheck) return (int)QuadrilateralTypes.InvalidType;

            var duplicates = sides.GroupBy(x => x).Where(g => g.Count() == 3).Select(y => y.Key).ToArray();
            angles = angles.Distinct().ToArray();
            sides = sides.Distinct().ToArray();

            if (angles.Length == 1)    
                if (sides.Length > 2||duplicates.Length==1) return (int)QuadrilateralTypes.InvalidType;
            double d1, d2;
            switch (sides.Length)
            {
                case 1:
                    if (angles.Length == 1)
                        if (angles[0] == 90)
                            return (int)QuadrilateralTypes.Square;
                    if (angles.Length == 2)
                    {
                        if (AngleBetweenCB != AngleBetweenDA) return (int)QuadrilateralTypes.InvalidType;
                        double alphaAngle = angles[0] < angles[1] ? angles[0] : angles[1];//alpha is acute 
                        
                       d1 = 2 * sides[0] * Math.Cos(Math.PI/180*(alphaAngle / 2));
                       d2 = 2 * sides[0] * Math.Sin(Math.PI / 180 * (alphaAngle / 2));
                        if (4*Math.Pow(sides[0],2) ==Math.Pow(d1,2)+Math.Pow(d2,2) )
                            return (int)QuadrilateralTypes.Rhombus;
                       
                    }
                    break;
                case 2:
                    if (angles.Length == 1)
                        if (angles[0] == 90)
                            return (int)QuadrilateralTypes.Rectangle;
                    if(angles.Length == 2)
                    {
                        if (AngleBetweenCB != AngleBetweenDA||A!=B||C!=D)return (int)QuadrilateralTypes.InvalidType;
                        return (int)QuadrilateralTypes.Parallelogram;
                    }
                    break;                              
                default:
                    double BiggestBase = A > B ? A : B;
                    double SmallestBase = BiggestBase == A ? B : A;
                    d1 = Math.Sqrt(SmallestBase * BiggestBase + D * D + (BiggestBase * (C * C - D * D)) / (BiggestBase - SmallestBase));
                    d2 = Math.Sqrt(SmallestBase * BiggestBase + C * C - (BiggestBase * (C * C - D * D)) / (BiggestBase - SmallestBase));
                    if (angles.Length==2)
                     if (sides.Length!=3)
                           return (int)QuadrilateralTypes.InvalidType;
                    if (d1 * d1 + d2 * d2 == 2 * A * B + C * C + D * D)
                    {
                        if (angles.Length == 2) 
                            if (sides.Length == 3)
                                return (int)QuadrilateralTypes.TrapezoidIsosceles;
                        if (angles.Length==3)
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
            double[] sides = new double[4] { A, B, C, D };
            double[] angles = new double[4] { AngleBetweenCB, AngleBetweenDA, AngleBetweenBD, AngleBetweenAC };
            angles = angles.Distinct().ToArray();
            sides = sides.Distinct().ToArray();
            double d1, d2;
            switch (DefineType())
            {
                case (int)QuadrilateralTypes.Rectangle:
                    return (float)(sides[0] * sides[1]);
                case (int)QuadrilateralTypes.Square:
                    return (float)(sides[0] * sides[0]);
                case (int)QuadrilateralTypes.Rhombus:
                    double alphaAngle = angles[0] < angles[1] ? angles[0] : angles[1];//alpha is acute 
                    d1 = 2 * sides[0] * Math.Cos(Math.PI / 180 * (alphaAngle / 2));
                    d2 = 2 * sides[0] * Math.Sin(Math.PI / 180 * (alphaAngle / 2));
                    return (float)((d1 * d2) / 2);
                case (int)QuadrilateralTypes.Parallelogram:
                    return (float)(B * C * Math.Sin(Math.PI/180*AngleBetweenCB));
                case (int)QuadrilateralTypes.Trapezoid: case (int)QuadrilateralTypes.TrapezoidRight: case (int) QuadrilateralTypes.TrapezoidIsosceles:
                    double h = Math.Sqrt(C * C - (1 / 4) * Math.Pow((((C * C - D * D) / (B - A)) + B - A), 2));
                    return (float)(((A + B) / 2) * h);
                case (int)QuadrilateralTypes.FreeQuadrilateral:
                    //Quadrilateral area 
                    //p - HalfPerimeter,  delta - (∠Any + ∠TheOtherAny)/2
                    double p = (A + B + C + D) / 2;
                    double delta = (AngleBetweenCB + AngleBetweenDA) / 2;
                    double S = Math.Sqrt((p - A) * (p - B) * (p - C) * (p - D) - A * B * C * D * Math.Pow(Math.Cos(Math.PI/180*delta), 2));
                    return (float)S;   
                default:
                    break;
            }
            return 0;
        }
    }


    static class Pentagon
    {
        static public double Side { get; set; } = 0;
        static public float Perimeter() =>(float) (5 * Side);
        static public float Area() => (float) ((5 * Math.Pow(Side, 2) )/ (4 * Math.Tan(Math.PI / 180 * 36)));
        
    }
    static class Circle
    {
        static public double Radius { get; set; } = 0;
        static public float Perimeter() => (float)(Math.PI*2 * Radius);
        static public float Area() =>(float)(Math.PI * Math.Pow(Radius,2));
    }
}
