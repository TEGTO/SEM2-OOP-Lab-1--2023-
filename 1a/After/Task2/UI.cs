using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
namespace OOP_Lab_1
{
    public class TextChecking
    {

        private static readonly Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text (only numbers)
        private static bool IsTextAllowed(string text)
        {
            return !regex.IsMatch(text);
        }
        //set event to all buttons on canvases in stack panel 
        public static void SetEventPreviewText(StackPanel stackPanel)
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
                            tx.PreviewTextInput += PreviewTextInputHandler;
                        }
                    }
                }

            }
        }
        private static void PreviewTextInputHandler(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
    }

}
