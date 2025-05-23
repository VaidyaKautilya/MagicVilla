﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_web.Models.Dto.VillaNumber
{
    public class VillaNumberUpdateDto
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VillaId { get; set; }
        public string SpecialDetails { get; set; }
    }

}
