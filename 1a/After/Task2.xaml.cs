
using System;
using System.Windows;
using System.Windows.Controls;
using Task2.Figures;
using Task2.UI;

namespace OOP_Lab_1
{


    /// <summary>
    ///  **Class that contains tasks of part two of the exercise.**
    /// </summary>

    public partial class Task2 : Window
    {

        /// <summary>
        ///  Initialize UI and some elements.
        /// </summary>


        public Task2()
        {
            InitializeComponent();
            TextChecking.SetEventPreviewText(stackPanelFiguresCanvases);

        }
        //Calculation
        //calculation button
        /// <summary>
        /// Button method to start calculations functions.
        /// </summary>
        /// <param name="sender">The element that called the method.</param>
        /// <param name="e">Contains state information and event data associated with a routed event.</param>
        private void ButtonClick_Calculation(object sender, RoutedEventArgs e)
        {
            try
            {
                GiveValuesToClasses();
                CalculationsFillLabels();
            }
            catch (Exception)
            {
                labelPerimeter.Content = "Invalid Type";
                labelS.Content = "Invalid Type";

            }

        }
        //give values from textboxes to static classes
        /// <summary>
        ///The method gives values from all textboxes to static class for calculations.
        ///\details Throws exception if textboxes are empty.
        /// </summary>

