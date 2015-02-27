using System.Windows;
using GassE.Repository;
using GassE.Model;
using System;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace GassE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static EventRepository repo;

        public MainWindow()
        {
            InitializeComponent();
            repo = new EventRepository();
            FillUpList.DataContext = repo.Context().Events.Local;
            //FillUpList.DataContext = repo.GetCount();
            if (repo.GetCount() > 1) 
            {
                HideHelpMessages();
            }
        }

        private void HideHelpMessages() 
        {
            GettingStartedText.Visibility = Visibility.Hidden;
        }

        private void NewFillUp_Click(object sender, RoutedEventArgs e) 
        {
            NewEventForm.Visibility = Visibility.Visible;
            EventDate.SelectedDate = DateTime.Today;
            NewFillUp.IsEnabled = false;
            HideHelpMessages();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            NewEventForm.Visibility = Visibility.Collapsed;
            repo = new EventRepository();
            int odometer = Int32.Parse(Odometer.Text);
            decimal gall = Convert.ToDecimal(Gallons.Text);
            decimal cost = Convert.ToDecimal(CostofFillUp.Text);
            string date = EventDate.SelectedDate.ToString();
            repo.Add(new Event(odometer, gall, cost, date));
            FillUpList.DataContext = repo.All();
            Odometer.Text = "";
            Gallons.Text = "";
            CostofFillUp.Text = "";
            EventDate.Text = "";
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        
    }
}
