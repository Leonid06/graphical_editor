using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace graphical_editor.element_builders
{
    static internal class FileBuilder
    {
        static public void openFile(Canvas canvas)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "All files (.)|.|PNG Photos (.png)|.png|Text files (.txt)|.txt";

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
                    canvas.Background = i;
                    return;
                }
            }
        }

        static public void saveFile(Canvas canvas)
        {
            SaveFileDialog saveimg = new SaveFileDialog();
            saveimg.DefaultExt = ".png";
            saveimg.Filter = "Image (.png)|*.png";
            saveimg.FileName = "1";
            if (saveimg.ShowDialog() == true)
            {
                ToImageSource(canvas, saveimg.FileName); 
            }
        }

        public static void ToImageSource(Canvas canvas, string filename)
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
            using (FileStream file = File.Create(filename))
            {
                encoder.Save(file);
            }
        }
    }
}
