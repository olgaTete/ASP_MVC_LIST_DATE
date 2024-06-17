using System.ComponentModel.DataAnnotations;
namespace ListDate2.Models.View
{
    public class CreatePersonViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string City { get; set; }
    }
}
