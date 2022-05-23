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
    }
}
