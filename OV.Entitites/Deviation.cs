using System;

namespace OV.Entitites
{
	public class Deviation : IEntity
	{
		public Guid DeviationId { get; set; }
		public string DeviationName { get; set; }
		public int DeviationTypeId { get; set; }
		public DateInterval DateInterval { get; set; }
	}
}