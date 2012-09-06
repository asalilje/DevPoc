using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Deviation.Entities
{
    public class Deviation : IEntity
    {
        public Guid DeviationId { get; set; }
        public string DeviationName { get; set; }
        public int DeviationTypeId { get; set; }
        public DateInterval DateInterval { get; set; }
    	public virtual ICollection<Booking> Bookings { get; set; }
		
    }
}
