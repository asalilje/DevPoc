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
	}
}