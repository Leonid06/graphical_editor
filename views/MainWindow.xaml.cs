﻿
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
            Rectangle,
            TextEditing
        }

        enum Thickness
        {
            SMALL, MEDIUM, BIG
        }

        public partial class MainWindow : Window
        {
            private TextBuilder textBuilder;
            private EllipseBuilder ellipseBuilder;
            private LineBuilder lineBuilder;
            private RectangleBuilder rectangleBuilder;
            private FileBuilder fileBuilder;

            private ToolType toolType;
            private Color color;
            private double thickness;
            private bool capturedRootMenu = false;
            private bool menuOn = true;
            //private Cursor eraserCursor = new Cursor("C:/Users/User/source/repos/graphical_editor/resources/eraser_cursor.cur"); 

            public MainWindow()
            {
                InitializeComponent();
                colorPicker.Brush = new SolidColorBrush(Colors.Black);
                toolType = ToolType.Pen;
                color = colorPicker.Color;
                thickness = thicknessPicker.thicknessSlider.Value;

                textBuilder = new TextBuilder();
                ellipseBuilder = new EllipseBuilder();
                lineBuilder = new LineBuilder();
                rectangleBuilder = new RectangleBuilder();
                fileBuilder = new FileBuilder();
            }



            private void penMenuItem_Click(object sender, RoutedEventArgs e)
            {
                toolType = ToolType.Pen;
                canvas.Cursor = Cursors.Pen;
                menuOn = true;
            }

            private void lineMenuItem_Click(object sender, RoutedEventArgs e)
            {
                toolType = ToolType.Line;
                canvas.Cursor = Cursors.Pen;
                menuOn = true;
            }

            private void eraserMenuItem_Click(object sender, RoutedEventArgs e)
            {
                toolType = ToolType.Eraser;
                menuOn = true;
                //canvas.Cursor = eraserCursor;
            }

            private void textMenuItem_Click(object sender, RoutedEventArgs e)
            {
                toolType = ToolType.Text;
                canvas.Cursor = Cursors.SizeAll;
                menuOn = true;
            }

            private void ellipseMenuItem_Click(object sender, RoutedEventArgs e)
            {
                toolType = ToolType.Ellipse;
                canvas.Cursor = Cursors.SizeAll;
                menuOn = true;
            }

            private void rectangleMenuItem_Click(object sender, RoutedEventArgs e)
            {
                toolType = ToolType.Rectangle;
                canvas.Cursor = Cursors.SizeAll;
                menuOn = true;
            }

            private void canvas_MouseMove(object sender, MouseEventArgs e)
            {
                if (menuOn)
                {
                    if (e.LeftButton == MouseButtonState.Pressed)
                    {
                        switch (toolType)
                        {

                            case ToolType.Line:

                                lineBuilder.createStraightLine(thickness, color, canvas, e, ref capturedRootMenu);

                                return;
                            case ToolType.Text:
                                textBuilder.createTextBox(thickness, canvas, e);
                                return;
                            case ToolType.Ellipse:
                                ellipseBuilder.createClassicEllipse(thickness, color, canvas, e, true);
                                return;
                            case ToolType.Rectangle:
                                rectangleBuilder.createRectangle(thickness, color, canvas, e);
                                return;

                            default:
                                ellipseBuilder.createPenEllipse(thickness, color, canvas, toolType, e);
                                lineBuilder.createLine(thickness, color, canvas, e, toolType, ref capturedRootMenu);
                                return;
                        }

                    }
                }

            }

            private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                if (menuOn)
                {
                    switch (toolType)
                    {
                        case ToolType.Line:
                            lineBuilder.SetCurrentPosition(canvas, e);
                            return;
                        case ToolType.Text:
                            //if (!textBuilder.isTextFocused())
                            //{
                            //    textBuilder.SetCurrentPosition(canvas, e);
                            //}
                            //else
                            //{
                            //    Keyboard.Focus(textBuilder.getText());
                            //}
                            return;
                        case ToolType.Ellipse:
                            ellipseBuilder.SetCurrentPosition(canvas, e);

                            return;
                        case ToolType.Rectangle:
                            rectangleBuilder.SetCurrentPosition(canvas, e);
                            return;
                        default:
                            ellipseBuilder.createPenEllipse(thickness, color, canvas, toolType, e);
                            lineBuilder.SetCurrentPosition(canvas, e);
                            return;

                    }
                }

            }



            private void undoMenuItem_Click(object sender, RoutedEventArgs e)
            {
                canvas.Children.Clear();
                canvas.Background = new SolidColorBrush(Colors.White);
                menuOn = true;
            }

            private void rootMenu_GotMouseCapture(object sender, MouseEventArgs e)
            {
                capturedRootMenu = true;
                menuOn = false;
            }

            private void openMenuItem_Click(object sender, RoutedEventArgs e)
            {
                fileBuilder.openFile(canvas);
                menuOn = true;
            }

            private void saveMenuItem_Click(object sender, RoutedEventArgs e)
            {
                fileBuilder.saveFile(canvas);
                menuOn = true;
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

            private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                lineBuilder.SetFigureNumZero();
                ellipseBuilder.SetFigureNumZero();
                rectangleBuilder.SetFigureNumZero();
                textBuilder.SetFigureNumZero();
                menuOn = true;
            }
        }
    }
