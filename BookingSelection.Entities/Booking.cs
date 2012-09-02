using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingSelection.Entities
{
    public class Booking : IEntity
    {
        public Guid BookingId { get; set; }
        public string BookingNumber { get; set; }
        public int BookingTypeId {get;set;}
    }
}
