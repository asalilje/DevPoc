using System;
using System.Collections.ObjectModel;
using System.Linq;
using Common.Messages.Commands;
using Deviation.Dal;
using NServiceBus;

namespace Deviation.Bus
{
    public class BookingCommandHandler : IHandleMessages<AddBookingsCommand>
    {

    	public IBus Bus { get; set; }

        public void Handle(AddBookingsCommand message)
        {
			Console.WriteLine("Handling message " + message.GetType().Name + " for deviationId " + message.DeviationId);

			using(var deviationContext = new DeviationDbContext())
			{
				var deviationRepository = new DeviationRepository(deviationContext);
				var deviation = deviationRepository.GetItem(message.DeviationId);
				if(deviation != null)
				{
					var bookingList = deviation.Bookings ?? new Collection<Entities.Booking>();
					message.Bookings.ToList().ForEach(item => bookingList.Add(
						new Entities.Booking {BookingGuid = item.BookingId}
						));
					deviation.Bookings = bookingList;
					deviationRepository.UpdateItem(deviation);
					deviationRepository.Save();
				}	
				deviationRepository.Dispose();
        	}

			// skickar vidare till OV
        	Bus.Send(message);

        }
    }
}
