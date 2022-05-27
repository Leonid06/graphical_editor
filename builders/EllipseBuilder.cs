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

        static Point currentPosition;

        static public void createPenEllipse(
            double thickness,
            Color color, 
            Canvas canvas, 
            ToolType type,
            MouseEventArgs e)
        {
            Ellipse el = new Ellipse();

            el.StrokeThickness = thickness;  

            if(type == ToolType.Pen)
            {
                el.Stroke = new SolidColorBrush(color);
                el.Fill = new SolidColorBrush(color);
            } else
            {
                el.Stroke = new SolidColorBrush(Colors.White);
                el.Fill = new SolidColorBrush(Colors.White); 
            }
            
            

            Canvas.SetTop(el, e.GetPosition(canvas).Y);
            Canvas.SetLeft(el, e.GetPosition(canvas).X);
            canvas.Children.Add(el);
        }

        


        static public void createDemoEllipse(
            double thickness,
            Color color,
            Canvas canvas,
            MouseEventArgs e
            )
        {
            Ellipse el = new Ellipse();

            el.StrokeThickness = thickness;

            el.Stroke = new SolidColorBrush(color);
            el.Fill = new SolidColorBrush(Colors.White);

            Canvas.SetTop(el, currentPosition.Y);
            Canvas.SetLeft(el, currentPosition.X);

            el.Height = Abs(currentPosition.Y - e.GetPosition(canvas).Y);
            el.Width = Abs(currentPosition.X - e.GetPosition(canvas).X);

            //Canvas.SetTop(el, canvas.Height / thickness / 2);
            //Canvas.SetLeft(el, canvas.Width / thickness / 2);

            canvas.Children.Add(el);
        }

        private static double Abs(double v)
        {
            throw new NotImplementedException();
        }

        static public void SetCurrentPosition(
            Canvas canvas,
            MouseEventArgs e)
        {
            currentPosition = e.GetPosition(canvas);
        }
    }

    
}
