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
using OurSecrets;

namespace OurSecrets
{
    public class CalenderView
    {
        const int BLOCK_HEIGHT = 80;
        const int BLOCK_WIDTH = 150;
        const int BLOCK_THICKNESS = 5;
        ItemsControl _itemsConrol;

        //CalenderView
        public CalenderView(ItemsControl itemsConrol)
        {
            itemsConrol.Height = (BLOCK_HEIGHT + 2 * BLOCK_THICKNESS) * 7;
            itemsConrol.Width = (BLOCK_WIDTH + 2 * BLOCK_THICKNESS) * 7;
            _itemsConrol = itemsConrol;
        }

        //Paint
        public void Paint(int year, int month, int day = -1)
        {
            int lastMonthWeek;
            int lastMonthDays;
            int nowMonthWeek;
            int nowMonthDays;
            int nextMonthWeek;
            int nextMonthDays;
            WeekAndDays(out lastMonthWeek, out lastMonthDays, year, month - 1);
            WeekAndDays(out nowMonthWeek, out nowMonthDays, year, month);
            WeekAndDays(out nextMonthWeek, out nextMonthDays, year, month + 1);

            int count = 0;
            for (int i = 0; i < 7; i++)
            { 
                _itemsConrol.Items.Add(CreateStackPanel(((DayOfWeek)i).ToString(), WeekColor(-1)));
            }
            for (int i = 1; i <= nowMonthWeek; i++)
            {
                _itemsConrol.Items.Add(CreateStackPanel(month - 1 < 1 ? month - 1 + 12 : month - 1, lastMonthDays - nowMonthWeek + i, WeekColor(7)));
                count = (count + 1) % 7;
            }
            for (int i = 1; i <= nowMonthDays; i++)
            {
                _itemsConrol.Items.Add(CreateStackPanel(month, i, WeekColor(count)));
                count = (count + 1) % 7;
            }
            for (int i = 1; i <= 7 - nextMonthWeek; i++)
            {
                _itemsConrol.Items.Add(CreateStackPanel(month + 1 > 12 ? month + 1 - 12 : month + 1, i, WeekColor(7)));
                count = (count + 1) % 7;
            }
        }

        public Color WeekColor(int week)
        {
            if (week < 0)
            {
                return Colors.YellowGreen;
            }
            else if (week > 6)
            {
                return Colors.Gray;
            }
            else if (week == 0 || week == 6)
            {
                return Colors.PaleVioletRed;
            }
            else
            {
                return Colors.LightSteelBlue;
            }
        }

        //WeekAndDays
        public void WeekAndDays(out int week, out int days, int year, int month)
        {
            DateTime dateTime;

            if (month > 12)
            {
                WeekAndDays(out week, out days, year + 1, month - 12);
                return;
            }
            if (month < 1)
            {
                WeekAndDays(out week, out days, year - 1, month + 12);
                return;
            }
            dateTime = new DateTime(year, month, 1);
            week = (int)dateTime.DayOfWeek;
            days = DateTime.DaysInMonth(year, month);
        }

        //CreateTextBlock
        private TextBlock CreateTextBlock(string showText)
        {
            TextBlock myTextBlock = new TextBlock();
            Random rand = new Random();
            myTextBlock.Width = BLOCK_WIDTH;
            myTextBlock.Height = BLOCK_HEIGHT;
            myTextBlock.Margin = new Thickness(BLOCK_THICKNESS);
            myTextBlock.Text = showText;
            myTextBlock.TextAlignment = TextAlignment.Center;
            return myTextBlock;
        }

        //CreateTextBlock
        private StackPanel CreateStackPanel(string showText, Color color)
        {
            UILayout uiLayout = new UILayout();
            uiLayout.SolidColorBrush = color;
            return uiLayout.GetMode_A_StackPanel(BLOCK_WIDTH, BLOCK_HEIGHT, BLOCK_THICKNESS, 0, 0, showText);
        }

        //CreateTextBlock
        private StackPanel CreateStackPanel(int month, int day, Color color)
        {
            UILayout uiLayout = new UILayout();
            uiLayout.SolidColorBrush = color;
            StackPanel stackPanel = uiLayout.GetMode_A_StackPanel(BLOCK_WIDTH, BLOCK_HEIGHT, BLOCK_THICKNESS, month, day);
            stackPanel.PointerPressed += OnPointerPressed;
            return stackPanel;
        }

        private void OnPointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            
        }
    }
}
