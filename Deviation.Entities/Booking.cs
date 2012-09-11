using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deviation.Entities
{
	public class Booking : IEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int BookingId { get; set; }
		public Guid BookingGuid { get; set; }
	}
}