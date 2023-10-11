using MagicVilla_VillaAPI.Models;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IVillaRepository : IGenericRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entity);
    }

}
