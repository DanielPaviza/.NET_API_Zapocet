using System.ComponentModel.DataAnnotations;
namespace Paviza_Zapocet.Data.Model
{
    public class CompanyKeys

    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CompanyKey { get; set; }

        [Required]
        public string CompanyHash { get; set; }

    }
}
