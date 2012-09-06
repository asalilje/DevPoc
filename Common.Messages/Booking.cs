using System;
using NServiceBus;

namespace Common.Messages
{
	public class Booking: IMessage 
	{
		public Guid BookingId { get; set; }
	}
}