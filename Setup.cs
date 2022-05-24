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

        static public void setupEllipseThickness(Ellipse ellipse, Thickness thickness)
        {
            switch (thickness)
            {
                case Thickness.SMALL:
                    ellipse.StrokeThickness = 2;
                    ellipse.Height = 2;
                    ellipse.Width = 2;
                    return;
                case Thickness.MEDIUM:
                    ellipse.StrokeThickness = 4;
                    ellipse.Height = 4;
                    ellipse.Width = 4;
                    return;
                case Thickness.BIG:
                    ellipse.StrokeThickness = 6;
                    ellipse.Height = 6;
                    ellipse.Width = 6;
                    return;
            }
        }
    }
}
