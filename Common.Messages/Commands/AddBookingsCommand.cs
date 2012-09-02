using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace Common.Messages.Commands
{
    public class AddBookingsCommand : ICommand
    {
        public Guid DeviationId { get; set; }
        public IEnumerable<Guid> Bookings {get;set;}
    }
}
