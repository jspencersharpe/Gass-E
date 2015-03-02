using System.Windows;
using GassE.Repository;
using GassE.Model;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Windows.Data;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using GassE;

namespace GassE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static EventContext _dbContext;
        public static EventRepository repo;

        public MainWindow()
        {
            InitializeComponent();
            repo = new EventRepository();
            FillUpList.DataContext = repo.Context().Events.Local;
            CalculateAverage.DataContext = repo.CalculateAverage();
            if (repo.GetCount() >= 1) 
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
            CalculateAverage.DataContext = repo.CalculateAverage();
            Odometer.Text = "";
            Gallons.Text = "";
            CostofFillUp.Text = "";
            EventDate.Text = "";
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Odometer != null)
            {
                this.Odometer.Clear();
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            repo.Clear();
        }

        
    }
}
