using System.ComponentModel.DataAnnotations;

namespace HobbyPrinterApi.Models.DTO.People_DTO
{
    public class PeopleCreateDto
    {
        [Required]
        [StringLength(30)]
        public string PersonNumber { get; set; } = string.Empty;


        [Required]
        [StringLength(40)]
        public string FirstName { get; set; } = string.Empty;


        [Required]
        [StringLength(40)]
        public string LastName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }
}
