using AutoMapper;
using Common.Messages;
using Common.Messages.Commands;
using NServiceBus;
using OV.Dal;
using OV.Entitites;
using StructureMap;

namespace OV.Bus
{
	public class DeviationCommandHandler : IHandleMessages<CreateDeviationCommand>, IHandleMessages<UpdateDeviationCommand>
	{

		public void Handle(CreateDeviationCommand command)
		{
            var deviation = MapToDeviation(command);

			using (var dbContext = new OVDbContext())
			{
				var deviationRepository = new Repository<Deviation>(dbContext);
                deviationRepository.AddItem(deviation);
                deviationRepository.Save();
				deviationRepository.Dispose();
			}

		}

        public void Handle(UpdateDeviationCommand command)
        {
            var deviation = MapToDeviation(command);

            using (var dbContext = new OVDbContext())
            {
                var deviationRepository = new Repository<Deviation>(dbContext);
                deviationRepository.UpdateItem(deviation);
                deviationRepository.Save();
                deviationRepository.Dispose();
            }

        }

		private static Deviation MapToDeviation(CreateDeviationCommand command)
		{
			Mapper.CreateMap<CreateDeviationCommand, Deviation>();
			var deviation = Mapper.Map<CreateDeviationCommand, Deviation>(command);
			return deviation;
		}

        private static Deviation MapToDeviation(UpdateDeviationCommand command)
        {
            Mapper.CreateMap<UpdateDeviationCommand, Deviation>();
            var deviation = Mapper.Map<UpdateDeviationCommand, Deviation>(command);
            return deviation;
        }

	}
}