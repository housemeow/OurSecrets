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
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// 空白頁項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234238

namespace Tiles_Test
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            AddView.DragItemsStarting+=AddView_DragItemsStarting;
            FirstDay.Drop += FirstDay_Drop;
            FirstDay.DragItemsStarting += AddView_DragItemsStarting;
            FirstDay.SizeChanged += FirstDay_SizeChanged;
            SecondDay.Drop += FirstDay_Drop;
            SecondDay.DragItemsStarting += AddView_DragItemsStarting;
            ThirdDay.Drop += FirstDay_Drop;
            ThirdDay.DragItemsStarting += AddView_DragItemsStarting;
            isChanging = false;
        }

        void FirstDay_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            isChanging = false;
        }



        void FirstDay_Drop(object sender, DragEventArgs e)
        {
            //rect = null;
            GridView[] DayViews = { FirstDay, SecondDay, ThirdDay };
            foreach (GridView Day in DayViews)
            {
                Day.Items.Remove(rect);
                rect = null;
            }

            for (int i = 0; i < DragItems.Count; i++)
            {
                //FirstDay.Items.Add(DragItems[i]);
                //(((Rectangle)sender).Parent as GridView).Items.Insert(,DragItems[i]);
            }
            rect = null;
        }

        private void myRectangle_DragEnter(object sender, DragEventArgs e)
        {
            ItemContainerGenerator gen = (((Rectangle)sender).Parent as GridView).ItemContainerGenerator;
            ItemCollection items = (((Rectangle)sender).Parent as GridView).Items;
            int i = items.IndexOf(sender);
            //if(DragItems==null||items.Contains(DragItems[0]))
            //{
            //    return;
            //}
            if (isChanging) return;
            bool isNew;
            
            if (rect == null)
            {
                Rectangle r = new Rectangle();
                //r.DragEnter += myRectangle_DragEnter;
                r.Margin = new Thickness(-50, 0, 0, 0);
                rect = r;
                items.Insert(i, rect);
                object a = (((Rectangle)sender).Parent as GridView).Items.ElementAt(i);
                (a as Rectangle).HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
                isChanging = true;
            }
            else
            {
                try
                {
                    (((Rectangle)rect).Parent as GridView).Items.Remove(rect);
                    Rectangle r = new Rectangle();
                    //r.DragEnter += myRectangle_DragEnter;
                    r.Margin = new Thickness(-50, 0, 0, 0);
                    rect = r;
                    items.Insert(i, rect);
                    Rectangle a = (Rectangle)(((Rectangle)sender).Parent as GridView).Items.ElementAt(i);
                    isChanging = true;
                }
                catch (Exception er)
                {
                }
            }
        }

        private void AddView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            DragItems = e.Items;
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
            if ((bool)First.IsChecked)
            {
                FirstDay.Items.Add(CreateItem());
            }
            if ((bool)Second.IsChecked)
            {
                SecondDay.Items.Add(CreateItem());
            }
            if ((bool)Third.IsChecked)
            {
                ThirdDay.Items.Add(CreateItem());
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)First.IsChecked && FirstDay.Items.Count > 0)
            {
                while (FirstDay.SelectedItems.Count > 0)
                {
                    FirstDay.Items.Remove(FirstDay.SelectedItems[0]);
                }
            }
            if ((bool)Second.IsChecked && SecondDay.Items.Count > 0)
            {
                while (SecondDay.SelectedItems.Count > 0)
                {
                    SecondDay.Items.Remove(SecondDay.SelectedItems[0]);
                }
            }
            if ((bool)Third.IsChecked && ThirdDay.Items.Count > 0)
            {
                while (ThirdDay.SelectedItems.Count>0)
                {
                    ThirdDay.Items.Remove(ThirdDay.SelectedItems[0]);
                }
            }
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
            myRectangle.DragEnter+=myRectangle_DragEnter;
            //myRectangle.DragOver += myRectangle_DragEnter;
            return myRectangle;
        }

        void myRectangle_DragLeave(object sender, DragEventArgs e)
        {
            
        }

        private void AddAgendaClick(object sender, ItemClickEventArgs e)
        {
            AgendaList.Items.Add(CreateItem());
        }

        private void DeleteItem(object sender, ItemClickEventArgs e)
        {
            GridView[] DayViews = { FirstDay, SecondDay, ThirdDay };
            foreach(GridView Day in DayViews)
            {
                while (Day.SelectedItems.Count > 0)
                {
                    Day.Items.Remove(Day.SelectedItems[0]);
                }
            }
        }

        public IList<object> DragItems { get; set; }

        public object rect { get; set; }


        public bool isChanging { get; set; }
    }
}
