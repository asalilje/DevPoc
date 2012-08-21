using OV.Entitites;
using OV.Web.Models;

namespace OV.Web.Infrastructure
{
	public interface IGenericMapper<TEntity,TModel> 
		where TEntity: IEntity 
		where TModel : IModel
	{

		TEntity MapToEntity(TModel model);

		TModel MapToModel(TEntity entity);

	}
}