
namespace Common.Logic
{
	public interface IGenericMapper<TEntity,TModel> 
		where TEntity: class 
		where TModel : class
	{

		TEntity MapToEntity(TModel model);

		TModel MapToModel(TEntity entity);

	}
}