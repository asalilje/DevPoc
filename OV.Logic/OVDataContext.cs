using System.Collections.Generic;
using System.Collections.ObjectModel;
using OV.Entitites;

namespace OV.Logic
{
	public class OVDataContext: IDataContext<Deviation>
	{

		private ICollection<Deviation> _collection;

		public OVDataContext()
		{
			_collection = new Collection<Deviation>();
		}

		public ICollection<Deviation> Collection
		{
			get { return _collection; }
		}
	}
}