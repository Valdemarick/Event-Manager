using System.ComponentModel.DataAnnotations;

namespace Application.Models.Place
{
    public class PlaceForCreationDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        public string Name { get; set; } = null!;
    }
}