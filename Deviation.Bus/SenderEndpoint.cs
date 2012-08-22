using AutoMapper;
using Common.Messages;
using NServiceBus;

namespace Deviation.Bus
{
	public class SenderEndpoint : IWantToRunAtStartup
	{
		public IBus Bus { get; set; }

		public void SendDeviation(Entities.Deviation deviation)
		{
			var message = CreateMessage(deviation);
			Bus.Send(message);
		}

		private DeviationMessage CreateMessage(Entities.Deviation deviation)
		{
			Mapper.CreateMap<Entities.Deviation, DeviationMessage>()
				.ForMember(dest => dest.ValidFrom, opt => opt.MapFrom(src => src.DateInterval.ValidFrom))
				.ForMember(dest => dest.ValidTo, opt => opt.MapFrom(src => src.DateInterval.ValidTo));
			var message = Mapper.Map<Entities.Deviation, DeviationMessage>(deviation);
			return message;
		}


		public void Run()
		{
			
		}

		public void Stop()
		{
			
		}
	}
}