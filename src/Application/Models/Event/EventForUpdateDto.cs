using System.ComponentModel.DataAnnotations;

namespace Application.Models.Event
{
    public class EventForUpdateDto
    {
        [Required(ErrorMessage = "Id is a required field")]
        public int Id { get; set; }

        [MaxLength(300, ErrorMessage = "Max length of the Description field cannot exceed 300 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Date is a required field")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "OrganizerId is a required field")]
        public int OrganizerId { get; set; }

        [Required(ErrorMessage = "PlaceId is a required field")]
        public int PlaceId { get; set; }
    }
}