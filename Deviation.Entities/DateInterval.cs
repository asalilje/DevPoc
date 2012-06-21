using System;

namespace Deviation.Entities
{
    public class DateInterval : IEntity
    {
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}