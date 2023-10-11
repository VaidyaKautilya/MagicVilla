﻿using MagicVilla_VillaAPI.Models.Dto.Villa;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.Dto.VillaNumber
{
    public class VillaNumberDto
    {
        [Required]
        public int VillaNo { get; set; }
        public int VillaId { get; set; }
        public string SpecialDetails { get; set; }
        public VillaDTO Villa { get; set; }
    }

}
