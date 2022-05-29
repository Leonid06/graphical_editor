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

        private Point currentPosition;
        private int figureNum;


        public EllipseBuilder() { }

        public void createPenEllipse(
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




        public void createClassicEllipse(
            double thickness,
            Color color,
            Canvas canvas,
            MouseEventArgs e,
            bool isPreview
            )
        {
            Ellipse el = new Ellipse();

            el.StrokeThickness = thickness;

            el.Stroke = new SolidColorBrush(color);
            el.Fill = new SolidColorBrush(Colors.White); 
            el.Fill.Opacity = 0;

            el.Height = Math.Abs(currentPosition.Y - e.GetPosition(canvas).Y);
            el.Width = Math.Abs(currentPosition.X - e.GetPosition(canvas).X);

            Canvas.SetTop(el, Math.Min(currentPosition.Y , e.GetPosition(canvas).Y));
            Canvas.SetLeft(el, Math.Min(currentPosition.X, e.GetPosition(canvas).X));

            if (figureNum > 0)
            {
                canvas.Children.Remove(canvas.Children[canvas.Children.Count - 1]);
            }
            figureNum++;

            canvas.Children.Add(el);
        }

        public void createDemoEllipse(
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

        //private static double Abs(double v)
        //{
        //    throw new NotImplementedException();
        //}

        public void SetCurrentPosition(
            Canvas canvas,
            MouseEventArgs e)
        {
            currentPosition = e.GetPosition(canvas);
            figureNum = 0;
        }

        public void SetFigureNumZero()
        {
            figureNum = 0;
        }
    }

    
}
