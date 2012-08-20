using System;
using System.Collections.Generic;
using System.Linq;

namespace Deviation.Logic
{

    public class DeviationRepository : IRepository<Entities.Deviation>
    {

        private readonly IDataContext<Entities.Deviation> _dataContext;

        public DeviationRepository(IDataContext<Entities.Deviation> dataContext)
        {
            _dataContext = dataContext;
        }

        public Entities.Deviation GetItemById(Guid id)
        {
            return _dataContext.Collection.FirstOrDefault(item => item.DeviationId == id);
        }

        public IEnumerable<Entities.Deviation> GetItems()
        {
            return _dataContext.Collection;
        }


        public IEnumerable<Entities.Deviation> GetItemsByQuery(Func<Entities.Deviation, bool> filter)
        {
            return _dataContext.Collection.Where(filter);
        }


        public void AddItem(Entities.Deviation item)
        {
			if(_dataContext.Collection.Any(deviation => deviation.DeviationId == item.DeviationId))
				_dataContext.Collection.Remove(_dataContext.Collection.Single(deviation => deviation.DeviationId == item.DeviationId));

			_dataContext.Collection.Add(item);
        }


        public void RemoveItem(Guid id)
        {
            _dataContext.Collection.Remove(_dataContext.Collection.FirstOrDefault(deviation => deviation.DeviationId == id));
        }

    }

}
