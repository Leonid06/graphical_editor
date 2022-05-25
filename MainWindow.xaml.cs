using graphical_editor.element_builders;
using System;
using System.IO;
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

        private void openMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            openFileDialog.Filter = "All files (.)|.|png Photos (.png)|.png|Text files (.txt)|.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);

                if (fileInfo.Extension.ToLower() == ".png")
                {
                    BitmapImage loadImage = new BitmapImage();
                    loadImage.BeginInit();
                    loadImage.UriSource = new Uri(fileInfo.FullName);
                    loadImage.EndInit();
                    ImageBrush i = new ImageBrush();
                    i.ImageSource = loadImage;
                    drawCanvas.Background = i;
                    return;
                }
            }
        }

        private void saveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveimg = new Microsoft.Win32.SaveFileDialog();
            saveimg.DefaultExt = ".png";
            saveimg.Filter = "Image (.png)|*.png";
            saveimg.FileName = "1";
            if (saveimg.ShowDialog() == true)
            {
                ToImageSource2(drawCanvas, saveimg.FileName);  //DragArena  - имя имеющегося канваса
            }
        }

        //private void ctrl_z_click(object sender, routedeventargs e)
        //{
        //    drawcanvas.children.removeat(drawcanvas.children.count - 1);
        //}

        public static void ToImageSource2(Canvas canvas, string filename)
        {

            canvas.LayoutTransform = null;  //обнуляем маштабировние если было


            //качество изображения
            double dpi = 300;
            double scale = dpi / 96;

            Size size = canvas.RenderSize;
            RenderTargetBitmap image = new RenderTargetBitmap((int)(size.Width * scale), (int)(size.Height * scale), dpi, dpi, PixelFormats.Pbgra32);
            canvas.Measure(size);
            canvas.Arrange(new Rect(size)); // This is important




            image.Render(canvas);
            PngBitmapEncoder encoder = new PngBitmapEncoder();  //конвертируем в png формат
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (System.IO.FileStream file = System.IO.File.Create(filename))
            {
                encoder.Save(file);
            }
        }

    }
}
