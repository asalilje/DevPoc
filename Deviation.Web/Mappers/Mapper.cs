using Deviation.Entities;
using Deviation.Web.Models;

namespace Deviation.Web.Mappers
{
    public class Mapper<TEntity, TModel> : IMapper<TEntity, TModel>
        where TEntity: IEntity, new()
        where TModel: IModel, new()
    {
        
        public virtual TEntity MapToEntity(TModel model)
        {
            var entity = new TEntity();
            
            // nån snygg generisk property mapper här

            return entity;
        }

        public virtual TModel MapToModel(TEntity entity)
        {
            var model = new TModel();

            // nån snygg generisk property mapper här

            return model;
        }
    
    }

 
}