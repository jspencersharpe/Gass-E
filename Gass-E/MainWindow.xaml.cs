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
using Gass_E.Model;

namespace Gass_E
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Event> Events;

        public MainWindow()
        {
            Events = new ObservableCollection<Event>();
            Events.Add(new Event("200,000", "$50.00", "4/1/2015"));
            InitializeComponent();
            FillUpList.DataContext = Events;
        }

        private void SetAndToggleAccess(string _string) 
        {
            
        }

        private void NewFillUp_Click(object sender, RoutedEventArgs e) 
        {
            SetAndToggleAccess("NewFillUp");
            NewFillUp.IsEnabled = true;
        }
    }
}
