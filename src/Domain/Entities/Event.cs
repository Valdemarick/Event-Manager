using Domain.Common;

namespace Domain.Entities
{
    public class Event : BaseEntity
    {
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; } = null!;
        public int PlaceId { get; set; }
        public Place Place { get; set; } = null!;
    }
}