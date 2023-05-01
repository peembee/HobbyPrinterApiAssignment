using System.ComponentModel.DataAnnotations;

namespace HobbyPrinterApi.Models.DTO.Hobby_DTO
{
    public class HobbyUpdateDto
    {
        [Required]
        [StringLength(30)]
        public string Titel { get; set; }

        public string? Description { get; set; } = string.Empty;
    }
}
