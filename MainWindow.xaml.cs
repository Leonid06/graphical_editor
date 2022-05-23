﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace graphical_editor
{
    enum DrawMode
    {
        Ellipse, Pen, Pencil , Text
    }

    enum Thickness
    {
        SMALL, MEDIUM, BIG
    }

    public partial class MainWindow : Window
    {
        DrawMode mode;
        Thickness thickness;
        Point currentPosition; 
        Line drawLine; 

        public MainWindow()
        {
            mode = DrawMode.Pen;
            thickness = Thickness.BIG;
            InitializeComponent();
            colorPicker.Brush = new SolidColorBrush(Colors.Black); 
        }

       

        private void penMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mode = DrawMode.Pen; 
        }

        private void pencilMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mode = DrawMode.Pencil;
        }

        private void drawCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                drawLine = new Line();
                drawLine.Stroke = colorPicker.Brush;

                Setup.setupLineThickness(drawLine, thickness);

                drawLine.X1 = currentPosition.X;
                drawLine.Y1 = currentPosition.Y;

                
                drawLine.X2 = e.GetPosition(drawCanvas).X;
                drawLine.Y2 = e.GetPosition(drawCanvas).Y;
                
                

                currentPosition = e.GetPosition(drawCanvas);

                drawCanvas.Children.Add(drawLine);
            }
        }

        private void drawCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ButtonState == MouseButtonState.Pressed && !rootMenu.IsMouseOver)
            {
                currentPosition = e.GetPosition(drawCanvas);
            }
        }

        private void undoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            drawCanvas.Children.Clear();
        }
    }
}
