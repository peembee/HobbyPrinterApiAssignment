using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HobbyPrinterApi.Models
{
    public class People
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PeopleID { get; set; }


        [Required]
        [StringLength(30)]
        public string PersonNumber { get; set; } = string.Empty;

        [Required]
        public DateTime RegisteredDate { get; set; } = DateTime.Now;


        [Required]
        [StringLength(40)]
        public string FirstName { get; set; } = string.Empty;


        [Required]
        [StringLength (40)]
        public string LastName { get; set; } = string.Empty;


        public string Phone { get; set; } = string.Empty;

        public virtual ICollection<Hobby> Hobbys { get; set; }
    }
}
