﻿using System;
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
using Xceed.Wpf.Toolkit;

namespace graphical_editor.element_builders
{
    static internal class LineBuilder
    {
        static Point currentPosition;
        static public void createLine(
            Thickness thickness,
            Syncfusion.Windows.Shared.ColorPicker colorPicker,
            Canvas canvas,
            MouseEventArgs e,
            ref bool capturedRootMenu
            )
        {
            Line line = new Line();
            LineBuilder.setupLineThickness(line, thickness);

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
            line.Stroke = new SolidColorBrush(colorPicker.Color);
            currentPosition = e.GetPosition(canvas);
            canvas.Children.Add(line);
        }

        static public void SetCurrentPosition(
            Canvas canvas,
            MouseEventArgs e)
        {
            currentPosition = e.GetPosition(canvas);
        }

        static public void setupLineThickness(Line line, Thickness thickness)
        {
            switch (thickness)
            {
                case Thickness.SMALL:
                    line.StrokeThickness = 6;
                    return;
                case Thickness.MEDIUM:
                    line.StrokeThickness = 10;
                    return;
                case Thickness.BIG:
                    line.StrokeThickness = 30;
                    return;
            }
        }

        internal static void SetCurrentPosition()
        {
            throw new NotImplementedException();
        }
    }
}