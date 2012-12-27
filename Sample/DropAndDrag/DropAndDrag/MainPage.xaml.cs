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

// 空白頁項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234238

namespace DropAndDrag
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Block> _blocksList;
        Thickness _thickness;
        Point _point;
        bool _isPressed;

        public MainPage()
        {
            this.InitializeComponent();
            _blocksList = new List<Block>();
            _textBox.Text = _blocksList.Count.ToString();
            //_imgSanta.ManipulationMode = ManipulationModes.All;
            _imgSanta.PointerPressed += OnPointerPressed;
            _imgSanta.PointerMoved += OnPointerMoved;
            _imgSanta.PointerReleased += OnPointerReleased;
            //_imgSanta.ManipulationStarted += StartedImageManipulation;
            _thickness = new Thickness(200, 0, 0, 0);
            _imgSanta.Margin = _thickness;
            _isPressed = false;
        }

        private void OnPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            OnPointerMoved(sender, e);
            _isPressed = false;
        }

        private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _point = e.GetCurrentPoint(_grid).Position;
            _isPressed = true;
        }

        private void OnPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (_isPressed)
            {
                Image block = (Image)sender;
                Point point = e.GetCurrentPoint(_grid).Position;
                _thickness.Left = block.Margin.Left + (point.X - _point.X);
                _thickness.Top = block.Margin.Top + (point.Y - _point.Y);
                block.Margin = _thickness;
                _point = point;
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

        private void StartedImageManipulation(object sender, ManipulationStartedRoutedEventArgs e)
        {
            Point point = e.Position;
            _listBox.Items.Add("start (" + point.X + "," + point.Y + ")");
        }

        private void DeltaImageManipulation(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            Image block = (Image)sender;
            _thickness.Left = block.Margin.Left + e.Delta.Translation.X;
            _thickness.Top = block.Margin.Top + e.Delta.Translation.Y;
            block.Margin = _thickness;
        }

        private void ClickAddButton(object sender, RoutedEventArgs e)
        {
            Block block = new Block();
            //block.Image.ManipulationMode = ManipulationModes.All;
            //block.Image.ManipulationDelta += DeltaImageManipulation;
            //block.Image.ManipulationStarted += StartedImageManipulation;
            block.Image.PointerPressed += OnPointerPressed;
            block.Image.PointerMoved += OnPointerMoved;
            block.Image.PointerReleased += OnPointerReleased;
            _itemControl.Items.Add(block.Image);
            block.X = block.X;
            block.Y = block.Y;
            _listBox.Items.Add("(" + block.X + ", " + block.Y + ")" + block.Image.Width.ToString() + ", " + block.Image.Height.ToString());
            _blocksList.Add(block);
            _textBox.Text = _blocksList.Count.ToString();
        }
    }
}
