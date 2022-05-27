
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace graphical_editor.builders
{
    internal class TextBuilder
    {
        private TextBox textBox;
        private bool isUsed = false; 
        public bool isFocused = false;
        

        public TextBuilder()
        {
            textBox = new TextBox(); 
        }
        public void createText(double thickness,Canvas canvas, Color color, MouseEventArgs e)
        {
            textBox.Text = "        ";

            Canvas.SetTop(textBox,e.GetPosition(canvas).Y ); 
            Canvas.SetLeft(textBox,e.GetPosition(canvas).X);

            textBox.FontSize = thickness;

            textBox.TextChanged += onTextChanged;
            textBox.GotFocus += onGotFocus;
            textBox.LostFocus += onLostFocus; 
           
            canvas.Children.Add(textBox); 

        }

        private void onGotFocus(object sender, RoutedEventArgs e)
        {
            isFocused = true;  
        }

        private void onLostFocus(object sender, RoutedEventArgs e)
        {
            isFocused = false; 
        }


        private void onTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!isUsed)
            {
                textBox.Text = "";
                isUsed = true; 
            }
        }

        


    }
}
