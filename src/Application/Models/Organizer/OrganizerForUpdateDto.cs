using System.ComponentModel.DataAnnotations;

namespace Application.Models.Organizer
{
    public class OrganizerForUpdateDto
    {
        [Required(ErrorMessage = "Is is a required field")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is a required field")]
        public string Name { get; set; } = null!;
    }
}