using System.Collections.Generic;
using OV.Entitites;

namespace OV.Logic
{
	public interface IDataContext<T> where T: IEntity
	{
		ICollection<T> Collection { get;}
	}
}