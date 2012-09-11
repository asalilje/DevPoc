using System;
using System.Collections.Generic;
using System.Diagnostics;
using NServiceBus;

namespace Common.Messages.Commands
{
    public class AddBookingsCommand : ICommand
    {
        public Guid DeviationId { get; set; }
        public ICollection<Booking> Bookings {get;set;}
    }
}
