using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using OurSecrets;

// 空白頁項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234238

namespace OurSecrets
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class DailyPage : Page
    {
        public DailyPage()
        {
            this.InitializeComponent();
            GridView[] DayViews = { FirstDay, SecondDay, ThirdDay, AgendaList };
            foreach (GridView Day in DayViews)
            {
                Day.Drop += View_Drop;
                Day.DragItemsStarting += View_DragItemsStarting;
            }
            AddView.DragItemsStarting += View_DragItemsStarting;
            Window.Current.CoreWindow.PointerWheelChanged += CoreWindow_PointerWheelChanged;
            //Window.Current.CoreWindow.PointerPressed += CoreWindow_PointerPressed;
        }

        void CoreWindow_PointerPressed(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.PointerEventArgs args)
        {
            if (args.CurrentPoint.Properties.IsRightButtonPressed)
            {
                BottomAppBar.IsOpen = !BottomAppBar.IsOpen;
            }
        }

        void CoreWindow_PointerWheelChanged(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.PointerEventArgs args)
        {
            if (args.KeyModifiers != Windows.System.VirtualKeyModifiers.Control) return;
            if (args.CurrentPoint.Properties.MouseWheelDelta < 0)
            {
                //下一日
            }
            else
            {
                //上一日
            }
        }

        void View_Drop(object sender, DragEventArgs e)
        {
            GridView[] DayViews = { FirstDay, SecondDay, ThirdDay ,AgendaList};
            GridView[] ItemSources = { FirstDay, SecondDay, ThirdDay, AddView, AgendaList };
            int index = -1;
            foreach (GridView Day in DayViews)
            {
                //放置的VIEW
                if (sender.Equals(Day))
                {
                    //放置的位置
                    index = Day.Items.IndexOf(rect);
                    //拖曳的ITEM
                    for (int i = DragItems.Count - 1; i >= 0; i--)
                    {
                        //拖曳的ITEM來源VIEW
                        foreach (GridView ItemSource in ItemSources)
                        {
                            int itemIndex = ItemSource.Items.IndexOf(DragItems.ElementAt(i));
                            if (itemIndex != -1)
                            {
                                object temp = ItemSource.Items.ElementAt(i);
                                ItemSource.Items.RemoveAt(itemIndex);
                                //Agendas.add()
                                NewAgenda();
                                /*
                                if (index != -1)
                                {
                                    Day.Items.Insert(index, CreateItem());
                                }
                                else
                                {
                                    Day.Items.Add(CreateItem());
                                }*/
                            }
                        }
                        if (IsAddNewItem)
                        {
                            IsAddNewItem = false;
                            //Day.Items.Add(CreateItem());
                            NewAgenda();
                        }
                    }
                }
            }
            foreach (GridView Day in DayViews)
            {
                Day.Items.Remove(rect);
            }
            rect = null;
        }

        private static void NewAgenda()
        {
            App.MyEditAgendaPage.SetNewState();
            App.MyEditAgendaPage.SetPreviousPage(App.DailyPage);
            Window.Current.Content = App.MyEditAgendaPage;
        }

        private static void EditAgenda()
        {
        }

        /* 原始版的拖曳事件*/
        private void myRectangle_DragEnter(object sender, DragEventArgs e)
        {
            ItemContainerGenerator gen = (((Rectangle)sender).Parent as GridView).ItemContainerGenerator;
            GridView view = (((Rectangle)sender).Parent as GridView);
            ItemCollection items = view.Items;
            int i = items.IndexOf(sender);
            int emptyIndex = 100;
            if (rect != null)
            {
                if (!items.Contains(rect))
                {
                    GridView[] DayViews = { FirstDay, SecondDay, ThirdDay };
                    foreach (GridView Day in DayViews)
                    {
                        Day.Items.Remove(rect);
                    }
                    rect = null;
                    emptyIndex = 1000;
                }
                else
                {
                    emptyIndex = items.IndexOf(rect);
                }
            }


            foreach (object item in DragItems)
            {
                if (items.Contains(item))
                {
                    return;
                }
            }

            try
            {
                if (emptyIndex == 1000)
                {
                    textblock.Text = "part0\n" + i + "  " + i;
                    Rectangle r = new Rectangle();
                    rect = r;
                    //items.Insert(i, rect);
                    object a = items.ElementAt(i);
                    items.RemoveAt(i);
                    items.Insert(i, rect);
                    items.Insert(i + 1, a);
                }
                else if ((i < emptyIndex && rect != null) || emptyIndex == 1000)
                {
                    textblock.Text = "part1\n" + i + "  " + emptyIndex;
                    object a = items.ElementAt(i);
                    items.RemoveAt(i);
                    items.Insert(i + 1, a);
                }
                else
                {
                    textblock.Text = "part2\n" + i + "  " + emptyIndex;
                    if (rect != null)
                        (((Rectangle)rect).Parent as GridView).Items.Remove(rect);
                    Rectangle r = new Rectangle();
                    rect = r;
                    object a = items.ElementAt(i);
                    items.RemoveAt(i);
                    items.Insert(i, rect);
                    items.Insert(i + 1, a);
                }
            }
            catch (Exception er)
            {
                textblock.Text += er.Message;
            }
        }

        private void View_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            DragItems = e.Items;
            bool a = (sender as GridView).Items.Contains(AddIcon);
            IsAddNewItem = true;
        }
        /// <summary>
        /// 在此頁面即將顯示在框架中時叫用。
        /// </summary>
        /// <param name="e">描述如何到達此頁面的事件資料。Parameter
        /// 屬性通常用來設定頁面。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            //if ((bool)First.IsChecked)
            //{
            //    Rectangle r = CreateItem();
            //    FirstDay.Items.Add(r);
            //}
            //if ((bool)Second.IsChecked)
            //{
            //    Rectangle r = CreateItem();
            //    SecondDay.Items.Add(r);
            //}
            //if ((bool)Third.IsChecked)
            //{
            //    Rectangle r = CreateItem();
            //    ThirdDay.Items.Add(r);
            //}
        }

        private Rectangle CreateItem()
        {
            Rectangle myRectangle = new Rectangle();
            Random rand = new Random();
            myRectangle.Fill = new SolidColorBrush(Color.FromArgb(255,
                 (byte)rand.Next(0, 255), (byte)rand.Next(0, 255), (byte)rand.Next(0, 255)));
            myRectangle.Width = 100;
            myRectangle.Height = 100;
            myRectangle.AllowDrop = true;
            myRectangle.Margin = new Thickness(10);
            myRectangle.DragEnter += myRectangle_DragEnter;
            return myRectangle;
        }

        private void AddAgendaClick(object sender, ItemClickEventArgs e)
        {
            //AgendaList.Items.Add(CreateItem());
        }

        private void DeleteItem(object sender, ItemClickEventArgs e)
        {
            GridView[] DayViews = { FirstDay, SecondDay, ThirdDay, AgendaList };
            foreach (GridView Day in DayViews)
            {
                while (Day.SelectedItems.Count > 0)
                {
                    Day.Items.Remove(Day.SelectedItems[0]);
                }
            }
        }

        public IList<object> DragItems { get; set; }

        public object rect { get; set; }

        public bool IsAddNewItem { get; set; }

        private void SwithchFree(object sender, RoutedEventArgs e)
        {
        }

        private void GoToDay(object sender, RoutedEventArgs e)
        {

        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = App.MyMainPage;
        }

        public void Refresh()
        {
            First_.Items.Clear();
            Second_.Items.Clear();
            Third_.Items.Clear();
            GridView[] days = { First_, Second_, Third_ };
            GridView[] dayLists = { FirstDay, SecondDay, ThirdDay };
            DayAgenda day = App.AgendasModel.GetDay(DateTime.Today);
            DateTime time = DateTime.Today;
            for (int i = 0; i < days.Length; i++)
            {
                UILayout uiLayout = new UILayout();
                uiLayout.SolidColorBrush = Colors.LightSeaGreen;
                StackPanel stackPanel = uiLayout.GetMode_A_StackPanel(100, 100, 5,time.Month , time.Day);
                days[i].Items.Add(stackPanel);

                List<Agenda> agendaList = App.AgendasModel.GetAgendaList(time);
                for (int j = 0; j < agendaList.Count; j++)
                {
                    //DayAgenda day = App.AgendasModel.GetDayList(time).ElementAt(i);
                    UILayout uiLayout2 = new UILayout();
                    int hour = agendaList[i].StartDateTime.Value.Hour;
                    int min = agendaList[i].StartDateTime.Value.Minute;
                    int hour2 = agendaList[i].EndDateTime.Value.Hour;
                    int min2 = agendaList[i].EndDateTime.Value.Minute;
                    StackPanel stackPanel2 = uiLayout2.GetMode_B_StackPanel(100, 100,0,0,hour*60+min,hour2*60+min2,agendaList[i].Title);
                    dayLists[i].Items.Add(stackPanel2);
                    //dayLists[i].Items.Add(new StackPanel());
                }


                time = time.AddDays(1);
                
            }
        }
    }
}
