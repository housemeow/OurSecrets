using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Gantt
{
    public class GanttView
    {
        Canvas _canvas;

        //GanttView
        public GanttView(Canvas canvas)
        {
            canvas.Width = 5000;
            canvas.Height = 500;
            _canvas = canvas;
            /*
            itemsControl.Items.Add(_canvas);
            */
            _canvas.Children.Add(CreateItem());
            //_canvas.Children.Add(CreateItem());
            //_canvas.Children.Add(CreateItem());
        }

        //CreateItem
        private Rectangle CreateItem()
        {
            Rectangle myRectangle = new Rectangle();
            Random rand = new Random();
            myRectangle.Fill = new SolidColorBrush(Color.FromArgb(255,
                 (byte)rand.Next(0, 255), (byte)rand.Next(0, 255), (byte)rand.Next(0, 255)));
            myRectangle.Width = 100;
            myRectangle.Height = 100;
            myRectangle.AllowDrop = true;
            myRectangle.Margin = new Thickness(10,10,0,0);

            return myRectangle;
        }
    }
}
