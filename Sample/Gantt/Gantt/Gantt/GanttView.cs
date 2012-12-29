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
        const int HOUR_MIN_WIDTH = 100;
        const int HOUR_HEIGHT = 50;
        const int LINE_PADDING = 30;
        const int TIME_LINE_NUMBER = 4;
        const int TIME_HEIGHT = 30;
        const int TIME_VERTICAL_THICHNESS = 1;
        const int TIME_HORIZONTAL_THICHNESS = 2;

        Canvas _canvas;
        List<GridView> _timeList;
        double _hourWidth = 100;

        List<Agenda> _agendaList;

        //GanttView
        public GanttView(Canvas canvas)
        {
            _canvas = canvas;
            _agendaList = new List<Agenda>();
            _agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 1:00"), DateTime.Parse("12/29/2012 3:00")));
            _agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 2:00"), DateTime.Parse("12/29/2012 5:00")));
            _agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 4:00"), DateTime.Parse("12/29/2012 7:00")));
            _agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00"), DateTime.Parse("12/29/2012 9:00")));
            _agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00")));
            _agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00")));
            _agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00")));
            _agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00")));
            _agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00")));
            _agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00")));

            _agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 12:15"), DateTime.Parse("12/29/2012 13:15")));
            _agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 12:20"), DateTime.Parse("12/29/2012 16:15")));
            _agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 17:15"), DateTime.Parse("12/29/2012 17:20")));
            _agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 18:20"), DateTime.Parse("12/29/2012 18:50")));
            _agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 20:00"), DateTime.Parse("12/29/2012 22:15")));
            _agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 23:15"), DateTime.Parse("12/29/2012 23:50")));

            Paint(_agendaList);
        }

        //InitialTimeBlock
        private void InitialTimeBlock()
        {
            if (_timeList == null)
            {
                _timeList = new List<GridView>();
                for (int i = 0; i < 24; i++)
                { 
                    GridView gridView = CreateGridView(Colors.Transparent);
                    gridView.BorderBrush = new SolidColorBrush(Colors.DimGray);
                    gridView.BorderThickness = new Thickness(TIME_VERTICAL_THICHNESS, 0, 0, TIME_HORIZONTAL_THICHNESS);
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = i.ToString();
                    gridView.Items.Add(textBlock);
                    _timeList.Add(gridView);
                }
            }
            for (int i = 0; i < 24; i++)
            {
                GridView item = _timeList[i];
                item.Width = HourWidth;
                item.Height = TIME_HEIGHT;
                item.Margin = new Thickness(HourWidth * i, (TIME_LINE_NUMBER - 1) * (HOUR_HEIGHT + LINE_PADDING) + LINE_PADDING, 0, 0);
            }
        }

        //HourWidth
        public double HourWidth
        {
            get
            {
                return _hourWidth;
            }
            set 
            {
                _hourWidth = value;
            }
        }

        //InitialCanvas
        private void InitialCanvas()
        {
            _canvas.Width = 24 * HourWidth;
            _canvas.Height = (HOUR_HEIGHT + LINE_PADDING) * 6 + (TIME_HEIGHT + LINE_PADDING) + LINE_PADDING;
            _canvas.Children.Clear();
        }

        //Paint
        public void Paint(List<Agenda> agendaList)
        {
            InitialCanvas();
            InitialTimeBlock();
            List<GridView> frameList = InitialAgendaGridViewList(agendaList);
            for (int i = 0; i < frameList.Count; i++)
            {
                _canvas.Children.Add(frameList[i]);
            }
            for (int i = 0; i < 24; i++)
            {
                _canvas.Children.Add(_timeList[i]);
            }
        }

        //CreateItem
        private GridView CreateGridView(Color color)
        {
            GridView gridView = new GridView();
            Random rand = new Random();
            gridView.IsEnabled = false;
            gridView.Padding = new Thickness(0);
            gridView.Background = new SolidColorBrush(color);
            gridView.AllowDrop = true;
            return gridView;
        }

        //InitialAgendaGridViewList
        private List<GridView> InitialAgendaGridViewList(List<Agenda> agendaList)
        {
            List<GridView> gridViewList = new List<GridView>();
            for (int i = 0; i < agendaList.Count; i++)
            {
                GridView gridView = CreateGridView(Colors.DarkGreen);
                double startHourMin = GetHourMin(agendaList[i].StartDateTime);
                double endHourMin = GetHourMin(agendaList[i].EndDateTime);
                double width = (endHourMin - startHourMin) * HourWidth;
                double left = startHourMin * HourWidth;
                double top = LINE_PADDING;
                gridView.Width = width >= HOUR_MIN_WIDTH ? width : HOUR_MIN_WIDTH;
                gridView.Height = HOUR_HEIGHT;
                for (int j = 0; j < i; j++)
                {
                    GridView iGridView = gridViewList[j];
                    double iLeft = iGridView.Margin.Left;
                    double iRight = iLeft + iGridView.Width;
                    if (top == iGridView.Margin.Top && iLeft <= left && left <= iRight)
                    {
                        if (top == LINE_PADDING + (HOUR_HEIGHT + LINE_PADDING) * (TIME_LINE_NUMBER - 2))
                        {
                            top += TIME_HEIGHT + LINE_PADDING;
                        }
                        top += HOUR_HEIGHT + LINE_PADDING;
                        j = 0;
                    }
                }
                gridView.Margin = new Thickness(left, top, 0, 0);
                gridViewList.Add(gridView);
            }
            return gridViewList;
        }

        //GetHourMin
        private double GetHourMin(DateTime? dateTime)
        {
            int hour = dateTime.Value.Hour;
            int min = dateTime.Value.Minute;
            return (double)hour + (double)min / (double)60;
        }
    }
}
