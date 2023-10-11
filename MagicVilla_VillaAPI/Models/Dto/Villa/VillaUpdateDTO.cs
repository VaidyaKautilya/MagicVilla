using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.Dto.Villa
{
    public class VillaUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public int SqFt { get; set; }
        [Required]
        public int Occupation { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Aminity { get; set; }
    }
}
