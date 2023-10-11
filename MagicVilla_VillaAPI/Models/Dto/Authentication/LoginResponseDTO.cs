namespace MagicVilla_VillaAPI.Models.Dto.Authentication
{
    public class LoginResponseDTO
    {
        public UserDTO User { get; set; }
        public string Token { get; set; }
    }
}
