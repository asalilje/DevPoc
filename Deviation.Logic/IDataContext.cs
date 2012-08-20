using System.Collections.Generic;
using Deviation.Entities;

namespace Deviation.Logic
{
    public interface IDataContext<T> where T:IEntity
    {
        ICollection<T> Collection { get; } 
    }
}