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

// The Item Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234232

namespace OurSecrets
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public sealed partial class EditAgendaPage : OurSecrets.Common.LayoutAwarePage
    {
        public static Agenda nowAgenda;
        public static UIElement PreviousPage;

        private bool _isNew;
        private bool _isEdit;
        private bool _isView;

        public void SetStartDate(DateTime dateTime)
        {
            StartDatePicker.SelectedDate = dateTime;
            _textBoxStartDate.Text = dateTime.ToString("MM/dd/yyyy");
        }
        public void SetEndDate(DateTime dateTime)
        {
            EndDatePicker.SelectedDate = dateTime;
            _textBoxEndDate.Text = dateTime.ToString("MM/dd/yyyy");
        }     

        public void SetNewState()
        {
            _isNew = true;
            _isEdit = false;
            _isView = false;
            _textBoxTitle.IsReadOnly = false;
            _textBoxTitle.Text = "";

            _textBoxContent.IsReadOnly = false;
            _textBoxContent.Text = "";

            _textBoxStartDate.IsReadOnly = false;

            StartDatePicker.IsEnabled = true;

            _textBoxEndDate.IsReadOnly = false;

            EndDatePicker.IsEnabled = true;

            _radioCommon.IsChecked = true;

            _comboBoxStartHour.IsEnabled = true;

            _comboBoxEndHour.IsEnabled = true;

            _radioImportant.IsEnabled = true;
            _radioCommon.IsEnabled = true;
            _radioUnimportant.IsEnabled = true;
            pageTitle.Text = "Add a New Agenda";
        }
        public void SetEditState(Agenda agenda)
        {
            nowAgenda = agenda;
            _isNew = false;
            _isEdit = true;
            _isView = false;


            _textBoxTitle.IsReadOnly = false;
            _textBoxTitle.Text = agenda.Title;

            _textBoxContent.IsReadOnly = false;
            _textBoxContent.Text = agenda.Content;

            _textBoxStartDate.IsReadOnly = false;
            StartDatePicker.IsEnabled = true;
            //StartDatePicker.SelectedDate = agenda.StartDateTime.Value;
            _textBoxStartDate.Text = agenda.StartDateTime.Value.ToString("MM/dd/yyyy");

            _comboBoxStartHour.SelectedIndex = agenda.StartDateTime.Value.Hour;
            _comboBoxStartHour.IsEnabled = true;

            _textBoxEndDate.IsReadOnly = false;
            EndDatePicker.IsEnabled = true;
            //EndDatePicker.SelectedDate = agenda.EndDateTime.Value;
            _textBoxEndDate.Text = agenda.EndDateTime.Value.ToString("MM/dd/yyyy");

            _comboBoxEndHour.SelectedIndex = agenda.EndDateTime.Value.Hour;
            _comboBoxEndHour.IsEnabled = true;

            if (agenda.Value == Agenda.ValueEnum.Important)
            {
                _radioImportant.IsChecked = true;
            }
            else if (agenda.Value == Agenda.ValueEnum.Common)
            {
                _radioCommon.IsChecked = true;
            }
            else
            {
                _radioUnimportant.IsChecked = true;
            }
            _radioImportant.IsEnabled = true;
            _radioCommon.IsEnabled = true;
            _radioUnimportant.IsEnabled = true;
            pageTitle.Text = "Edit My Agenda";
        }
        public void SetViewState(Agenda agenda)
        {
            nowAgenda = agenda;
            _isNew = false;
            _isEdit = false;
            _isView = true;

            pageTitle.Text = "Agenda detail";


            _textBoxTitle.IsReadOnly = true;
            _textBoxTitle.Text = agenda.Title;
            _textBoxContent.IsReadOnly = true;
            _textBoxContent.Text = agenda.Content;

            _textBoxStartDate.IsReadOnly = true;
            StartDatePicker.IsEnabled = false;
            _textBoxStartDate.Text = agenda.StartDateTime.Value.ToString("MM/dd/yyyy");
            //StartDatePicker.SelectedDate = agenda.StartDateTime.Value;

            _comboBoxStartHour.SelectedIndex = agenda.EndDateTime.Value.Hour;
            _comboBoxStartHour.IsEnabled = false;

            _textBoxEndDate.IsReadOnly = true;
            EndDatePicker.IsEnabled = false;
            _textBoxEndDate.Text = agenda.EndDateTime.Value.ToString("MM/dd/yyyy");
            //EndDatePicker.SelectedDate = agenda.EndDateTime.Value;

            _comboBoxEndHour.SelectedIndex = agenda.EndDateTime.Value.Hour;
            _comboBoxEndHour.IsEnabled = false;


            if (agenda.Value == Agenda.ValueEnum.Important)
            {
                _radioImportant.IsChecked = true;
            }
            else if (agenda.Value == Agenda.ValueEnum.Common)
            {
                _radioCommon.IsChecked = true;
            }
            else
            {
                _radioUnimportant.IsChecked = true;
            }
            _radioImportant.IsEnabled = false;
            _radioCommon.IsEnabled = false;
            _radioUnimportant.IsEnabled = false;
        }

        public EditAgendaPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // Allow saved page state to override the initial item to display
            if (pageState != null && pageState.ContainsKey("SelectedItem"))
            {
                navigationParameter = pageState["SelectedItem"];
            }

            // TODO: Assign a bindable group to this.DefaultViewModel["Group"]
            // TODO: Assign a collection of bindable items to this.DefaultViewModel["Items"]
            // TODO: Assign the selected item to this.flipView.SelectedItem
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            var selectedItem = this.flipView.SelectedItem;
            // TODO: Derive a serializable navigation parameter and assign it to pageState["SelectedItem"]
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            //Window.Current.Content = App.MyMainPage;

            Window.Current.Content = PreviousPage;
        }

        private void ClickButtonSubmit(object sender, RoutedEventArgs e)
        {
            if (_isNew)
            {
                Agenda agenda = new Agenda();
                agenda.Title = _textBoxTitle.Text;
                agenda.Content = _textBoxContent.Text;

                int year, month, day, hour;
                DateTime startDateTime = Convert.ToDateTime(_textBoxStartDate.Text);
                year = startDateTime.Year;
                month = startDateTime.Month;
                day = startDateTime.Day;
                hour = _comboBoxStartHour.SelectedIndex;// Convert.ToInt32(_comboBoxStartHour.SelectedIndex);
                startDateTime = new DateTime(year, month, day, hour, 0, 0);
                agenda.StartDateTime = startDateTime;
                DateTime endDateTime = Convert.ToDateTime(_textBoxEndDate.Text);
                year = endDateTime.Year;
                month = endDateTime.Month;
                day = endDateTime.Day;
                hour = _comboBoxEndHour.SelectedIndex;
                endDateTime = new DateTime(year, month, day, hour, 0, 0);
                agenda.EndDateTime = endDateTime;
                if (_radioImportant.IsChecked.Value)
                {
                    agenda.Value = Agenda.ValueEnum.Important;
                }
                else if (_radioCommon.IsChecked.Value)
                {
                    agenda.Value = Agenda.ValueEnum.Common;
                }
                else
                {
                    agenda.Value = Agenda.ValueEnum.Unimportant;
                }
                App.AgendasModel.AddAgenda(agenda);
            }
            else if (_isEdit)
            {
                nowAgenda.Title = _textBoxTitle.Text;
                nowAgenda.Content = _textBoxContent.Text;
                int year, month, day, hour;
                DateTime startDateTime = Convert.ToDateTime(_textBoxStartDate.Text);
                year = startDateTime.Year;
                month = startDateTime.Month;
                day = startDateTime.Day;
                hour = _comboBoxStartHour.SelectedIndex;// Convert.ToInt32(_comboBoxStartHour.SelectedIndex);
                startDateTime = new DateTime(year, month, day, hour, 0, 0);

                DateTime endDateTime = Convert.ToDateTime(_textBoxEndDate.Text);
                year = endDateTime.Year;
                month = endDateTime.Month;
                day = endDateTime.Day;
                hour = _comboBoxEndHour.SelectedIndex;
                endDateTime = new DateTime(year, month, day, hour, 0, 0);

                if (startDateTime < endDateTime)
                {
                    nowAgenda._startDateTime = startDateTime;
                    nowAgenda._endDateTime = endDateTime;
                }
                else
                {
                    nowAgenda._startDateTime = endDateTime;
                    nowAgenda._endDateTime = startDateTime;
                }

                if (_radioImportant.IsChecked.Value)
                {
                    nowAgenda.Value = Agenda.ValueEnum.Important;
                }
                else if (_radioCommon.IsChecked.Value)
                {
                    nowAgenda.Value = Agenda.ValueEnum.Common;
                }
                else
                {
                    nowAgenda.Value = Agenda.ValueEnum.Unimportant;
                }
            }
            //Window.Current.Content = App.MyMainPage;
            App.DailyPage.Refresh();
            Window.Current.Content = PreviousPage;
        }


        internal void SetPreviousPage(UIElement frame)
        {
            PreviousPage = frame;
        }
    }
}
