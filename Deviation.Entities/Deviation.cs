using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deviation.Entities
{
    public class Deviation : IEntity
    {
        public Guid DeviationId { get; set; }
        public string DeviationName { get; set; }
        public int DeviationTypeId { get; set; }
        public DateInterval DateInterval { get; set; }

        public IEnumerable<Guid> Bookings { get; set; }

    }
}
