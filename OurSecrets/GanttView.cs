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
    public class GanttView
    {
        const int HOUR_MIN_WIDTH = 150;
        const int HOUR_HEIGHT = 90;
        const int LINE_PADDING = 5;
        const int LINE_MAX_NUMBER = 6;
        const int TIME_HEIGHT = 30;
        const int TIME_VERTICAL_THICHNESS = 1;
        const int TIME_HORIZONTAL_THICHNESS = 2;

        ScrollViewer _mainScrollViewer;
        ScrollViewer _timeScrollViewer;
        Canvas _mainCanvas;
        Canvas _timeCanvas;
        List<GridView> _timeList;
        int _collisionCount = 0;
        double _hourWidth = 100;
        
        //List<Agenda> _agendaList;

        //GanttView
        public GanttView(ScrollViewer scrollViewer)
        {
            _mainScrollViewer = (scrollViewer.Content as StackPanel).Children[0] as ScrollViewer;
            _timeScrollViewer = (scrollViewer.Content as StackPanel).Children[1] as ScrollViewer;
            InitialScrollViews();

            InitialTimeBlock();

            //_agendaList = new List<Agenda>();
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 1:00"), DateTime.Parse("12/29/2012 3:00")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 2:00"), DateTime.Parse("12/29/2012 5:00")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 4:00"), DateTime.Parse("12/29/2012 7:00")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00"), DateTime.Parse("12/29/2012 9:00")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 6:00")));

            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 12:15"), DateTime.Parse("12/29/2012 13:15")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 12:20"), DateTime.Parse("12/29/2012 16:15")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 17:15"), DateTime.Parse("12/29/2012 17:20")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 18:20"), DateTime.Parse("12/29/2012 18:50")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 20:00"), DateTime.Parse("12/29/2012 22:15")));
            //_agendaList.Add(new Agenda(DateTime.Parse("12/29/2012 23:15"), DateTime.Parse("12/29/2012 23:50")));

            Paint(App.AgendasModel.GetAgendaList());
        }

        //InitialScrollView
        private void InitialScrollViews()
        {
            _mainCanvas = new Canvas();
            _mainScrollViewer.Height = (HOUR_HEIGHT + LINE_PADDING) * LINE_MAX_NUMBER + LINE_PADDING;
            _mainScrollViewer.Content = _mainCanvas;

            _timeCanvas = new Canvas();
            _timeScrollViewer.Height = TIME_HEIGHT;
            _timeScrollViewer.Content = _timeCanvas;
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
                    textBlock.Margin = new Thickness(-20, -15, 0, 0);
                    gridView.Items.Add(textBlock);
                    _timeList.Add(gridView);
                }
            }
            for (int i = 0; i < 24; i++)
            {
                GridView item = _timeList[i];
                item.Width = HourWidth;
                item.Height = TIME_HEIGHT;
                item.Margin = new Thickness(HourWidth * i, 0, 0, 0);
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

        public double TotalHeight
        {
            get
            {
                return (HOUR_HEIGHT + LINE_PADDING) * LINE_MAX_NUMBER + LINE_PADDING + TIME_HEIGHT;
            }
        }

        //InitialCanvas
        private void InitialCanvas()
        {
            int linesNum = _collisionCount <= LINE_MAX_NUMBER ? LINE_MAX_NUMBER : _collisionCount;

            _mainCanvas.Width = 24 * HourWidth;
            _mainCanvas.Height = (HOUR_HEIGHT + LINE_PADDING) * linesNum + LINE_PADDING;
            _mainCanvas.Children.Clear();

            _timeCanvas.Width = 24 * HourWidth;
            _timeCanvas.Height = TIME_HEIGHT;
            _timeCanvas.Children.Clear();
        }

        //Paint
        public void Paint(List<Agenda> agendaList)
        {
            List<StackPanel> frameList = InitialAgendaGridViewList(agendaList);
            InitialCanvas();
            InitialTimeBlock();
            for (int i = 0; i < frameList.Count; i++)
            {
                _mainCanvas.Children.Add(frameList[i]);
            }
            for (int i = 0; i < 24; i++)
            {
                _timeCanvas.Children.Add(_timeList[i]);
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
        private List<StackPanel> InitialAgendaGridViewList(List<Agenda> agendaList)
        {
            List<StackPanel> gridViewList = new List<StackPanel>();
            for (int i = 0; i < agendaList.Count; i++)
            {
                int collisionCount = 1;
                //GridView gridView = CreateGridView(Colors.DarkGreen);
                double startHourMin = GetHourMin(agendaList[i].StartDateTime);
                double endHourMin = GetHourMin(agendaList[i].EndDateTime);
                double width = (endHourMin - startHourMin) / 60.0 * HourWidth;
                double height;
                double left = startHourMin / 60.0 * HourWidth;
                double top = LINE_PADDING;
                for (int j = 0; j < i; j++)
                {
                    StackPanel iGridView = gridViewList[j];
                    double iLeft = iGridView.Margin.Left;
                    double iRight = iLeft + iGridView.Width;
                    if (top == iGridView.Margin.Top && iLeft <= left && left <= iRight)
                    {
                        top += HOUR_HEIGHT + LINE_PADDING;
                        collisionCount++;
                        j = 0;
                    }
                }
                if (_collisionCount < collisionCount)
                {
                    _collisionCount = collisionCount;
                }
                UILayout uiLayout = new UILayout();
                width = width >= HOUR_MIN_WIDTH ? width : HOUR_MIN_WIDTH;
                height = HOUR_HEIGHT;
                StackPanel stackPanel = uiLayout.GetMode_B_StackPanel(width, height, left, top, startHourMin, endHourMin, agendaList[i].Title);
                stackPanel.PointerPressed += OnPointerPressed;
                stackPanel.Tag = agendaList[i];
                gridViewList.Add(stackPanel);
            }
            return gridViewList;
        }

        private void OnPointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            StackPanel stackPanel = (StackPanel)sender;
            Agenda agenda = (Agenda)stackPanel.Tag;
            App.MyEditAgendaPage.SetEditState(agenda);


            App.MyEditAgendaPage.SetPreviousPage(App.MyGanttPage);
            Window.Current.Content = App.MyEditAgendaPage;

            //((TextBlock)stackPanel.Children[0]).Text += "AA"; // Time ~ Time
            //((TextBlock)stackPanel.Children[1]).Text += "BB"; // Title
        }

        //GetHourMin
        private double GetHourMin(DateTime? dateTime)
        {
            int hour = dateTime.Value.Hour;
            int min = dateTime.Value.Minute;
            return (double)hour*60 + (double)min;
        }
    }
}
