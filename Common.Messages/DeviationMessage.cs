using System;
using NServiceBus;

namespace Common.Messages
{
	public class DeviationMessage : IMessage
	{
		public Guid DeviationId { get; set; }
		public string DeviationName { get; set; }
		public DateTime ValidFrom { get; set; }
		public DateTime ValidTo { get; set; }
		public int DeviationTypeId { get; set; }
	}
}