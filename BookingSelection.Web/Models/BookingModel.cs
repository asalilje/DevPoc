using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSelection.Web.Models
{
    public class BookingModel : IModel
    {

        public string DeviationId { get; set; }

        public Guid BookingId { get; set; }

        public string BookingNumber { get; set; }

        public int BookingTypeId { get; set; }
        
        public IEnumerable<BookingType> BookingTypes
        {
            get
            {
                yield return new BookingType { Id = 1, Name = "Charter" };
                yield return new BookingType { Id = 2, Name = "Independent" };
            }
        }
    }

 
    public class BookingType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}