using System.ComponentModel.DataAnnotations;

namespace HobbyPrinterApi.Models.DTO.Hobby_DTO
{
    public class HobbyCreateDto
    {
        public int FK_PeopleID { get; set; }

        [Required]
        [StringLength(30)]
        public string Titel { get; set; }


        public string? Description { get; set; } = string.Empty;
    }
}
