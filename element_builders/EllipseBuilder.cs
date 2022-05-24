using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace graphical_editor
{
    internal class EllipseBuilder
    {
   

        static public void createEllipse(
            Thickness thickness ,
            ColorPicker colorPicker , 
            Canvas canvas , 
            MouseEventArgs e)
        {
            Ellipse el = new Ellipse();
            EllipseBuilder.setupEllipseThickness(el, thickness);
            el.Stroke = new SolidColorBrush(colorPicker.Color);
            el.Fill = new SolidColorBrush(colorPicker.Color);

            Canvas.SetTop(el, e.GetPosition(canvas).Y);
            Canvas.SetLeft(el, e.GetPosition(canvas).X);
            canvas.Children.Add(el);
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
                    ellipse.StrokeThickness = 5;
                    ellipse.Height = 10;
                    ellipse.Width = 10;
                    return;
            }
        }
    }

    
}
