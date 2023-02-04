using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
namespace OOP_Lab_1
{
    /// <summary>
    /// Class for checking text in textBoxes. Allows only numbers.
    /// </summary>
    public class TextChecking
    {
        /// <summary>
        /// **Regex that matches disallowed text (only numbers).**
        /// </summary>
        private static readonly Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text (only numbers)
        /// <summary>
        /// **Check if text is allowed.**
        /// </summary>
        /// <param name="text">Text to checking.</param>
        /// <returns></returns>
        private static bool IsTextAllowed(string text)
        {
            return !regex.IsMatch(text);
        }
        //set event to all textBoxes on canvases in stack panel 
        /// <summary>
        /// **Set event to all textBoxes on canvases in stack panel **
        /// </summary>
        /// <param name="stackPanel"></param>
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
        /// <summary>
        /// **Allows text if text is correct.**
        /// </summary>
        /// <param name="sender">The element that called the method.</param>
        /// <param name="e">Contains state information and event data associated with a routed event.</param>
        private static void PreviewTextInputHandler(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
    }

}
