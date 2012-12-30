using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using OurSecrets;

// 空白頁項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234238

namespace OurSecrets
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class GanttPage : Page
    {
        public GanttView GantView;

        public GanttPage()
        {
            this.InitializeComponent();
            GantView = new GanttView(_srollViewer);
            App.AgendasModel.PropertyChanged += AgendasModel_PropertyChanged;
            Window.Current.CoreWindow.PointerWheelChanged += new TypedEventHandler<Windows.UI.Core.CoreWindow, Windows.UI.Core.PointerEventArgs>(ChangedCoreWindowPointerWheel);
        }

        public void RePaint()
        {
            if (GantView != null)
            {
                //DateTimeSorter sorter = new DateTimeSorter();
                //List<Agenda> agneda = sorter.Sort(App.AgendasModel.GetAgendaList(_gantView.DateTime));
                //_gantView.PaintGantt(agneda);

                GantView.PaintGantt(App.AgendasModel.GetAgendaList(GantView.DateTime));
            }
        }

        void AgendasModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //DateTimeSorter sorter = new DateTimeSorter();
            //List<Agenda> agneda = sorter.Sort(App.AgendasModel.GetAgendaList(_gantView.DateTime));
            //_gantView.PaintGantt(agneda);

            GantView.PaintGantt(App.AgendasModel.GetAgendaList(GantView.DateTime));
        }

        //ChangedCoreWindowPointerWheel
        private void ChangedCoreWindowPointerWheel(object sender, Windows.UI.Core.PointerEventArgs args)
        {
            Windows.UI.Input.PointerPoint currentPoint = args.CurrentPoint;
            double mouseWheelDelta = currentPoint.Properties.MouseWheelDelta;
            if (currentPoint.Position.Y <= GantView.TotalHeight)
            {
                if (args.KeyModifiers == Windows.System.VirtualKeyModifiers.None)
                {
                    double horizontalOffset = ((_srollViewer.Content as StackPanel).Children[0] as ScrollViewer).HorizontalOffset;
                    horizontalOffset -= mouseWheelDelta;
                    ((_srollViewer.Content as StackPanel).Children[0] as ScrollViewer).ScrollToHorizontalOffset(horizontalOffset);
                    ((_srollViewer.Content as StackPanel).Children[1] as ScrollViewer).ScrollToHorizontalOffset(horizontalOffset);
                }
                else if (args.KeyModifiers == Windows.System.VirtualKeyModifiers.Control)
                {
                    double verticalOffset = ((_srollViewer.Content as StackPanel).Children[0] as ScrollViewer).VerticalOffset;
                    verticalOffset -= mouseWheelDelta;
                    ((_srollViewer.Content as StackPanel).Children[0] as ScrollViewer).ScrollToVerticalOffset(verticalOffset);
                }
            }
        }

        /// <summary>
        /// 在此頁面即將顯示在框架中時叫用。
        /// </summary>
        /// <param name="e">描述如何到達此頁面的事件資料。Parameter
        /// 屬性通常用來設定頁面。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void ChangedSliderValue(object sender, RangeBaseValueChangedEventArgs e)
        {
            /*
            if (_gantView != null)
            {
                double horizontalOffset = _srollViewer.HorizontalOffset;
                horizontalOffset += 100;
                horizontalOffset = horizontalOffset / e.OldValue * e.NewValue;
                horizontalOffset -= 100;
                _gantView.HourWidth = e.NewValue;
                _srollViewer.ScrollToHorizontalOffset(horizontalOffset);
            }*/
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = App.MyMainPage;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void SwithchFree(object sender, RoutedEventArgs e)
        {
        }

        private void GoToDay(object sender, RoutedEventArgs e)
        {

            Window.Current.Content = App.DailyPage;
        }
        private void GoCalendar(object sender, RoutedEventArgs e)
        {

            App.DailyPage.Refresh();
            Window.Current.Content = App.MyMainPage;
        }

        internal void SetText(DateTime dateTime)
        {
            _textBoxDate.Text = dateTime.ToString("MM/dd/yyyy");
        }
    }
}
