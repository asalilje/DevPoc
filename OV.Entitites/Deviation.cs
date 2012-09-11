using System;
using System.ComponentModel.DataAnnotations;

namespace OV.Entitites
{
	public class Deviation : IEntity
	{
		public Guid Id { get; set; }
		
		public string DeviationName { get; set; }
		public int DeviationTypeId { get; set; }
		public DateTime ValidFrom { get; set; }
		public DateTime ValidTo { get; set; }
        public string Status { get; set; }
		public bool HasBookings { get; set; }
	}
}