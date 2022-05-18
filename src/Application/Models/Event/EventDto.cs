namespace Application.Models.Event
{
    public class EventDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string OrganizerName { get; set; } = null!;
        public string PlaceName { get; set; } = null!;
    }
}