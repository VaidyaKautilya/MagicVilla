﻿namespace MagicVilla_web.Models.Dto.Authentication
{
    public class RegistrationRequestDTO
    {
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
