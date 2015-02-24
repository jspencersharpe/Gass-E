using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Gass_E.Model 
{
    public class Event : INotifyPropertyChanged
    {
        public int EventId { get; set; }
        public int Odometer { get; set; }
        public int Gallons { get; set; }
        public int CostofFillUp { get; set; }
        public string Date { get; set; }

        public Event() 
        { 
            //placeholder
        }

        public Event(int EventOdometer, int EventGallons, int EventCostofFillUp, string EventDate) 
        {
            this.Odometer = EventOdometer;
            this.Gallons = EventGallons;
            this.CostofFillUp = EventCostofFillUp;
            this.Date = EventDate;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
    }

}
