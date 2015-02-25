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
        public static EventRepository repo = new EventRepository();

        public MainWindow()
        {
            InitializeComponent();
            NewFillUp.DataContext = repo.Context().Events.Local;
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
            HideHelpMessages();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            repo = new EventRepository();
            string odometer = Odometer.Text;
            int odo = Int32.Parse(odometer);
            decimal gall = Convert.ToDecimal(Gallons.Text);
            decimal cost = Convert.ToDecimal(CostofFillUp.Text);
            string date = EventDate.SelectedDate.ToString();
            repo.Add(new Event(odo, gall, cost, date));
            Odometer.Text = "";
            Gallons.Text = "";
            CostofFillUp.Text = "";
            EventDate.Text = "";
        }

        
    }
}
