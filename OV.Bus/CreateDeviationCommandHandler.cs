using AutoMapper;
using Common.Messages.Commands;
using NServiceBus;
using OV.Dal;
using OV.Entitites;
using StructureMap;

namespace OV.Bus
{
	public class CreateDeviationCommandHandler : IHandleMessages<CreateDeviationCommand>
	{

		public void Handle(CreateDeviationCommand command)
		{
			var deviation = CreateDeviation(command);


			using (var dbContext = new OVDbContext())
			{
				var deviationRepository = new Repository<Deviation>(dbContext);
				deviationRepository.AddItem(deviation);
				deviationRepository.Save();
				deviationRepository.Dispose();
			}



		}

		private static Deviation CreateDeviation(CreateDeviationCommand command)
		{
			Mapper.CreateMap<CreateDeviationCommand, Deviation>();
			var deviation = Mapper.Map<CreateDeviationCommand, Deviation>(command);
			return deviation;
		}
	}
}