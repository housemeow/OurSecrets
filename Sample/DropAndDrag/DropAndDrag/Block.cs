using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace DropAndDrag
{
    public class Block
    {
        Image _image;
        Thickness _thickness;

        public Block()
        {
            _image = new Image();
            _image.Source = new BitmapImage(new Uri("ms-appx:/Assets/test.png"));
            _image.Height = 160;
            _image.Width = 100;
            _thickness = new Thickness(0, 0, 0, 0);
            _image.Margin = _thickness;
        }

        public double X
        {
            get
            {
                return _image.Margin.Left;
            }
            set
            {
                _thickness.Left = value;
                _image.Margin = _thickness;
            }
        }

        public double Y
        {
            get
            {
                return _image.Margin.Top;
            }
            set
            {
                _thickness.Top = value;
                _image.Margin = _thickness;
            }
        }

        public Image Image
        {
            get
            {
                return _image;
            }
        }

        public bool IsInBlock(Point point)
        {
            double top = Y;
            double left = X;
            double right = left + _image.Width;
            double bottom = top + _image.Height;
            if (point.X >= top && point.X <= bottom && point.Y >= left && point.Y <= right)
                return true;
            else
                return false;
        }
    }
}
