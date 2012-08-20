using System;
using System.Collections.Generic;
using System.Linq;
using OV.Entitites;

namespace OV.Logic
{
	public class OVRepository : IRepository<Deviation>
	{

		private readonly IDataContext<Deviation> _dataContext;

		public OVRepository(IDataContext<Deviation> dataContext)
        {
            _dataContext = dataContext;
        }

        public Deviation GetItemById(Guid id)
        {
            return _dataContext.Collection.FirstOrDefault(item => item.DeviationId == id);
        }

        public IEnumerable<Deviation> GetItems()
        {
            return _dataContext.Collection;
        }


        public IEnumerable<Deviation> GetItemsByQuery(Func<Deviation, bool> filter)
        {
            return _dataContext.Collection.Where(filter);
        }


        public void AddItem(Deviation item)
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