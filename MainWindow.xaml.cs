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
    
    public partial class MainWindow : Window
    {
        DrawMode mode;
        Thickness thickness;
        StrokeColor color; 

        enum StrokeColor
        {
            Black, Red, Blue, Yellow, Green
        }

        enum  DrawMode
        {
             Ellipse, Pen, Pencil
        }

        enum Thickness
        {
            SMALL, MEDIUM , BIG 
        }


        public MainWindow()
        {
            mode = DrawMode.Pen; 
            InitializeComponent();
        }

        
        


    }
}
