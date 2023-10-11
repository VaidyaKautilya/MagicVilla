using System.ComponentModel.DataAnnotations;

namespace MagicVilla_web.Models.Dto.Villa
{
    public class VillaDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        public int SqFt { get; set; }
        public int Occupation { get; set; }
        public string ImageUrl { get; set; }
        public string Aminity { get; set; }
    }
}