        public void GiveValuesToClasses()
        {
            try
            {
                switch (figuresComboBox.SelectedIndex)
                {
                    case (int)ComboBoxFiguresIndex.Triangle:
                        Triangle.firstAngle = Convert.ToSingle(triangleTextBox_FirstAngle.Text);
                        Triangle.secondAngle = Convert.ToSingle(triangleTextBox_SecondAngle.Text);
                        Triangle.thirdAngle = Convert.ToSingle(triangleTextBox_ThirdAngle.Text);
                        Triangle.sirstSide = Convert.ToSingle(triangleTextBox_FirstSide.Text);
                        Triangle.secondSide = Convert.ToSingle(triangleTextBox_SecondSide.Text);
                        Triangle.thirdSide = Convert.ToSingle(triangleTextBox_ThirdSide.Text);
                        break;
                    case (int)ComboBoxFiguresIndex.Quadrilateral:

                        Quadrilateral.firstSide = Convert.ToSingle(quadrilateralTextBox_FirstSide.Text);
                        Quadrilateral.secondSide = Convert.ToSingle(quadrilateralTextBox_SecondSide.Text);
                        Quadrilateral.thirdSide = Convert.ToSingle(quadrilateralTextBox_ThirdSide.Text);
                        Quadrilateral.fourthSide = Convert.ToSingle(quadrilateralTextBox_FourthSide.Text);
                        Quadrilateral.fourthAngle = Convert.ToSingle(quadrilateralTextBox_FirstAngle.Text);
                        Quadrilateral.firstAngle = Convert.ToSingle(quadrilateralTextBox_SecondAngle.Text);
                        Quadrilateral.secondAngle = Convert.ToSingle(quadrilateralTextBox_ThirdAngle.Text);
                        Quadrilateral.thirdAngle = Convert.ToSingle(quadrilateralTextBox_FourthAngle.Text);
                        break;
                    case (int)ComboBoxFiguresIndex.PentagonCanvas:
                        Pentagon.side = Convert.ToSingle(pentagonTextBox_Side.Text);
                        break;
                    case (int)ComboBoxFiguresIndex.Circle:
                        Circle.radius = Convert.ToSingle(circleTextBox_Radius.Text);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        //perform calculations and fill in labels based on the results
        /// <summary>
        /// The method fills labels with results of calculations functions.
        /// </summary>
        private void CalculationsFillLabels()
        {
            switch (figuresComboBox.SelectedIndex)
            {
                case (int)ComboBoxFiguresIndex.Triangle:
                    labelS.Content = Triangle.Area();
                    labelPerimeter.Content = Triangle.Perimeter();
                    break;
                case (int)ComboBoxFiguresIndex.Quadrilateral:
                    labelS.Content = Quadrilateral.Area();
                    labelPerimeter.Content = Quadrilateral.Perimeter();
                    break;
                case (int)ComboBoxFiguresIndex.PentagonCanvas:
                    labelS.Content = Pentagon.Area();
                    labelPerimeter.Content = Pentagon.Perimeter();
                    break;
                case (int)ComboBoxFiguresIndex.Circle:
                    labelS.Content = Circle.Area();
                    labelPerimeter.Content = Circle.Perimeter();
                    break;
                default:
                    break;
            }
        }

        //hide all figures canvases
        /// <summary>
        /// The method hides all canvases on a stackpanel.
        /// </summary>

        private void HideAllCanvases(StackPanel stackPanel)
        {
            Canvas canvas;

            foreach (var item in stackPanel.Children)
            {
                if (item is Canvas)
                {
                    canvas = item as Canvas;
                    canvas.Visibility = Visibility.Hidden;
                }
            }
        }
        //ComboBoxFunctions
        /// <summary>
        /// Enum of different figures.
        /// </summary>
        enum ComboBoxFiguresIndex
        {
            /// <summary>
            /// Triangle figure.
            /// </summary>
            Triangle = 0,
            /// <summary>
            /// Quadrilateral figure.
            /// </summary>
            Quadrilateral,
            /// <summary>
            /// PentagonCanvas figure.
            /// </summary>
            PentagonCanvas,
            /// <summary>
            /// Circle figure.
            /// </summary>
            Circle
        }
        //comboBox SelectionChanged function to show a figure canvas and to fill combobox of the figure's type
        /// <summary>
        /// The method makes different canvases visible depending on selection of the main comboBox.
        /// </summary>
        /// <param name="sender">The element that called the method.</param>
        /// <param name="e">Contains state information and event data associated with a routed event.</param>
        private void ComboBoxFiguresCanvases_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            HideAllCanvases(stackPanelFiguresCanvases);
            stackPanelType.Visibility = Visibility.Hidden;
            TypeComboBoxFill();
            switch (figuresComboBox.SelectedIndex)
            {
                case (int)ComboBoxFiguresIndex.Triangle:
                    triangleCanvas.Visibility = Visibility.Visible;
                    stackPanelType.Visibility = Visibility.Visible;
                    break;
                case (int)ComboBoxFiguresIndex.Quadrilateral:
                    quadrilateralCanvas.Visibility = Visibility.Visible;
                    stackPanelType.Visibility = Visibility.Visible;
                    break;
                case (int)ComboBoxFiguresIndex.PentagonCanvas:
                    pentagonCanvas.Visibility = Visibility.Visible;

                    break;
                case (int)ComboBoxFiguresIndex.Circle:
                    circleCanvas.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }

        }
        //combobox fill function
        //comboBox SelectionChanged function to show a figure canvas and to fill combobox of the figure's type
        /// <summary>
        /// The method fills the combobox of figure type depending on selection of the main combobox.
        /// </summary>

        private void TypeComboBoxFill()
        {
            figureTypeComboBox.Items.Clear();

            switch (figuresComboBox.SelectedIndex)
            {
                case (int)ComboBoxFiguresIndex.Triangle:
                    figureTypeComboBox.Items.Add("Scalene");
                    figureTypeComboBox.Items.Add("Equilateral");
                    figureTypeComboBox.Items.Add("Isosceles");
                    figureTypeComboBox.Items.Add("Right");
                    break;
                case (int)ComboBoxFiguresIndex.Quadrilateral:
                    figureTypeComboBox.Items.Add("FreeQuadrilateral");
                    figureTypeComboBox.Items.Add("Rectangle");
                    figureTypeComboBox.Items.Add("Square");
                    figureTypeComboBox.Items.Add("Rhombus");
                    figureTypeComboBox.Items.Add("Parallelogram");
                    figureTypeComboBox.Items.Add("Trapezoid");
                    figureTypeComboBox.Items.Add("TrapezoidRight");
                    figureTypeComboBox.Items.Add("TrapezoidIsosceles");
                    break;

                default:
                    break;
            }
            figureTypeComboBox.SelectedIndex = 0;

        }
        //setting of textboxes by figure type

        /// <summary>
        /// The method fills different textboxes depending on selection of figureTypeComboBox.
        /// \details Also subscribes text boxes on FiguresTextBox_TextChanged depending on selection of type.
        /// </summary>
        /// <param name="sender">The element that called the method.</param>
        /// <param name="e">Contains state information and event data associated with a routed event.</param>
        private void ComboBoxFigureType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBoxesResetToDefault(stackPanelFiguresCanvases);  
            switch (figuresComboBox.SelectedIndex)
            {
                case (int)ComboBoxFiguresIndex.Triangle:
                    switch (figureTypeComboBox.SelectedIndex)
                    {
                        case (int)TriangleTypes.Equilateral:
                            triangleTextBox_FirstAngle.Text = "60";
                            triangleTextBox_FirstAngle.IsReadOnly = true;
                            triangleTextBox_SecondAngle.Text = "60";
                            triangleTextBox_SecondAngle.IsReadOnly = true;
                            triangleTextBox_ThirdAngle.Text = "60";
                            triangleTextBox_ThirdAngle.IsReadOnly = true;
                            break;
                        case (int)TriangleTypes.Isosceles:
                            triangleTextBox_FirstSide.TextChanged += FiguresTextBox_TextChanged;
                            triangleTextBox_SecondSide.TextChanged += FiguresTextBox_TextChanged;
                            triangleTextBox_FirstAngle.TextChanged += FiguresTextBox_TextChanged;
                            triangleTextBox_SecondAngle.TextChanged += FiguresTextBox_TextChanged;
                            break;
                        case (int)TriangleTypes.Right:
                            triangleTextBox_FirstAngle.Text = "90";
                            triangleTextBox_FirstAngle.IsReadOnly = true;     
                            break;
                        default:
                            break;
                    }
                    break;
                case (int)ComboBoxFiguresIndex.Quadrilateral:
                    switch (figureTypeComboBox.SelectedIndex)
                    {
                        case (int)QuadrilateralTypes.Rectangle:
                        case (int)QuadrilateralTypes.Square:
                            quadrilateralTextBox_FirstAngle.Text = "90";
                            quadrilateralTextBox_FirstAngle.IsReadOnly = true;
                            quadrilateralTextBox_SecondAngle.Text = "90";
                            quadrilateralTextBox_SecondAngle.IsReadOnly = true;
                            quadrilateralTextBox_ThirdAngle.Text = "90";
                            quadrilateralTextBox_ThirdAngle.IsReadOnly = true;
                            quadrilateralTextBox_FourthAngle.Text = "90";
                            quadrilateralTextBox_FourthAngle.IsReadOnly = true;
                            quadrilateralTextBox_FirstSide.TextChanged += FiguresTextBox_TextChanged;
                            quadrilateralTextBox_SecondSide.TextChanged += FiguresTextBox_TextChanged;
                            quadrilateralTextBox_ThirdSide.TextChanged += FiguresTextBox_TextChanged;
                            quadrilateralTextBox_FourthSide.TextChanged += FiguresTextBox_TextChanged;
                            break;

                        case (int)QuadrilateralTypes.Parallelogram:
                        case (int)QuadrilateralTypes.Rhombus:
                            quadrilateralTextBox_FirstSide.TextChanged += FiguresTextBox_TextChanged;
                            quadrilateralTextBox_SecondSide.TextChanged += FiguresTextBox_TextChanged;
                            quadrilateralTextBox_ThirdSide.TextChanged += FiguresTextBox_TextChanged;
                            quadrilateralTextBox_FourthSide.TextChanged += FiguresTextBox_TextChanged;

                            quadrilateralTextBox_FirstAngle.TextChanged += FiguresTextBox_TextChanged;
                            quadrilateralTextBox_SecondAngle.TextChanged += FiguresTextBox_TextChanged;
                            quadrilateralTextBox_ThirdAngle.TextChanged += FiguresTextBox_TextChanged;
                            quadrilateralTextBox_FourthAngle.TextChanged += FiguresTextBox_TextChanged;
                            break;
                        case (int)QuadrilateralTypes.TrapezoidRight:
                            quadrilateralTextBox_FirstAngle.Text = "90";
                            quadrilateralTextBox_FirstAngle.IsReadOnly = true;
                            quadrilateralTextBox_SecondAngle.Text = "90";
                            quadrilateralTextBox_SecondAngle.IsReadOnly = true;
                            quadrilateralTextBox_ThirdAngle.TextChanged += FiguresTextBox_TextChanged;
                            quadrilateralTextBox_FourthAngle.TextChanged += FiguresTextBox_TextChanged;
                            break;
                        case (int)QuadrilateralTypes.TrapezoidIsosceles:
                        case (int)QuadrilateralTypes.Trapezoid:
                            quadrilateralTextBox_FirstSide.TextChanged += FiguresTextBox_TextChanged;
                            quadrilateralTextBox_ThirdSide.TextChanged += FiguresTextBox_TextChanged;
                            quadrilateralTextBox_FirstAngle.TextChanged += FiguresTextBox_TextChanged;
                            quadrilateralTextBox_SecondAngle.TextChanged += FiguresTextBox_TextChanged;
                            quadrilateralTextBox_ThirdAngle.TextChanged += FiguresTextBox_TextChanged;
                            quadrilateralTextBox_FourthAngle.TextChanged += FiguresTextBox_TextChanged;
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
        }

        //TextBoxFunctions 
        /// <summary>
        /// he method resets all textBoxes on stackPanel to default settings.
        /// </summary>

        private void TextBoxesResetToDefault(StackPanel stackPanel)
        {
            TextBox tx;
            Canvas canvas;
            foreach (var item in stackPanel.Children)
            {
                if (item is Canvas)
                {
                    canvas = item as Canvas;
                    foreach (var element in canvas.Children)
                    {
                        if (element is TextBox)
                        {
                            tx = element as TextBox;
                            tx.IsReadOnly = false;
                            tx.TextChanged -= FiguresTextBox_TextChanged;
                            tx.Text = "";
                           
                        }
                    }
                }

            }
        }
        //textChanged event, different behaviour for every figure 
        /// <summary>
        /// The method makes different behaviour of textboxes depending on figureTypeComboBox.
        /// \details All types of figures have different behaviour. Method fills and make textboxes uneditable depending on type.
        /// </summary>
        /// <param name="sender">The element that called the method.</param>
        /// <param name="e">Contains state information and event data associated with a routed event.</param>
        private void FiguresTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            switch (figuresComboBox.SelectedIndex)
            {
                case (int)ComboBoxFiguresIndex.Triangle:
                    if (tx != triangleTextBox_SecondAngle && tx != triangleTextBox_FirstAngle)
                    {
                        triangleTextBox_FirstSide.Text = tx.Text;
                        triangleTextBox_SecondSide.Text = tx.Text;

                    }
                    else
                    {
                        triangleTextBox_SecondAngle.Text = tx.Text;
                        triangleTextBox_FirstAngle.Text = tx.Text;
                    }
                    break;
                case (int)ComboBoxFiguresIndex.Quadrilateral:
                    switch (figureTypeComboBox.SelectedIndex)
                    {
                        case (int)QuadrilateralTypes.Rectangle:
                            if (tx == quadrilateralTextBox_ThirdSide || tx == quadrilateralTextBox_FirstSide)
                            {
                                quadrilateralTextBox_FirstSide.Text = tx.Text;
                                quadrilateralTextBox_ThirdSide.Text = tx.Text;
                            }
                            else
                            {
                                quadrilateralTextBox_SecondSide.Text = tx.Text;
                                quadrilateralTextBox_FourthSide.Text = tx.Text;

                            }
                            break;
                        case (int)QuadrilateralTypes.Square:
                            quadrilateralTextBox_FirstSide.Text = tx.Text;
                            quadrilateralTextBox_SecondSide.Text = tx.Text;
                            quadrilateralTextBox_ThirdSide.Text = tx.Text;
                            quadrilateralTextBox_FourthSide.Text = tx.Text;
                            break;
                        case (int)QuadrilateralTypes.Rhombus:
                            if (tx == quadrilateralTextBox_FirstAngle || tx == quadrilateralTextBox_ThirdAngle)
                            {
                                quadrilateralTextBox_FirstAngle.Text = tx.Text;
                                quadrilateralTextBox_ThirdAngle.Text = tx.Text;
                            }
                            else if (tx == quadrilateralTextBox_SecondAngle || tx == quadrilateralTextBox_FourthAngle)
                            {
                                quadrilateralTextBox_SecondAngle.Text = tx.Text;
                                quadrilateralTextBox_FourthAngle.Text = tx.Text;

                            }
                            else
                            {
                                quadrilateralTextBox_FirstSide.Text = tx.Text;
                                quadrilateralTextBox_SecondSide.Text = tx.Text;
                                quadrilateralTextBox_ThirdSide.Text = tx.Text;
                                quadrilateralTextBox_FourthSide.Text = tx.Text;
                            }
                            break;

                        case (int)QuadrilateralTypes.Parallelogram:
                            if (tx == quadrilateralTextBox_FirstAngle || tx == quadrilateralTextBox_ThirdAngle)
                            {
                                quadrilateralTextBox_FirstAngle.Text = tx.Text;
                                quadrilateralTextBox_ThirdAngle.Text = tx.Text;
                            }
                            else if (tx == quadrilateralTextBox_SecondAngle || tx == quadrilateralTextBox_FourthAngle)
                            {
                                quadrilateralTextBox_SecondAngle.Text = tx.Text;
                                quadrilateralTextBox_FourthAngle.Text = tx.Text;

                            }
                            else if (tx == quadrilateralTextBox_ThirdSide || tx == quadrilateralTextBox_FirstSide)
                            {
                                quadrilateralTextBox_FirstSide.Text = tx.Text;
                                quadrilateralTextBox_ThirdSide.Text = tx.Text;
                            }
                            else
                            {
                                quadrilateralTextBox_SecondSide.Text = tx.Text;
                                quadrilateralTextBox_FourthSide.Text = tx.Text;

                            }
                            break;
                        case (int)QuadrilateralTypes.TrapezoidIsosceles:          
                            if (tx == quadrilateralTextBox_FirstAngle || tx == quadrilateralTextBox_FourthAngle)
                            {
                                quadrilateralTextBox_FirstAngle.Text = tx.Text;
                                quadrilateralTextBox_FourthAngle.Text = tx.Text;
                            }
                            else if (tx == quadrilateralTextBox_SecondAngle || tx == quadrilateralTextBox_ThirdAngle)
                            {

                                quadrilateralTextBox_SecondAngle.Text = tx.Text;
                                quadrilateralTextBox_ThirdAngle.Text = tx.Text; 

                              
                            }
                            else
                            {
                                quadrilateralTextBox_FirstSide.Text = tx.Text;
                                quadrilateralTextBox_ThirdSide.Text = tx.Text;
                            }
                            break;
                        default:
                            break;
                        case (int)QuadrilateralTypes.Trapezoid:
                        case (int)QuadrilateralTypes.TrapezoidRight:
                            float buffer;
                            float.TryParse(tx.Text, out buffer);
                            if (tx == quadrilateralTextBox_FirstAngle || tx == quadrilateralTextBox_SecondAngle)
                            {
                                if (tx == quadrilateralTextBox_FirstAngle)
                                {
                                    quadrilateralTextBox_FirstAngle.Text = tx.Text;
                                    quadrilateralTextBox_SecondAngle.Text = (180 - buffer).ToString();
                                }
                                else
                                {
                                    quadrilateralTextBox_SecondAngle.Text = tx.Text;
                                    quadrilateralTextBox_FirstAngle.Text = (180 - buffer).ToString();
                                }
                            }
                            else if (tx == quadrilateralTextBox_FourthAngle || tx == quadrilateralTextBox_ThirdAngle)
                            {
                                if (tx == quadrilateralTextBox_FourthAngle)
                                {
                                    quadrilateralTextBox_FourthAngle.Text = tx.Text;
                                    quadrilateralTextBox_ThirdAngle.Text = (180 - buffer).ToString();
                                }
                                else
                                {
                                    quadrilateralTextBox_ThirdAngle.Text = tx.Text;
                                    quadrilateralTextBox_FourthAngle.Text = (180 - buffer).ToString();
                                }
                              
                            }
                            break;
                    }
                    break;
                default:
                    break;
            }
        }


    }

}
