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
        private LineBuilder lineBuilder;
        private EllipseBuilder ellipseBuilder; 
        private ToolType toolType;
        private Color color; 
        private double thickness; 
        private bool capturedRootMenu = false;
        private Cursor eraserCursor = new Cursor("C:/Users/User/source/repos/graphical_editor/resources/eraser_cursor.cur"); 

        public MainWindow()
        {
            InitializeComponent();
            colorPicker.Brush = new SolidColorBrush(Colors.Black);
            toolType = ToolType.Pen;
            color = colorPicker.Color;
            thickness = thicknessPicker.thicknessSlider.Value;
            textBuilder = new TextBuilder();
            lineBuilder = new LineBuilder();
            ellipseBuilder = new EllipseBuilder();
            setUpListeners();
        }

        private void setUpListeners()
        {
            penMenuItem.Click += onPenMenuItemClick;
            lineMenuItem.Click += onLineMenuItemClick;
            eraserMenuItem.Click += onEraserMenuItemClick;
            textMenuItem.Click += onTextMenuItemClick;
            undoMenuItem.Click += onUndoMenuItemClick;
            openMenuItem.Click += onOpenMenuItemClick;
            saveMenuItem.Click += onSaveMenuItemClick; 

            canvas.MouseMove += onCanvasMouseMove;
            canvas.MouseLeftButtonDown += onCanvasMouseLeftButtonDown;

            rootMenu.GotMouseCapture += onRootMenuGotMouseCapture;
            colorPicker.ColorChanged += onColorPickerColorChanged;
            thicknessPicker.LostMouseCapture += onThicknessPickerLostMouseCapture;

            mainWindow.SizeChanged += onMainWindowSizeChanged;



        }



        private void onPenMenuItemClick(object sender, RoutedEventArgs e)
        {
            toolType = ToolType.Pen;
            canvas.Cursor = Cursors.Pen;

        }

        private void onLineMenuItemClick(object sender, RoutedEventArgs e)
        {
            toolType = ToolType.Line;
            canvas.Cursor = Cursors.Pen;

        }

        private void onEraserMenuItemClick(object sender, RoutedEventArgs e)
        {
            toolType = ToolType.Eraser;
            canvas.Cursor = eraserCursor;
        }

        private void onTextMenuItemClick(object sender, RoutedEventArgs e)
        {
            toolType = ToolType.Text;
            canvas.Cursor = Cursors.SizeAll;
        }
        private void onUndoMenuItemClick(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            canvas.Background = new SolidColorBrush(Colors.White);
        }

        private void onOpenMenuItemClick(object sender, RoutedEventArgs e)
        {
            FileBuilder.openFile(canvas);
        }

        private void onSaveMenuItemClick(object sender, RoutedEventArgs e)
        {
            FileBuilder.saveFile(canvas);
        }


        private void onCanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                switch (toolType)
                {

                    case ToolType.Line:

                        lineBuilder.createStraightLine(thickness, color, canvas, e);

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

                    default:
                        ellipseBuilder.createPenEllipse(thickness, color, canvas, toolType, e);
                        lineBuilder.createLine(thickness, color, canvas, e, toolType, ref capturedRootMenu);

                        return;


                }

            }

        }

        private void onCanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (toolType)
            {
                case ToolType.Line:
                    lineBuilder.SetCurrentPosition(canvas, e);
                    return;
                case ToolType.Text:

                    textBuilder.createText(thickness, canvas, color, e);
                    return;


                default:

                    ellipseBuilder.createPenEllipse(thickness, color, canvas, toolType, e);
                    lineBuilder.SetCurrentPosition(canvas, e);
                    return;

            }

        }

        
        private void onRootMenuGotMouseCapture(object sender, MouseEventArgs e)
        {
            capturedRootMenu = true;
        }

        

    

        private void onColorPickerColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            color = colorPicker.Color;
            thicknessPicker.setColor(color);
        }

        

        private void onThicknessPickerLostMouseCapture(object sender, MouseEventArgs e)
        {
            thickness = thicknessPicker.thicknessSlider.Value;
            
        }

        private void onMainWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            canvas.Height = this.Height - rootMenu.Height;
            canvas.Width = this.Width; 
        }

    }
}
