using System.Windows;
using Gass_E.Repository;
using Gass_E.Model;

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
            NewFillUp.DataContext = repo.Context().Events.Local;

        }

        private void NewFillUp_Click(object sender, RoutedEventArgs e) 
        {
            repo.Add(new Event("100,000", "$50.00", "4/1/2015"));
        }
    }
}
