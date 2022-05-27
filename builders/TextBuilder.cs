
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace graphical_editor.builders
{
    internal class TextBuilder
    {
        static public void createText(double thickness,Canvas canvas, Color color, MouseEventArgs e)
        {
            TextBox  textBox = new TextBox();
            textBox.Text = "Test text";
            Canvas.SetTop(textBox,e.GetPosition(canvas).Y); 
            Canvas.SetLeft(textBox,e.GetPosition(canvas).X);

            textBox.FontSize = thickness; 

            canvas.Children.Add(textBox); 
        }
    }
}
