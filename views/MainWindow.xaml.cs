using graphical_editor.builders;
using graphical_editor.element_builders;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;


namespace graphical_editor
{
    enum ToolType 
    {
        Ellipse, 
        Pen, 
        Text, 
        Eraser,
        Line, 
        Rectangle
    }

    enum Thickness
    {
        SMALL, MEDIUM, BIG
    }

    public partial class MainWindow : Window
    {
        private TextBuilder textBuilder;
        private ToolType toolType;
        private Color color; 
        private double thickness; 
        private bool capturedRootMenu = false;
        //private Cursor eraserCursor = new Cursor("C:/Users/User/source/repos/graphical_editor/resources/eraser_cursor.cur"); 

        public MainWindow()
        {
            InitializeComponent();
            colorPicker.Brush = new SolidColorBrush(Colors.Black);
            toolType = ToolType.Pen;
            color = colorPicker.Color;
            thickness = thicknessPicker.thicknessSlider.Value;
            textBuilder = new TextBuilder();
        }



        private void penMenuItem_Click(object sender, RoutedEventArgs e)
        {
            toolType = ToolType.Pen;
            canvas.Cursor = Cursors.Pen;

        }

        private void lineMenuItem_Click(object sender, RoutedEventArgs e)
        {
            toolType = ToolType.Line;
            canvas.Cursor = Cursors.Pen;

        }

        private void eraserMenuItem_Click(object sender, RoutedEventArgs e)
        {
            toolType = ToolType.Eraser;
            //canvas.Cursor = eraserCursor;
        }

        private void textMenuItem_Click(object sender, RoutedEventArgs e)
        {
            toolType = ToolType.Text;
            canvas.Cursor = Cursors.SizeAll;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                switch (toolType)
                {

                    case ToolType.Line:

                        LineBuilder.createStraightLine(thickness, color, canvas, e, ref capturedRootMenu);

                        return;
                    case ToolType.Text:

                        if (!textBuilder.isFocused)
                        {
                            toolType = ToolType.Pen;
                            canvas.Cursor = Cursors.Pen;
                        }
                        else
                        {
                            toolType = ToolType.Text;
                            canvas.Cursor = Cursors.SizeAll; 
                        }
                      
                        return;
                    case ToolType.Ellipse:
                        EllipseBuilder.createDemoEllipse(thickness, color, canvas, e);
                        return;

                    default:
                        EllipseBuilder.createPenEllipse(thickness, color, canvas, toolType, e);
                        LineBuilder.createLine(thickness, color, canvas, e, toolType, ref capturedRootMenu);

                        return;


                }

            }
            
        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (toolType)
            {
                case ToolType.Line:
                    LineBuilder.SetCurrentPosition(canvas, e);
                    return;
                case ToolType.Text:

                    textBuilder.createText(thickness, canvas, color, e);
                    return;
                case ToolType.Ellipse:
                    EllipseBuilder.SetCurrentPosition(canvas, e);
                    return;

                default:

                    EllipseBuilder.createPenEllipse(thickness, color, canvas, toolType, e);
                    LineBuilder.SetCurrentPosition(canvas, e);
                    return;

            }

        }

        private void undoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            canvas.Background = new SolidColorBrush(Colors.White); 
        }

        private void rootMenu_GotMouseCapture(object sender, MouseEventArgs e)
        {
            capturedRootMenu = true;
        }

        private void openMenuItem_Click(object sender, RoutedEventArgs e)
        {
            FileBuilder.openFile(canvas);
        }

        private void saveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            FileBuilder.saveFile(canvas);
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

        private void mainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            canvas.Height = this.Height - rootMenu.Height;
            canvas.Width = this.Width; 
        }

    }
}
