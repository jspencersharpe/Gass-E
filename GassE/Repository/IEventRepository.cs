using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GassE.Model;

namespace GassE.Repository
{
    public interface IEventRepository
    {
        int GetCount();
        void Add(Event E);
        void Delete(Event E);
        void Clear();
        IEnumerable<Event> PastEvents();
        decimal CalculateAverage();
        IEnumerable<Event> All();
        Event GetById(int id);
        Event GetByOdometer(int odo);
        Event GetByGallons(decimal gall);
        Event GetByCostOfFillUp(decimal cost);
        Event GetByDate(string date);
        IQueryable<Event> SearchFor(Expression<Func<Event, bool>> predicate);
    }
}
