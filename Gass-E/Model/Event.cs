using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gass_E.Model
{
    public class Event
    {
        public string Odometer;
        public string CostofFillUp;
        public string Date;

        public Event(string EventOdometer, string EventCostofFillUp, string EventDate) 
        {
            this.Odometer = EventOdometer;
            this.CostofFillUp = EventCostofFillUp;
            this.Date = EventDate;
        }
        
    }

}
