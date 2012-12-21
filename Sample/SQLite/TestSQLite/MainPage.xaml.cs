using SQLite;
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

namespace TestSQLite
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "sqlite.db");

        public MainPage()
        {
            this.InitializeComponent();
            LoadData();
        }

        /// <summary>
        /// 在此頁面即將顯示在框架中時叫用。
        /// </summary>
        /// <param name="e">描述如何到達此頁面的事件資料。Parameter
        /// 屬性通常用來設定頁面。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        
        public void LoadData()
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection(dbPath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite, true);

            sqlite_conn.CreateTable<Person>();

            sqlite_conn.Insert(new Person() { FirstName = "Keming", LastName = "Chen" });

            List<Person> personList = sqlite_conn.Query<Person>("SELECT * FROM Person");

            for (int i = 0; i < personList.Count; i++)
            {
                _myListBox.Items.Add(personList[i].FirstName + " " + personList[i].LastName);
            }

            sqlite_conn.Close();
        }

        private void ClickTestButton(object sender, RoutedEventArgs e)
        {
            App.Current.Exit();
        }
    }
}
