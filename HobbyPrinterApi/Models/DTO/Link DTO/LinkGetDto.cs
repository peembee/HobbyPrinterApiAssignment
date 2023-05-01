namespace HobbyPrinterApi.Models.DTO.Link_DTO
{
    public class LinkGetDto
    {
        public int LinkID { get; set; }

        public int FK_HobbyID { get; set; }

        public string Url { get; set; } = string.Empty;
    }
}
