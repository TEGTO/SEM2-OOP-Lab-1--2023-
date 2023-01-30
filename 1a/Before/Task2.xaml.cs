using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;



namespace OOP_Lab_1
{
    /// <summary>
    /// Interaction logic for task2.xaml
    /// </summary>

    enum CheckBoxTypes
    {
        Triangle = 1, Quadrilateral,Pentagon,Circle
    }
    public partial class Task2 : Window
    {

      
        int checkBoxType = 0;
        public Task2()
        {
            InitializeComponent();    
        }
        void ClearTextBoxes()
        {
            FirstAngle_Triangle.Text = "";
            SecondAngle_Triangle.Text = "";
            ThirdAngle_Triangle.Text = "";
            CBAngle_Rectangle.Text = "";
            ACAngle_Rectangle.Text = "";
            DAAngle_Rectangle.Text = "";
            BDAngle_Rectangle.Text = "";
            Side_Pentagon.Text = "";
            Radius_Circle.Text = "";
        }

        private void UncheckMainMethod()
        {
            ClearTextBoxes();
            MainFigureCanvas.Visibility = Visibility.Hidden;
           
            if ((int)CheckBoxTypes.Triangle != checkBoxType)
            {
                TriangleCheckBox.IsChecked = false;
               
            }
            else
            {        
                TriangleCanvas.IsEnabled = true;
                TriangleCanvas.Visibility = Visibility.Visible;
            }
            if ((int)CheckBoxTypes.Quadrilateral != checkBoxType)
            {
                RectangleCheckBox.IsChecked = false;

            }
            else
            {        
                RectangleCanvas.IsEnabled = true;
                RectangleCanvas.Visibility = Visibility.Visible;
            }
            if ((int)CheckBoxTypes.Pentagon != checkBoxType)
            {
                PentagonCheckBox.IsChecked = false;
            }
            else
            {
               PentagonCanvas.IsEnabled = true;
                PentagonCanvas.Visibility = Visibility.Visible;
            }
            if ((int)CheckBoxTypes.Circle != checkBoxType)
            {
                СircleCheckBox.IsChecked = false;
            }
            else
            {
                СircleCanvas.IsEnabled = true;
                СircleCanvas.Visibility = Visibility.Visible;
            }

        }
        private void TriangleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
           
