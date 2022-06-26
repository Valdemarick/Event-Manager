using System.ComponentModel.DataAnnotations;

namespace Application.Models.Place
{
    public class PlaceForUpdateDto
    {
        [Required(ErrorMessage = "Id is a required field")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is a required field")]
        public string Name { get; set; } = null!;
    }
}