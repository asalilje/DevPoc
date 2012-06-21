using Deviation.Entities;
using Deviation.Web.Models;

namespace Deviation.Web.Mappers
{
    public interface IMapper<TEntity, TModel> 
        where TEntity: IEntity, new()
        where TModel: IModel, new()
    {

        TEntity MapToEntity(TModel model);
        TModel MapToModel(TEntity entity);
    }
}