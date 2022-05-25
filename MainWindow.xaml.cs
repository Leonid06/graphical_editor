using graphical_editor.element_builders;
using System;
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
        private DrawMode mode;
        private Thickness thickness;
        private bool capturedRootMenu = false;

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
                EllipseBuilder.createEllipse(thickness, colorPicker, drawCanvas,e);
                LineBuilder.createLine(thickness, colorPicker, drawCanvas, e);
            }
        }

        private void drawCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EllipseBuilder.createEllipse(thickness, colorPicker, drawCanvas, e);
            LineBuilder.SetCurrentPosition(drawCanvas, e);
        }

        private void undoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            drawCanvas.Children.Clear();
        }

        private void rootMenu_GotMouseCapture(object sender, MouseEventArgs e)
        {
            capturedRootMenu = true;
         
        }

        //private void ctrl_z_click(object sender, routedeventargs e)
        //{
        //    drawcanvas.children.removeat(drawcanvas.children.count - 1);
        //}
    }
}
