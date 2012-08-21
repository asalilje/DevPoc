using AutoMapper;
using OV.Entitites;
using OV.Web.Models;

namespace OV.Web.Infrastructure
{
	public class GenericMapper<TEntity, TModel> : IGenericMapper<TEntity, TModel>
		where TEntity : IEntity
		where TModel : IModel
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