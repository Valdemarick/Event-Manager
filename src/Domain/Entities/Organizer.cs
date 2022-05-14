using Domain.Common;

namespace Domain.Entities
{
    public class Organizer : BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<Event> Events { get; set; } = null!;
    }
}