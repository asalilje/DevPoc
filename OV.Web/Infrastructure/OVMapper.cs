using AutoMapper;
using Common.Logic;
using OV.Entitites;
using OV.Web.Models;

namespace OV.Web.Infrastructure
{
	public class OVMapper : GenericMapper<Deviation, DeviationModel>
	{
		public override Deviation MapToEntity(DeviationModel model)
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

		public override DeviationModel MapToModel( Deviation entity)
		{
			Mapper.CreateMap<Deviation, DeviationModel>()
				.ForMember(dest => dest.ValidFrom, opt => opt.MapFrom(src => src.DateInterval.ValidFrom))
				.ForMember(dest => dest.ValidTo, opt => opt.MapFrom(src => src.DateInterval.ValidTo));
			var model = Mapper.Map<Deviation, DeviationModel>(entity);
			return model;
		}
	}
}