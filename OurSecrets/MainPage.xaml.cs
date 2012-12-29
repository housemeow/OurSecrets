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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OurSecrets
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Agendas _agendas;
        public MainPage()
        {
            this.InitializeComponent();
            _agendas = new Agendas();
            _agendas.LoadAgendaList();
            _textBlock.Text = _agendas.Count.ToString();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Agenda agenda1 = new Agenda(new DateTime(2012, 1, 1));
            agenda1.Title = "agenda1";
            Agenda agenda2 = new Agenda(new DateTime(2012, 1, 2));
            agenda2.Title = "agenda2";
            Agenda agenda3 = new Agenda(new DateTime(2012, 1, 3));
            agenda3.Title = "agenda3";
            Agenda agenda4 = new Agenda(new DateTime(2012, 1, 4));
            agenda4.Title = "agenda4";
            Agenda agenda5 = new Agenda(new DateTime(2012, 1, 5));
            agenda5.Title = "agenda5";
            _agendas.AddAgenda(agenda1);
            _agendas.AddAgenda(agenda2);
            _agendas.AddAgenda(agenda3);
            _agendas.AddAgenda(agenda4);
            _agendas.AddAgenda(agenda5);
            _agendas.SaveAgendaList();
        }
    }
}
