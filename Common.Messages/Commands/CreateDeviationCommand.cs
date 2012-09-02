using System;
using NServiceBus;

namespace Common.Messages.Commands
{
	public class CreateDeviationCommand : ICommand
	{
		public Guid Id { get; set; }
		public string DeviationName { get; set; }
		public DateTime ValidFrom { get; set; }
		public DateTime ValidTo { get; set; }
		public int DeviationTypeId { get; set; }
        public DeviationStatus Status {get; set;}
    }
}