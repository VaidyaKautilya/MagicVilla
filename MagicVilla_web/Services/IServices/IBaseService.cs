using MagicVilla_web.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace MagicVilla_web.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get;set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }


}
