using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace GassE.Model 
{
    public class Event : INotifyPropertyChanged
    {
        public int EventId { get; set; }
        public int Odometer { get; set; }
        public decimal Gallons { get; set; }
        public decimal CostofFillUp { get; set; }
        public string Date { get; set; }
        public decimal MPG { get; set; }

        public Event() 
        { 
            //placeholder
        }

        public Event(int EventOdometer, decimal EventGallons, decimal EventCostofFillUp, string EventDate) 
        {
            this.Odometer = EventOdometer;
            this.Gallons = EventGallons;
            this.CostofFillUp = EventCostofFillUp;
            this.Date = EventDate;
 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
    }

}
