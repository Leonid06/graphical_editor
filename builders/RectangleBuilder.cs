using System;
using Syncfusion.Windows.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace graphical_editor.builders
{
    internal class RectangleBuilder
    {
        private Point currentPosition;
        private int FigureNum;
        

        public void createRectangle(
            double thickness,
            Color color,
            Canvas canvas,
            MouseEventArgs e
            )
        {
            Rectangle a = new Rectangle();
            a.StrokeThickness = thickness;
            a.Stroke = new SolidColorBrush(color);
            a.Fill = new SolidColorBrush(Colors.White);
            a.Fill.Opacity = 0;

            a.Height = Math.Abs(currentPosition.Y - e.GetPosition(canvas).Y);
            a.Width = Math.Abs(currentPosition.X - e.GetPosition(canvas).X);
            Canvas.SetTop(a, Math.Min(currentPosition.Y, e.GetPosition(canvas).Y));
            Canvas.SetLeft(a, Math.Min(currentPosition.X, e.GetPosition(canvas).X));

            if (FigureNum > 0)
            {
                canvas.Children.Remove(canvas.Children[canvas.Children.Count - 1]);
            }
            FigureNum++;

            canvas.Children.Add(a);
        }
        public void SetCurrentPosition(
            Canvas canvas,
            MouseEventArgs e)
        {
            currentPosition = e.GetPosition(canvas);
            FigureNum = 0;
        }

        internal static void SetCurrentPosition()
        {
            throw new NotImplementedException();
        }

        public void SetFigureNumZero()
        {
            FigureNum = 0;
        }
    }
}
