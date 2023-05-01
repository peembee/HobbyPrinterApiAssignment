using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HobbyPrinterApi.Models
{
    public class Link
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LinkID { get; set; }


        [ForeignKey(name: "Hobbys")]
        public int FK_HobbyID { get; set; }
        public virtual Hobby Hobbys { get; set; }


        [Required]
        public string Url { get; set; } = string.Empty;
    }
}
