using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Deviation.Logic
{
    public class DeviationDataContext: IDataContext<Entities.Deviation>
    {
        private readonly ICollection<Entities.Deviation> _collection;

        public ICollection<Entities.Deviation> Collection { get { return _collection; } }

        public DeviationDataContext()
        {
            _collection = new Collection<Entities.Deviation>();
        }
    }
}