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
                First_ItemControl.Items.Add(CreateItem());
            }
            if ((bool)Second.IsChecked)
            {
                Second_ItemControl.Items.Add(CreateItem());
            }
            if ((bool)Third.IsChecked)
            {
                Third_ItemControl.Items.Add(CreateItem());
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)First.IsChecked && First_ItemControl.Items.Count>0)
            {
                First_ItemControl.Items.RemoveAt(0);
            }
            if ((bool)Second.IsChecked && Second_ItemControl.Items.Count > 0)
            {
                Second_ItemControl.Items.RemoveAt(0);
            }
            if ((bool)Third.IsChecked && Third_ItemControl.Items.Count > 0)
            {
                Third_ItemControl.Items.RemoveAt(0);
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
            myRectangle.DragEnter += myRectangle_DragEnter;
            return myRectangle;
        }

        void myRectangle_DragEnter(object sender, DragEventArgs e)
        {
            
        }
    }
}
