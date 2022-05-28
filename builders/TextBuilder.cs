
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
        private bool isFocused; 
        public void createTextBox(
           double thickness,
           Canvas canvas,
           MouseEventArgs e
           )
        {
            TextBox textBox = new TextBox();

            textBox.MouseEnter += onGotFocus; 

            textBox.Height = Math.Abs(currentPosition.Y - e.GetPosition(canvas).Y);
            textBox.Width = Math.Abs(currentPosition.X - e.GetPosition(canvas).X);
            Canvas.SetTop(textBox, Math.Min(currentPosition.Y, e.GetPosition(canvas).Y));
            Canvas.SetLeft(textBox, Math.Min(currentPosition.X, e.GetPosition(canvas).X));

            textBox.Background = new SolidColorBrush(Colors.White); 
            textBox.Background.Opacity = 0; 

            if (FigureNum > 0)
            {
                canvas.Children.Remove(canvas.Children[canvas.Children.Count - 1]);
            }
            FigureNum++;

            canvas.Children.Add(textBox);
        }

        public bool isTextFocused()
        {
            return isFocused; 
        }

        private void onGotFocus(object sender, RoutedEventArgs e)
        {
            isFocused = true; 
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

