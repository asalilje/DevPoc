using System.Collections.Generic;
using System.Collections.ObjectModel;
using Deviation.Entities;

namespace Common.Repository
{
    public interface IDataContext<T> where T:IEntity
    {
        ICollection<T> Collection { get; } 
    }
}