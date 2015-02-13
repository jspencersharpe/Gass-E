using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using Gass_E.Repository;
using Gass_E.Model;
using Gass_E;

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
