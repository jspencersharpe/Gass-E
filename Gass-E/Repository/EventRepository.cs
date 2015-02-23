using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gass_E;
using System.Data.Entity;
using Gass_E.Model;
using System.Linq.Expressions;

namespace Gass_E.Repository
{
    public class EventRepository : IEventRepository
    {
        private EventContext _dbContext;

        public EventRepository() 
        {
            _dbContext = new EventContext();
            //_dbContext.Events.Load();
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
            return _dbContext.Events.Count<Model.Event>();
        }
        public void Add(Model.Event E) 
        {
            _dbContext.Events.Add(E);
            _dbContext.SaveChanges();
        }
        public void Delete(Model.Event E) 
        {
            throw new NotImplementedException();
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
        public int CalculateAverage(Model.Event E) 
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Model.Event> All()
        {
            var qu = from Event in _dbContext.Events select Event;
            return qu.ToList<Model.Event>();
        }
        public Model.Event GetById(int id) 
        {
            var query = from Event in _dbContext.Events
                        where Event.EventId == id
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
