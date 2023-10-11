using MagicVilla_Utilities;
using MagicVilla_web.Models;
using MagicVilla_web.Models.Dto.Authentication;
using MagicVilla_web.Services.IServices;

namespace MagicVilla_web.Services
{
    public class AuthService : BaseService,IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaURL;
        public AuthService(IHttpClientFactory clientFactory,IConfiguration configuration):base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaURL = configuration.GetValue<string>("ServiceURLs:VillaAPI");
        }
        public Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDTO,
                Url = villaURL + "/api/UsersAuth/login"
            });
        }

        public Task<T> RegistrationAsync<T>(RegistrationRequestDTO registrationRequestDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequestDTO,
                Url = villaURL + "/api/UsersAuth/registration"
            });
        }
    }
}
