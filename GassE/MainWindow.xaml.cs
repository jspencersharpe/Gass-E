﻿using System.Windows;
using GassE.Repository;
using GassE.Model;
using System;
using System.Data.Entity;

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
            //NewFillUp.DataContext = repo.Context().Events.Local;
            //NewFillUp.DataContext = repo.Context();
            FillUpList.DataContext = repo.GetCount();
        }

        private void NewFillUp_Click(object sender, RoutedEventArgs e) 
        {
            repo = new EventRepository();
            int odometer = Convert.ToInt32(Odometer.Text);
            int gall = Convert.ToInt32(Gallons.Text);
            int cost = Convert.ToInt32(CostofFillUp.Text);
            string date = Date.Text;
            repo.Add(new Event(odometer, gall, cost, date));
            Odometer.Text = "";
            Gallons.Text = "";
            CostofFillUp.Text = "";
            Date.Text = "";
        }
    }
}