using AutoMapper;

namespace Common.Logic
{
	public class GenericMapper<TEntity, TModel> : IGenericMapper<TEntity, TModel>
		where TEntity : class
		where TModel : class
	{
		public virtual TEntity MapToEntity(TModel model)
		{
			Mapper.CreateMap<TModel, TEntity>();
			var entity = Mapper.Map<TModel, TEntity>(model);
			return entity;
		}

		public virtual TModel MapToModel(TEntity entity)
		{
			Mapper.CreateMap<TEntity, TModel>();
			var model = Mapper.Map<TEntity, TModel>(entity);
			return model;
		}

	}
}