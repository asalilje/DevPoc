using AutoMapper;
using Common.Logic;
using Deviation.Entities;
using Deviation.Web.Models;

namespace Deviation.Web.Infrastructure.Mappers
{
    public class DeviationMapper: GenericMapper<Entities.Deviation, DeviationModel>
    {

        public override Entities.Deviation MapToEntity(DeviationModel model)
        {
            var entity = base.MapToEntity(model);
			
            var dateInterval = new DateInterval
			                       {
			                           ValidFrom = model.ValidFrom, 
			                           ValidTo = model.ValidTo
			                       };
			entity.DateInterval = dateInterval;

            return entity;
        }

        public override DeviationModel MapToModel(Entities.Deviation entity)
        {
            Mapper.CreateMap<Entities.Deviation, DeviationModel>()
                .ForMember(dest => dest.ValidFrom, opt => opt.MapFrom(src => src.DateInterval.ValidFrom))
                .ForMember(dest => dest.ValidTo, opt => opt.MapFrom(src => src.DateInterval.ValidTo));
			var model = Mapper.Map<Entities.Deviation, DeviationModel>(entity);
            return model;
        }

    }
}