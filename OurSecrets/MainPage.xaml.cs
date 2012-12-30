using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OurSecrets
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //private readonly ObservableCollection<Agenda> _objects = new ObservableCollection<Agenda>();

        //public ObservableCollection<Agenda> Objects
        //{
        //    get { return _objects; }
        //}
        //public List<Agenda> AgendaList
        //{
        //    get { return _agendas.GetAgendaList(); }
        //}

        //Agendas _agendas;
        public MainPage()
        {
            this.InitializeComponent();
            App.AgendasModel.PropertyChanged += _agendas_PropertyChanged;
            //_agendas = App.AgendasModel;
            //_agendas.PropertyChanged += _agendas_PropertyChanged;
            //_agendas.LoadAgendaList();
            //_textBlock.SetBinding(TextBlock.TextProperty, new Binding()
            //{
            //    Source = _agendas,
            //    Path = new PropertyPath("Count"),
            //    Mode = BindingMode.TwoWay
            //});
            CalenderView calenderView = new CalenderView(_itemsControl);
            calenderView.Paint(2012, 12, 28);
        }

        public IAsyncAction ExecuteOnUIThread(Windows.UI.Core.DispatchedHandler action)
        {
            return Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, action);
        }
        public async Task Update()
        {
            await ExecuteOnUIThread(() =>
            {
                //_textBlock.Text = _agendas.Count.ToString();
            });
        }

        public async Task AddAgendaToGridView()
        {
            await ExecuteOnUIThread(() =>
            {
                ////_gridView.Items.Add(new Agenda(new DateTime(2012, 12, 21)));
                //_gridView.Items.Clear();
                //foreach (Agenda agenda in App.AgendasModel.GetAgendaList())
                //{
                //    _gridView.Items.Add(agenda);
                //}
            });
        }
        private void _agendas_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Update();
            AddAgendaToGridView();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ;
        }

        int count = 0;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Agenda agenda1 = new Agenda(new DateTime(2012, 1, 1));
            //agenda1.Title = "agenda" + (count++).ToString();
            //Agenda agenda2 = new Agenda(new DateTime(2012, 1, 2));
            //agenda2.Title = "agenda" + (count++).ToString();
            //Agenda agenda3 = new Agenda(new DateTime(2012, 1, 3));
            //agenda3.Title = "agenda" + (count++).ToString();
            //Agenda agenda4 = new Agenda(new DateTime(2012, 1, 4));
            //agenda4.Title = "agenda" + (count++).ToString();
            //Agenda agenda5 = new Agenda(new DateTime(2012, 1, 5));
            //agenda5.Title = "agenda" + (count++).ToString();
            //_agendas.AddAgenda(agenda1);
            //_agendas.AddAgenda(agenda2);
            //_agendas.AddAgenda(agenda3);
            //_agendas.AddAgenda(agenda4);
            //_agendas.AddAgenda(agenda5);
            //_agendas.SaveAgendaList();
        }

        private void ClickButtonNew(object sender, RoutedEventArgs e)
        {
            App.MyEditAgendaPage.SetNewState();
            App.MyEditAgendaPage.SetPreviousPage( App.MyMainPage);
            Window.Current.Content = App.MyEditAgendaPage;
        }

        private void ClickButtonEdit(object sender, RoutedEventArgs e)
        {
            App.MyEditAgendaPage.SetEditState(App.AgendasModel.GetAgendaList()[0]);
            App.MyEditAgendaPage.SetPreviousPage(App.MyMainPage);
            Window.Current.Content = App.MyEditAgendaPage;
        }

        private void ClickButtonView(object sender, RoutedEventArgs e)
        {
            App.MyEditAgendaPage.SetViewState(App.AgendasModel.GetAgendaList()[0]);
            App.MyEditAgendaPage.SetPreviousPage(App.MyMainPage);
            Window.Current.Content = App.MyEditAgendaPage;
        }

        private void ClickButtonGantt(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = App.MyGanttPage;
        }

        private void ClickButtonDaliyPage(object sender, RoutedEventArgs e)
        {
            App.DailyPage.Refresh();
            Window.Current.Content = App.DailyPage;
        }

        private void SwithchFree(object sender, RoutedEventArgs e)
        {
        }

        private void GoToDay(object sender, RoutedEventArgs e)
        {

            Window.Current.Content = App.DailyPage;
        }
        private void GoGantt(object sender, RoutedEventArgs e)
        {

            Window.Current.Content = App.MyGanttPage;
        }
    }
}
