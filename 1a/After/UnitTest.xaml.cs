using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOP_Lab_1
{
    /// <summary>
    /// Interaction logic for UnitTests.xaml
    /// </summary>
    public partial class UnitTest : Window
    {
        public UnitTest()
        {
            InitializeComponent();
        }

        private void ButtonSortTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UnitTestsSortingMethods.unitTestStart();
            }
            catch (Exception ex)
            {
                resultTextBox.Text = ex.Message + "\n";


            }
            resultTextBox.Text += $"{UnitTestsSortingMethods.statusMessages[7]}";
            for (int i = 0; i < 7; i++)
            {
                resultTextBox.Text += $"\n{UnitTestsSortingMethods.statusMessages[i]}";
            }

        }
    }
}
