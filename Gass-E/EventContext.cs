using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Gass_E;
using Gass_E.Model;

namespace Gass_E
{
    public class EventContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
    }
}
