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
   

        static public void createPenEllipse(
            double thickness,
            Color color, 
            Canvas canvas, 
            MouseEventArgs e)
        {
            Ellipse el = new Ellipse();

            el.StrokeThickness = thickness;  
            
            el.Stroke = new SolidColorBrush(color);
            el.Fill = new SolidColorBrush(color);

            Canvas.SetTop(el, e.GetPosition(canvas).Y);
            Canvas.SetLeft(el, e.GetPosition(canvas).X);
            canvas.Children.Add(el);
        }


        static public void createDemoEllipse(
            double thickness,
            Canvas canvas,
            Color color)
        {
            Ellipse el = new Ellipse();

            el.StrokeThickness = thickness; 
         
            el.Stroke = new SolidColorBrush(color);
            el.Fill = new SolidColorBrush(color);

            Canvas.SetTop(el, canvas.Height / thickness / 2);
            Canvas.SetLeft(el, canvas.Width / thickness / 2);
            

            canvas.Children.Add(el);
        }

       
    }

    
}
