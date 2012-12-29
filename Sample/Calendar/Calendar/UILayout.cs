using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Calendar
{
    public class UILayout
    {
        static Color[] colors = { Colors.AliceBlue, Colors.Cornsilk, Colors.ForestGreen, Colors.MediumSeaGreen, 
                                  Colors.MediumVioletRed, Colors.Salmon, Colors.OldLace, Colors.Pink, Colors.RoyalBlue, Colors.Tomato};
        static Random random = new Random();

        //UI
        SolidColorBrush _solidColorBrush;
        StackPanel _stackPanel;
        TextBlock ModeA_TextBlock;
        TextBlock ModeB_TextBlock_Date;
        TextBlock ModeB_TextBlock_Title;

        public UILayout()
        {
            _solidColorBrush = new SolidColorBrush(colors[random.Next(0, colors.Length - 1)]);
            _stackPanel = new StackPanel();

            //ModeA
            ModeA_TextBlock = new TextBlock();
            
            //ModeB
            ModeB_TextBlock_Date = new TextBlock();
            ModeB_TextBlock_Title = new TextBlock();
        }

        private void InitialStackPanel(int width, int height, int thickness)
        {
            _stackPanel.Margin = new Windows.UI.Xaml.Thickness(thickness);
            _stackPanel.Width = width;
            _stackPanel.Height = height;
            _stackPanel.Background = _solidColorBrush;
            _stackPanel.Children.Clear();
        }

        public StackPanel GetMode_A_StackPanel(int width, int height, int thickness, int month, int day, string showString = null)
        {
            InitialStackPanel(width, height, thickness);

            ModeA_TextBlock.Text = showString == null ? month + "/" + day : showString;
            ModeA_TextBlock.Width = width;
            ModeA_TextBlock.Height = height;
            ModeA_TextBlock.FontSize = 25;
            ModeA_TextBlock.Margin = new Windows.UI.Xaml.Thickness(0, 30, 0, 0);
            ModeA_TextBlock.Foreground = new SolidColorBrush(Colors.Black);
            ModeA_TextBlock.TextAlignment = Windows.UI.Xaml.TextAlignment.Center;

            _stackPanel.Children.Add(ModeA_TextBlock);
            return _stackPanel;
        }

        public StackPanel GetMode_B_StackPanel(int width, int height, int thickness, int hour, int min, string title)
        {
            InitialStackPanel(width, height, thickness);

            ModeB_TextBlock_Date.Text = hour + "~" + min;
            ModeB_TextBlock_Date.Width = width;
            ModeB_TextBlock_Date.Height = height / 2;
            ModeB_TextBlock_Date.FontSize = 25;
            ModeB_TextBlock_Date.Margin = new Windows.UI.Xaml.Thickness(0, 30, 0, 0);
            ModeB_TextBlock_Date.Foreground = new SolidColorBrush(Colors.Black);
            ModeB_TextBlock_Date.TextAlignment = Windows.UI.Xaml.TextAlignment.Center;

            ModeB_TextBlock_Title.Text = title;
            ModeB_TextBlock_Title.Width = width;
            ModeB_TextBlock_Title.Height = height / 2;
            ModeB_TextBlock_Title.FontSize = 25;
            ModeB_TextBlock_Title.Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 0);
            ModeB_TextBlock_Title.Foreground = new SolidColorBrush(Colors.Black);
            ModeB_TextBlock_Title.TextAlignment = Windows.UI.Xaml.TextAlignment.Center;

            _stackPanel.Children.Add(ModeB_TextBlock_Date);
            _stackPanel.Children.Add(ModeB_TextBlock_Title);
            return _stackPanel;
        }

        public Color SolidColorBrush
        {
            set
            {
                _solidColorBrush = new SolidColorBrush(value);
            }
        }
    }
}
