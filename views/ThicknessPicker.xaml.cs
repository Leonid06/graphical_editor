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
    public partial class ThicknessPicker : UserControl
    {
        private Color color; 
        
        public ThicknessPicker()
        {
            InitializeComponent();
            EllipseBuilder.createDemoEllipse(thicknessSlider.Value, thicknessCanvas, color);
        }

        private void thicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            thicknessCanvas.Children.Clear();
            EllipseBuilder.createDemoEllipse(thicknessSlider.Value,thicknessCanvas , color); 
        }



        public void setColor(Color color)
        {
            this.color = color;
            EllipseBuilder.createDemoEllipse(thicknessSlider.Value, thicknessCanvas, color);
        }

      
    }
}
