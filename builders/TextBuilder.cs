﻿
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace graphical_editor.builders
{
    internal class TextBuilder
    {

        private Point currentPosition;
        private int FigureNum;
        private bool isResizable;
        private TextBox textBox;

        public TextBuilder()
        {
            textBox = new TextBox();
        }
        public void createTextBox(
           double thickness,
           Canvas canvas,
           MouseEventArgs e
           )
        {
            textBox = new TextBox();

            textBox.MouseLeftButtonDown += onLeftButtonDown;

            textBox.Height = Math.Abs(currentPosition.Y - e.GetPosition(canvas).Y);
            textBox.Width = Math.Abs(currentPosition.X - e.GetPosition(canvas).X);
            Canvas.SetTop(textBox, Math.Min(currentPosition.Y, e.GetPosition(canvas).Y));
            Canvas.SetLeft(textBox, Math.Min(currentPosition.X, e.GetPosition(canvas).X));

            textBox.Background = new SolidColorBrush(Colors.White);
            textBox.Background.Opacity = 0;

            try
               {
                   if (FigureNum > 0)
                   {
                        canvas.Children.Remove(canvas.Children[canvas.Children.Count - 1]);
                   }
               }
            catch
               {

               }

                  FigureNum++;
                  canvas.Children.Add(textBox);

        }

        private void onLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.Focus(textBox);
        }

        public TextBox getText()
        {
            return textBox;  
        }
        public bool isTextResizable()
        {
            return isResizable; 
        }

        public void setResizable(bool value)
        {
            isResizable = value;  
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

    //public void createText(double thickness,Canvas canvas, Color color, MouseEventArgs e)
    //{
    //    textBox.Text = "        ";

    //    Canvas.SetTop(textBox,e.GetPosition(canvas).Y); 
    //    Canvas.SetLeft(textBox,e.GetPosition(canvas).X);

    //    textBox.FontSize = thickness;

    //    textBox.GotFocus += onGotFocus;
    //    textBox.LostFocus += onLostFocus; 

    //    try
    //    {
    //        canvas.Children.Add(textBox);
    //    }
    //    catch
    //    {

    //    }


    //}

    //public bool isTextFocused()
    //{
    //    return isFocused;
    //}

    //private void onGotFocus(object sender, RoutedEventArgs e)
    //{
    //    isFocused = true;
    //}

    //private void onLostFocus(object sender, RoutedEventArgs e)
    //{
    //    isFocused = false;
    //}


    //private void onTextChanged(object sender, TextChangedEventArgs e)
    //{
    //    if (!isUsed)
    //    {
    //        textBox.Text = "";
    //        isUsed = true; 
    //    }
    //}




}

