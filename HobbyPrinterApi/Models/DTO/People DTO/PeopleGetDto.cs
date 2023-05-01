using System.ComponentModel.DataAnnotations;

namespace HobbyPrinterApi.Models.DTO.People_DTO
{
    public class PeopleGetDto
    {
        public int PeopleID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }
}
