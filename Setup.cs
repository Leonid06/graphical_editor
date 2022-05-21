using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace graphical_editor
{
    internal class Setup
    {
        static public void setupLineColor(Line line, StrokeColor color)
        {
            switch (color)
            {
                case StrokeColor.Black:
                    line.Stroke = new SolidColorBrush(Colors.Black);
                    return;
                case StrokeColor.Red:
                    line.Stroke = new SolidColorBrush(Colors.Red);
                    return;
                case StrokeColor.Blue:
                    line.Stroke = new SolidColorBrush(Colors.Blue);
                    return;
                case StrokeColor.Yellow:
                    line.Stroke = new SolidColorBrush(Colors.Yellow);
                    return;
                case StrokeColor.Green:
                    line.Stroke = new SolidColorBrush(Colors.Green);
                    return;
            }


        }

        static public void setupLineThickness(Line line , Thickness thickness)
        {
            switch (thickness)
            {
                case Thickness.SMALL:
                    line.StrokeThickness = 2;
                    return;
                case Thickness.MEDIUM:
                    line.StrokeThickness = 4;
                    return;
                case Thickness.BIG:
                    line.StrokeThickness = 6;
                    return; 
            }
        }
    }
}
