using MagicVilla_web.Models.Dto.Authentication;

namespace MagicVilla_web.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO);
        Task<T> RegistrationAsync<T>(RegistrationRequestDTO registrationRequestDTO);
    }
}
