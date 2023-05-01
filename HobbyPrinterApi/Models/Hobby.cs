using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HobbyPrinterApi.Models
{
    public class Hobby
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HobbyID { get; set; }


        [ForeignKey(name: "Peoples")]
        public int FK_PeopleID { get; set; }
        public virtual People Peoples { get; set; }


        [Required]
        public DateTime RegisteredDate { get; set; } = DateTime.Now;


        [Required]
        [StringLength(30)]
        public string Titel { get; set; }


        public string? Description { get; set; } = string.Empty;

        public virtual ICollection<Link> Links { get; set; }    
    }
}
