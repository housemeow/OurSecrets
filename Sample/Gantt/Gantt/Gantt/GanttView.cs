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
        const int HOUR_WIDTH = 100;
        const int HOUR_HEIGHT = 100;
        
        Canvas _canvas;

        //GanttView
        public GanttView(Canvas canvas)
        {
            canvas.Width = 5000;
            canvas.Height = 500;
            _canvas = canvas;
            _canvas.Children.Add(CreateFrame());
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

        //CreateItem
        private Frame CreateFrame()
        {
            Frame myFrame = new Frame();
            Random rand = new Random();
            myFrame.Background = new SolidColorBrush(Color.FromArgb(255,
                 (byte)rand.Next(0, 255), (byte)rand.Next(0, 255), (byte)rand.Next(0, 255)));
            myFrame.AllowDrop = true;
            return myFrame;
        }

        private List<Frame> InitialAgendaFrameList(List<Agenda> agendaList)
        {
            List<Frame> frameList = new List<Frame>();
            for(int i=0;i<agendaList.Count;i++)
            {
                Frame frame = CreateFrame();
                double startHourMin = GetHourMin(agendaList[i].StartDateTime);
                double endHourMin = GetHourMin(agendaList[i].EndDateTime);
                frame.Width = (endHourMin - startHourMin) * HOUR_WIDTH;
                frame.Height = HOUR_HEIGHT;
                frame.Margin = new Thickness(10, 10, 0, 0);
            }
            return frameList;
        }

        private double GetHourMin(DateTime? dateTime)
        {
            int hour = dateTime.Value.Hour;
            int min = dateTime.Value.Minute;
            return (double)hour + (double)min / (double)60;
        }
    }
}
