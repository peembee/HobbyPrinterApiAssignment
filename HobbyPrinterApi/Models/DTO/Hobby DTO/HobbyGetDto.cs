using System.ComponentModel.DataAnnotations;

namespace HobbyPrinterApi.Models.DTO.Hobby_DTO
{
    public class HobbyGetDto
    {
        public int HobbyID { get; set; }

        public int FK_PeopleID { get; set; }

        public DateTime RegisteredDate { get; set; }

        public string Titel { get; set; }

        public string? Description { get; set; } = string.Empty;
    }
}
