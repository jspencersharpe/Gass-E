using System.Windows;
using Gass_E.Repository;
using Gass_E.Model;
using System;
using System.Data.Entity;

namespace Gass_E
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
            //NewFillUp.DataContext = repo.Context().Events.Local;
            //NewFillUp.DataContext = repo.Context();
            FillUpList.DataContext = repo.GetCount();
        }

        private void NewFillUp_Click(object sender, RoutedEventArgs e) 
        {
            repo = new EventRepository();
            int odometer = Convert.ToInt32(Odometer.Text);
            int cost = Convert.ToInt32(CostofFillUp.Text);
            string date = Date.Text;
            repo.Add(new Event(odometer, cost, date));
            Odometer.Text = "";
            CostofFillUp.Text = "";
            Date.Text = "";
        }
    }
}
