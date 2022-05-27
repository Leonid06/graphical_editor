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


namespace graphical_editor.element_builders
{
    internal class LineBuilder
    {
        static Point currentPosition;
        static int LineNum;  
        static public void createLine(
            double thickness,
            Color color,
            Canvas canvas,
            MouseEventArgs e,
            ToolType type,
            ref bool capturedRootMenu
            )
        {
            Line line = new Line();

            line.StrokeThickness = thickness;  

            line.X1 = currentPosition.X + line.StrokeThickness / 2;
            line.Y1 = currentPosition.Y + line.StrokeThickness / 2;

            if (!capturedRootMenu)
            {
                line.X2 = e.GetPosition(canvas).X + line.StrokeThickness / 2;
                line.Y2 = e.GetPosition(canvas).Y + line.StrokeThickness / 2;
            }
            else
            {
                line.X2 = line.X1;
                line.Y2 = line.Y1;
                capturedRootMenu = false;
            }
            if(type == ToolType.Pen)
            {
                line.Stroke = new SolidColorBrush(color);
            } else
            {
                line.Stroke = new SolidColorBrush(Colors.White); 
            }
            

            currentPosition = e.GetPosition(canvas);
            canvas.Children.Add(line);
        }

        static public void createStraightLine(
            double thickness,
            Color color,
            Canvas canvas,
            MouseEventArgs e,
            ref bool capturedRootMenu
            )
        {
            Line line = new Line();

            line.StrokeThickness = thickness; 
            

            line.X1 = currentPosition.X + line.StrokeThickness / 2;
            line.Y1 = currentPosition.Y + line.StrokeThickness / 2;

            if (!capturedRootMenu)
            {
                line.X2 = e.GetPosition(canvas).X + line.StrokeThickness / 2;
                line.Y2 = e.GetPosition(canvas).Y + line.StrokeThickness / 2;
            }
            else
            {
                line.X2 = line.X1;
                line.Y2 = line.Y1;
                capturedRootMenu = false;
            }
            line.Stroke = new SolidColorBrush(color);

            if (LineNum > 0)
            {
                canvas.Children.Remove(canvas.Children[canvas.Children.Count - 1]);
            }
            LineNum++;
            canvas.Children.Add(line);
        }

       
        static public void SetCurrentPosition(
            Canvas canvas,
            MouseEventArgs e)
        {
            currentPosition = e.GetPosition(canvas);
            LineNum = 0;
        }

        internal static void SetCurrentPosition()
        {
            throw new NotImplementedException();
        }


    }
}
