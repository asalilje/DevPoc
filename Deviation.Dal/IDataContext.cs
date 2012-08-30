using System.Collections.Generic;
using Deviation.Entities;

namespace Deviation.Dal
{
    public interface IDataContext<T> where T:IEntity
    {
        ICollection<T> Collection { get; } 
    }
}