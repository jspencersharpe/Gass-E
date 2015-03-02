using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GassE;
using System.Data.Entity;
using GassE.Model;
using System.Linq.Expressions;

namespace GassE.Repository
{
    public class EventRepository : IEventRepository
    {
        private EventContext _dbContext;

        public EventRepository() 
        {
            _dbContext = new EventContext();
            _dbContext.Events.Load();
        }

        public EventContext Context() 
        {
            return _dbContext;
        }

        public DbSet<Model.Event> GetDbSet() 
        {
            return _dbContext.Events;
        }

        public int GetCount() 
        {
            return _dbContext.Events.Count<Event>();
        }

        public void Add(Event E) 
        {
            _dbContext.Events.Add(E);
            _dbContext.SaveChanges();
        }

        public void Delete(Event E) 
        {
            _dbContext.Events.Remove(E);
            _dbContext.SaveChanges();
        }

        public void Clear() 
        {
            var a = this.All();
            _dbContext.Events.RemoveRange(a);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Model.Event> PastEvents() 
        {
            throw new NotImplementedException();
        }

        public Model.Event FindMostRecent()
        {
            //Event filler = new Event(200000, 10, 50, "10/1/2015");
            //_dbContext.Events.Add(filler);
            //_dbContext.SaveChanges();
            Event filler = new Event(100, 10, 50, "03/1/2015");
            _dbContext.Events.Add(filler);
            _dbContext.SaveChanges();
            var mostRecent = from Event in _dbContext.Events
                             select Event;
            return mostRecent.OrderByDescending
                (u => u.EventId).FirstOrDefault<Model.Event>();
        }

        public Model.Event FindTimeBefore()
        {
            //Event filler = new Event(10, 1, 1, "2/1/2015");
            //_dbContext.Events.Add(filler);
            //_dbContext.SaveChanges();
            var timeBefore = from Event in _dbContext.Events
                             select Event;

            return timeBefore.OrderByDescending
                (u => u.EventId).Skip(1).FirstOrDefault<Model.Event>();
        }

        public Model.Event MostRecentGallons(decimal gall)
        {

            var gallons = from Event in _dbContext.Events
                          where Event.Gallons == gall
                          select Event;

            return gallons.OrderByDescending
                (s => s.EventId).First<Model.Event>();
        }

        public IEnumerable<Model.Event> All()
        {
            var qu = from Event in _dbContext.Events select Event;
            return qu.ToList<Model.Event>();
        }

        public decimal CalculateAverage()
        {
            Event mostRecent = FindMostRecent();
            Event timeBefore = FindTimeBefore();
            int difference = mostRecent.Odometer - timeBefore.Odometer;
            decimal avg = difference / mostRecent.Gallons;

            if (avg < 0)
            {
               avg = avg * (-1);
            }
            return Math.Round(avg, 2);

        }

        public Model.Event GetById(int id) 
        {
            var query = from Event in _dbContext.Events
                        where Event.EventId == id
                        select Event;
            return query.First<Model.Event>();
        }

        public Model.Event GetByOdometer(int odo) 
        {
            var query = from Event in _dbContext.Events
                        where Event.Odometer == odo
                        select Event;
            return query.First<Model.Event>();
        }

        public Model.Event GetByGallons(decimal gall) 
        {
            var query = from Event in _dbContext.Events
                        where Event.Gallons == gall
                        select Event;
            return query.First<Model.Event>();
        }

        public Model.Event GetByCostOfFillUp(decimal cost) 
        {
            var query = from Event in _dbContext.Events
                        where Event.CostofFillUp == cost
                        select Event;
            return query.First<Model.Event>();
        }

        public Model.Event GetByDate(string date)
        {
            var query = from Event in _dbContext.Events
                        where Event.Date == date
                        select Event;
            return query.First<Model.Event>();
        }

        public IQueryable<Event> SearchFor(Expression<Func<Event, bool>> predicate) 
        {
            throw new NotImplementedException();
        }

        public void Dispose() 
        {
            _dbContext.Dispose();
        }

    }
}
