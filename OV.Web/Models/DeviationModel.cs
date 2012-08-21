using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OV.Web.Models
{
	public class DeviationModel : IModel
	{
		public Guid DeviationId { get; set; }

		[DisplayName("Avvikelse")]
		public string DeviationName { get; set; }

		[DisplayName("Typ")]
		public int DeviationTypeId { get; set; }

		[DisplayName("Startdatum")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime ValidFrom { get; set; }

		[DisplayName("Slutdatum")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime ValidTo { get; set; }


		public IEnumerable<DeviationType> DeviationTypes
		{
			get
			{
				yield return new DeviationType { Name = "Timetable change", Id = 1 };
				yield return new DeviationType { Name = "Hotel renovation", Id = 2 };
			}
		}
	}
	
	public class DeviationType
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

}