           checkBoxType = (int)CheckBoxTypes.Triangle;
            UncheckMainMethod();
          



        }
        private void TriangleCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            TriangleCanvas.IsEnabled = false;
            TriangleCanvas.Visibility = Visibility.Hidden;
        }
        private void RectangleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
            checkBoxType = (int)CheckBoxTypes.Quadrilateral;
            UncheckMainMethod();
          


        }
        private void RectangleCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RectangleCanvas.IsEnabled = false;
            RectangleCanvas.Visibility = Visibility.Hidden;
            MainRectangle.Visibility = Visibility.Hidden;
         
        }

        private void PentagonCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxType = (int)CheckBoxTypes.Pentagon;
            UncheckMainMethod();
         
        }
        private void PentagonCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PentagonCanvas.IsEnabled = false;
            PentagonCanvas.Visibility = Visibility.Hidden;


        }
        private void СircleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxType = (int)CheckBoxTypes.Circle;
            UncheckMainMethod();

        }

        private void СircleCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            СircleCanvas.IsEnabled = false;
            СircleCanvas.Visibility = Visibility.Hidden;
            MainCircle.Visibility = Visibility.Hidden;

        }
        private void FigureTypePrint(int FigureType)
        {
            switch (checkBoxType)
            {
                case (int)CheckBoxTypes.Triangle:
                    switch (FigureType)
                    {
                        case (int)TriangleTypes.Scalene: AnglesIndefined("Scalene Triangle"); break;
                        case (int)TriangleTypes.Equilateral: labelType.Content = "TYPE = Equilateral Triangle"; break;
                        case (int)TriangleTypes.Isosceles: labelType.Content = "TYPE = Isosceles Triangle"; break;
                        case (int)TriangleTypes.Right: labelType.Content = "TYPE = Right Triangle"; break;
                        default:
                            labelType.Content = "TYPE = Invalid Triangle";
                            break;
                    }
                    break;
                case (int)CheckBoxTypes.Quadrilateral:
                    switch (FigureType)
                    {
                        case (int)QuadrilateralTypes.FreeQuadrilateral: AnglesIndefined("Free Quadrilateral"); break;
                        case (int)QuadrilateralTypes.Rectangle: labelType.Content = "TYPE = Rectangle"; break;
                        case (int)QuadrilateralTypes.Trapezoid: labelType.Content = "TYPE = Trapezoid"; break;
                        case (int)QuadrilateralTypes.TrapezoidRight:labelType.Content = "TYPE = Right Trapezoid";break;
                        case (int)QuadrilateralTypes.TrapezoidIsosceles: labelType.Content="TYPE = Isosceles Trapezoid"; break;
                        case (int)QuadrilateralTypes.Rhombus: labelType.Content = "TYPE = Rhombus"; break;
                        case (int)QuadrilateralTypes.Square: labelType.Content = "TYPE = Square"; break;
                        case (int)QuadrilateralTypes.Parallelogram: labelType.Content = "TYPE = Parallelogram"; break;
                        default:
                            labelType.Content = "TYPE = Invalid Quadrilateral";
                            break;
                    }
                    break;
                default:
                    break;
            }
          
        }
        private void DrawFigure(int FigureType)
        {
            MainFigure.Fill = Brushes.Red;
            Quadrilateral.A = Quadrilateral.A > 20 ? 20 : Quadrilateral.A;
            Quadrilateral.B = Quadrilateral.B > 20 ? 20 : Quadrilateral.B;
            Quadrilateral.C = Quadrilateral.C > 20 ? 20 : Quadrilateral.C;
            Quadrilateral.D = Quadrilateral.D > 20 ? 20 : Quadrilateral.D;
            Triangle.FirstSide = Triangle.FirstSide > 20 ? 20 : Triangle.FirstSide;
            Triangle.SecondSide = Triangle.SecondSide > 20 ? 20 : Triangle.SecondSide;
            Triangle.ThirdSide = Triangle.ThirdSide > 20 ? 20 : Triangle.ThirdSide;
            MainFigure.Points = new PointCollection() { new Point(0, 0), new Point(0, 0), new Point(0, 0) };
            switch (checkBoxType)
            {
                case (int)CheckBoxTypes.Triangle:
                    switch (FigureType)
                    {
                        case (int)TriangleTypes.Scalene:
                            MainFigure.Points = new PointCollection() { new Point(0, 200), new Point(200, 200), new Point(50, 50) };
                           
                            break;
                        case (int)TriangleTypes.Equilateral:
                            MainFigure.Points = new PointCollection() { new Point(0  -(Triangle.FirstSide * 3), 250 + (Triangle.FirstSide * 3)), 
                                new Point(200 + (Triangle.FirstSide * 3), 250 + (Triangle.FirstSide * 3)), new Point(100, 50-(Triangle.FirstSide * 3)) };
                            MainFigure.Fill = Brushes.Blue;
                            break;

                        case (int)TriangleTypes.Isosceles:
                            MainFigure.Points = new PointCollection() { new Point(50 - (Triangle.FirstSide * 3), 250 + (Triangle.SecondSide * 3)), new Point(150 + (Triangle.FirstSide * 3), 250 + (Triangle.SecondSide * 3)), new Point(100, 100 - (Triangle.SecondSide * 3)) };
                            MainFigure.Fill = Brushes.Blue;
                            break;
                        case (int)TriangleTypes.Right:
                            MainFigure.Points = new PointCollection() { new Point(0, 250), new Point(0, 50), new Point(200, 250) };
                            break;
                        default:
                            MainFigure.Points = new PointCollection() { new Point(0, 0), new Point(0, 0), new Point(0, 0) };
                            break;
                    }
                  

                    break;
                case (int)CheckBoxTypes.Quadrilateral:
                    switch (FigureType)
                    {
                        case (int)QuadrilateralTypes.FreeQuadrilateral:
                            MainFigure.Points = new PointCollection() { new Point(80, 200), new Point(280, 210), new Point(240, 100), new Point(100, 50) };
                            break;
                        case (int)QuadrilateralTypes.Rectangle:
                            MainRectangle.Width = Quadrilateral.B * 10 <= 200 ? Quadrilateral.B * 10 : 200;
                            MainRectangle.Height = Quadrilateral.A != Quadrilateral.B? Quadrilateral.A*10<200 ? Quadrilateral.A * 10 :200 :
                                Quadrilateral.C * 10 < 200 ? Quadrilateral.C * 10 : 200;
                            MainRectangle.Visibility = Visibility.Visible;
                            break;
                        case (int)QuadrilateralTypes.Trapezoid:
                            MainFigure.Points = new PointCollection() { new Point(60 - (Quadrilateral.B * 3), 250 + (Quadrilateral.C * 3)), new Point(280 + (Quadrilateral.B * 3), 250 + (Quadrilateral.D * 3)), new Point(240 + (Quadrilateral.A * 3), 50 - (Quadrilateral.D * 3)), new Point(120 - (Quadrilateral.A * 3), 50 - (Quadrilateral.C * 3)) };
                            MainFigure.Fill = Brushes.Blue;
                            break;
                       case (int)QuadrilateralTypes.TrapezoidRight:
                            MainFigure.Points = new PointCollection() { new Point(80, 250 + (Quadrilateral.C * 3)),
                                new Point(280 + (Quadrilateral.B * 3), 250 + (Quadrilateral.D * 3)), new Point(150 + (Quadrilateral.A * 3), 50 -(Quadrilateral.D * 3)), new Point(80 , 50-(Quadrilateral.C * 3)) };
                            MainFigure.Fill = Brushes.Blue;
                            break;
                        case (int)QuadrilateralTypes.TrapezoidIsosceles:
                          
                            MainFigure.Points = new PointCollection() { new Point(80 - (Quadrilateral.B * 3), 250 + (Quadrilateral.C * 3)),
                                new Point(290 + (Quadrilateral.B * 3), 250 + (Quadrilateral.C * 3)), new Point(240+(Quadrilateral.A * 3), 50 - (Quadrilateral.C * 3)), 
                                new Point(120 - (Quadrilateral.A * 3), 50 - (Quadrilateral.C * 3)) };

                            MainFigure.Fill = Brushes.Blue;
                            break;
                        case (int)QuadrilateralTypes.Rhombus:
                     
                            MainFigure.Points = new PointCollection() { new Point(80 - (Quadrilateral.A * 3), 200), new Point(180, 300+ (Quadrilateral.A*3)), new Point(280 + (Quadrilateral.A * 3), 200), new Point(180, 100 - (Quadrilateral.A * 3)) };
                            MainFigure.Fill =Brushes.Blue;
                            break;
                        case (int)QuadrilateralTypes.Square:
                            MainRectangle.Height = MainRectangle.Width = Quadrilateral.B*10<=200? Quadrilateral.B * 10:200;   
                            MainRectangle.Visibility = Visibility.Visible;
                            break;
                        case (int)QuadrilateralTypes.Parallelogram:
                         
                            MainFigure.Points = new PointCollection() { new Point(80-( Quadrilateral.A*3), 250+( Quadrilateral.C*3)), new Point(280+ (Quadrilateral.A * 3), 250 + (Quadrilateral.C * 3)), new Point(340 + (Quadrilateral.A * 3), 50 - (Quadrilateral.C * 3)), new Point(140 - (Quadrilateral.A * 3), 50 - (Quadrilateral.C * 3)) };
                            MainFigure.Fill = Brushes.Blue;
                            break;
                        default:
                            MainFigure.Points = new PointCollection() { new Point(0, 0), new Point(0, 0), new Point(0, 0) };
                            break;
                    }
               

                    break;
                case (int)CheckBoxTypes.Pentagon:
                    if (Pentagon.Side!=0)
                    {
                        MainFigure.Points = new PointCollection() { new Point(10-(Pentagon.Side*3), 150), new Point(80-(Pentagon.Side*3), 265+(Pentagon.Side*3)), new Point(220+(Pentagon.Side*3), 265+(Pentagon.Side*3)), new Point(290+(Pentagon.Side*3), 150),
                        new Point(220+(Pentagon.Side*3), 35-(Pentagon.Side*3)),new Point(80-(Pentagon.Side*3), 35-(Pentagon.Side*3)) };
                        MainFigure.Fill = Brushes.Blue;
                    }
                    else
                       MainFigure.Points = new PointCollection() { new Point(0, 0), new Point(0, 0), new Point(0, 0) };
                    
                    break;
                case (int)CheckBoxTypes.Circle:
                   
                        MainCircle.Height = Circle.Radius*10<=200? Circle.Radius*10:200;
                        MainCircle.Width = Circle.Radius*10 <= 200 ? Circle.Radius*10 : 200;
                        MainCircle.Visibility = Visibility.Visible;
                       MainFigure.Points = new PointCollection() { new Point(0, 0), new Point(0, 0), new Point(0, 0) };
                    break;
                default:
                    break;
            }
            

        }
        void AnglesIndefined(string figure)
        {
            labelType.Content = $"TYPE = {figure} (Angles not defined)";
            FirstAngle_Triangle.Text = "??";
            SecondAngle_Triangle.Text = "??";
            ThirdAngle_Triangle.Text = "??";
            CBAngle_Rectangle.Text= "??";
            ACAngle_Rectangle.Text= "??";
            DAAngle_Rectangle.Text = "??";
            BDAngle_Rectangle.Text= "??";

        }
        private void Button_Calculations(object sender, RoutedEventArgs e)
        {
           
        
            switch (checkBoxType)
            {
                case (int)CheckBoxTypes.Triangle:

                 
                    try
                    {
                      
                        Triangle.FirstSide = Convert.ToDouble(FirstSide_Triangle.Text);
                        Triangle.SecondSide = Convert.ToDouble(SecondSide_Triangle.Text);
                        Triangle.ThirdSide = Convert.ToDouble(ThirdSide_Triangle.Text);
                        Triangle.FirstAngle = Convert.ToDouble(FirstAngle_Triangle.Text);
                        Triangle.SecondAngle = Convert.ToDouble(SecondAngle_Triangle.Text);
                        Triangle.ThirdAngle = Convert.ToDouble(ThirdAngle_Triangle.Text);
                    }
                    catch (Exception) { }
                    labelPerimeter.Content = $"P = {Triangle.Perimeter()}";
                    labelS.Content = $"S = {Triangle.Area()}";
                    FigureTypePrint(Triangle.DefineType());
                    DrawFigure(Triangle.DefineType());
                    break;


                case (int)CheckBoxTypes.Quadrilateral:
                    try
                    {
                        Quadrilateral.A = Convert.ToDouble(ASide_Rectangle.Text);
                        Quadrilateral.B = Convert.ToDouble(BSide_Rectangle.Text);
                        Quadrilateral.C = Convert.ToDouble(CSide_Rectangle.Text);
                        Quadrilateral.D = Convert.ToDouble(DSide_Rectangle.Text);
                        Quadrilateral.AngleBetweenAC = Convert.ToDouble(ACAngle_Rectangle.Text);
                        Quadrilateral.AngleBetweenCB = Convert.ToDouble(CBAngle_Rectangle.Text);
                        Quadrilateral.AngleBetweenDA = Convert.ToDouble(DAAngle_Rectangle.Text);
                        Quadrilateral.AngleBetweenBD = Convert.ToDouble(BDAngle_Rectangle.Text);
                    }
                    catch (Exception) { }
                    labelPerimeter.Content = $"P = {Quadrilateral.Perimeter()}";
                    labelS.Content = $"S = {Quadrilateral.Area()}";
                    FigureTypePrint(Quadrilateral.DefineType());
                    DrawFigure(Quadrilateral.DefineType());
                    break;
                case (int)CheckBoxTypes.Pentagon:
                    try
                    {
                        Pentagon.Side = Convert.ToDouble(Side_Pentagon.Text);
                       
                    }
                    catch (Exception) { }
                    labelPerimeter.Content = $"P = {Pentagon.Perimeter()}";
                    labelS.Content = $"S = {Pentagon.Area()}";
                    labelType.Content = "TYPE = Pentagon";
                    DrawFigure(5);
                    break;
                case (int)CheckBoxTypes.Circle:
                    try
                    {
                        Circle.Radius = Convert.ToDouble(Radius_Circle.Text);

                    }
                    catch (Exception) { }
                    labelPerimeter.Content = $"P = {Circle.Perimeter()}";
                    labelS.Content = $"S = {Circle.Area()}";
                    labelType.Content = "TYPE = Circle";
                    DrawFigure(0);
                    break;
                default:
                    break;
            } 

                MainFigureCanvas.Visibility = Visibility.Visible;
            
        }

     
    }
}
