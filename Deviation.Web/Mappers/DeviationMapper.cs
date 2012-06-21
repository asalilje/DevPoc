using System;
using Deviation.Entities;
using Deviation.Web.Models;

namespace Deviation.Web.Mappers
{
    public class DeviationMapper: Mapper<Entities.Deviation, DeviationModel>
    {

        public override Entities.Deviation MapToEntity(DeviationModel model)
        {
            var entity = base.MapToEntity(model);
            entity.DeviationId = model.DeviationId;
            entity.DeviationName = model.DeviationName;
            entity.DeviationTypeId = model.DeviationTypeId;
            var dateInterval = new DateInterval
                                   {
                                       ValidFrom = model.ValidFrom ?? DateTime.MinValue, 
                                       ValidTo = model.ValidTo ?? DateTime.MaxValue
                                   };
            entity.DateInterval = dateInterval;

            return entity;
        }

        public override DeviationModel MapToModel(Entities.Deviation entity)
        {
            var model = base.MapToModel(entity);
            model.DeviationId = entity.DeviationId;
            model.DeviationName = entity.DeviationName;
            model.DeviationTypeId = entity.DeviationTypeId;
            model.ValidFrom = entity.DateInterval.ValidFrom;
            model.ValidTo = entity.DateInterval.ValidTo;

            return model;
        }

    }
}