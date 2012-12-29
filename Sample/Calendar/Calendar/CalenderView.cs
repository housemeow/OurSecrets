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

namespace Calendar
{
    public class CalenderView
    {
        const int BLOCK_HEIGHT = 100;
        const int BLOCK_WIDTH = 100;
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

            for (int i = 0; i < 7; i++)
            { 
                _itemsConrol.Items.Add(CreateTextBlock(((DayOfWeek)i).ToString()));
            }
            for (int i = 1; i <= nowMonthWeek; i++)
            {
                _itemsConrol.Items.Add(CreateTextBlock((lastMonthDays - nowMonthWeek + i).ToString()));
            }
            for (int i = 1; i <= nowMonthDays; i++)
            {
                _itemsConrol.Items.Add(CreateTextBlock(i.ToString()));
            }
            for (int i = 1; i <= 7 - nextMonthWeek; i++)
            {
                _itemsConrol.Items.Add(CreateTextBlock(i.ToString()));
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
    }
}
