using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models
{
    public class Villa : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Details { get; set; }
        public double Rate { get; set; }
        public int SqFt { get; set; }
        public int Occupation { get; set; }
        public string ImageUrl { get; set; }
        public string Aminity { get; set; }
    }

}
