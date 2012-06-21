using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using Deviation.Web.Models.CustomValidators;

namespace Deviation.Web.Models
{
    public class DeviationModel : IModel
    {
        public Guid DeviationId { get; set; }

        [DisplayName("Avvikelse")]
        [Required(ErrorMessage = "Avvikelsen måste få en titel")]
        public string DeviationName { get; set; }

        [DisplayName("Typ")]
        public int DeviationTypeId { get; set; }

        [DisplayName("Startdatum")]
		public DateTime? ValidFrom { get; set; }

        [DisplayName("Slutdatum")]
        [DateGreaterThan("ValidFrom")]
        public DateTime? ValidTo { get; set; }

        public IEnumerable<DeviationModel> DeviationList { get; set; }
		
        public IEnumerable<SelectListItem> DeviationTypes
        {
            get
            {
                return new List<SelectListItem>
                           {
                               new SelectListItem {Text = "Timetable change", Value = "1"},
                               new SelectListItem {Text = "Hotel renovation" , Value = "2"}
                           };
            }
        }
    }
}