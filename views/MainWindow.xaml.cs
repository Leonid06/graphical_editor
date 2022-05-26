using graphical_editor.element_builders;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;


namespace graphical_editor
{
    enum ToolType 
    {
        Ellipse, Pen, Text, Eraser, Line, Rectangle
    }

    enum Thickness
    {
        SMALL, MEDIUM, BIG
    }

    public partial class MainWindow : Window
    {
        private ToolType toolType;
        private Color color; 
        private double thickness; 
        private bool capturedRootMenu = false;

        public MainWindow()
        {
            InitializeComponent();
            colorPicker.Brush = new SolidColorBrush(Colors.Black);
            toolType = ToolType.Pen;
            color = colorPicker.Color;
            thickness = thicknessPicker.thicknessSlider.Value; 
        }



        private void penMenuItem_Click(object sender, RoutedEventArgs e)
        {
            toolType = ToolType.Pen; 
        }

        private void lineMenuItem_Click(object sender, RoutedEventArgs e)
        {
            toolType = ToolType.Line; 
        }

        private void drawCanvas_MouseMove(object sender, MouseEventArgs e)
        {


            switch (toolType)
            {
                case ToolType.Pen:

                    if (e.LeftButton == MouseButtonState.Pressed)
                    {
                        EllipseBuilder.createPenEllipse(thickness, color, drawCanvas, e);
                        LineBuilder.createLine(thickness, color, drawCanvas, e, ref capturedRootMenu);
                    }
                    return;
                case ToolType.Line:

                    if (e.LeftButton == MouseButtonState.Pressed)
                    {
                        LineBuilder.createStraightLine(thickness, color, drawCanvas, e, ref capturedRootMenu);
                    }
                    return;

            }
        }

        private void drawCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (toolType)
            {
                case ToolType.Pen:
                    EllipseBuilder.createPenEllipse(thickness, color, drawCanvas, e);
                    LineBuilder.SetCurrentPosition(drawCanvas, e);
                    return;
                case ToolType.Line:
                    LineBuilder.SetCurrentPosition(drawCanvas, e);
                    return; 

            }

        }

        private void undoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            drawCanvas.Children.Clear();
        }

        private void rootMenu_GotMouseCapture(object sender, MouseEventArgs e)
        {
            capturedRootMenu = true;
        }

        private void openMenuItem_Click(object sender, RoutedEventArgs e)
        {
            FileBuilder.openFile(drawCanvas);
        }

        private void saveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            FileBuilder.saveFile(drawCanvas);
        }

    

        private void colorPicker_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            color = colorPicker.Color;
            thicknessPicker.setColor(color);
        }

        

        private void thicknessPicker_LostMouseCapture(object sender, MouseEventArgs e)
        {
            thickness = thicknessPicker.thicknessSlider.Value;
            
        }

        
    }
}
