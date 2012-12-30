using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace OurSecrets
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        static public Frame MyMainPage { set; get; }
        static public EditAgendaPage MyEditAgendaPage { set; get; }
        static public GanttPage MyGanttPage { set; get; }
        static public Agendas AgendasModel = new Agendas();
        static public DailyPage DailyPage { set; get; }
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            AgendasModel.LoadAgendaList();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 1:00"), DateTime.Parse("12/29/2012 3:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 2:00"), DateTime.Parse("12/29/2012 5:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 4:00"), DateTime.Parse("12/29/2012 7:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 6:00"), DateTime.Parse("12/29/2012 9:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 6:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 6:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 6:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 6:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 6:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 6:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 6:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 6:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/24/2012 6:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/24/2012 12:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/25/2012 6:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/27/2012 6:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/28/2012 18:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/28/2012 18:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 6:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/30/2012 6:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/21/2012 12:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/21/2012 6:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/22/2012 6:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/18/2012 6:00")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/20/2012 7:00")));

                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 12:15"), DateTime.Parse("12/29/2012 13:15")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 12:20"), DateTime.Parse("12/29/2012 16:15")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 17:15"), DateTime.Parse("12/29/2012 17:20")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 18:20"), DateTime.Parse("12/29/2012 18:50")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 20:00"), DateTime.Parse("12/29/2012 22:15")));
                AgendasModel.AddAgenda(new Agenda(DateTime.Parse("12/29/2012 23:15"), DateTime.Parse("12/29/2012 23:50")));

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
                MyMainPage = rootFrame;
                MyEditAgendaPage = new EditAgendaPage();
                MyGanttPage = new GanttPage();
                DailyPage = new DailyPage();
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        /// <summary>
        /// 在啟用應用程式以顯示搜尋結果時叫用。
        /// </summary>
        /// <param name="args">有關啟用要求的詳細資料。</param>
        protected async override void OnSearchActivated(Windows.ApplicationModel.Activation.SearchActivatedEventArgs args)
        {
            // TODO: 在 OnWindowCreated 中註冊 Windows.ApplicationModel.Search.SearchPane.GetForCurrentView().QuerySubmitted
            // 事件，以加速已經執行之應用程式的搜尋速度

            // 如果視窗尚未使用框架巡覽，則插入我們自己的框架
            var previousContent = Window.Current.Content;
            var frame = previousContent as Frame;

            // 如果應用程式不包含最上層框架，這可能是
            // 應用程式的初始啟動。一般而言，這個方法和 App.xaml.cs 中的 OnLaunched 
            // 可以呼叫共同的方法。
            if (frame == null)
            {
                // 建立框架做為巡覽內容，並與
                // SuspensionManager 機碼產生關聯
                frame = new Frame();
                OurSecrets.Common.SuspensionManager.RegisterFrame(frame, "AppFrame");

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // 只在適當時還原儲存的工作階段狀態
                    try
                    {
                        await OurSecrets.Common.SuspensionManager.RestoreAsync();
                    }
                    catch (OurSecrets.Common.SuspensionManagerException)
                    {
                        //發生狀況，還原狀態。
                        //假定沒有狀態，並繼續
                    }
                }
            }

            //frame.Navigate(typeof(SearchResultsPage1), args.QueryText);
            Window.Current.Content = frame;

            // 確定目前視窗是作用中
            Window.Current.Activate();
        }
    }
}
