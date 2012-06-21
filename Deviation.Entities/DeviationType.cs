namespace Deviation.Entities
{
    public class DeviationType :IEntity
    {
        public int DeviationTypeId { get; set; }
        public string DeviationTypeName { get; set; }
        public string DeviationTypeDescription { get; set; }
    }
}