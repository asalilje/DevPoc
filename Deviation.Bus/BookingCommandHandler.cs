using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Messages.Commands;
using Deviation.Dal;
using NServiceBus;
using StructureMap;

namespace Deviation.Bus
{
    public class BookingCommandHandler : IHandleMessages<AddBookingsCommand>
    {
        public void Handle(AddBookingsCommand message)
        {
            ObjectFactory.Configure(x =>
            {
                x.Scan(scan =>
                {
                    scan.LookForRegistries();
                    scan.Assembly("Deviation.Dal");
                });
            });

            var repository = ObjectFactory.GetInstance<IDataContext<Entities.Deviation>>();
        }
    }
}
