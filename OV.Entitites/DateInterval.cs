using System;

namespace OV.Entitites
{
	public class DateInterval : IEntity
	{
		public DateTime ValidFrom { get; set; }
		public DateTime ValidTo { get; set; }
	}
}