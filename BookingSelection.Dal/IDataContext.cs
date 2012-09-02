using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingSelection.Entities;


namespace BookingSelection.Dal
{
    public interface IDataContext<T> where T: IEntity
    {
        ICollection<T> Collection { get; }
    }
}
