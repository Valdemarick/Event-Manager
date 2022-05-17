using System.ComponentModel.DataAnnotations;

namespace Application.Models.Organizer
{
    public class OrganizerForCreationDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        public string Name { get; set; } = null!;
    }
}