using System.ComponentModel.DataAnnotations;

namespace HobbyPrinterApi.Models.DTO.Link_DTO
{
    public class LinkCreateDto
    {
        public int FK_HobbyID { get; set; }


        [Required]
        public string Url { get; set; } = string.Empty;
    }
}
