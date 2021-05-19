using RB_Soft.Data.Entities;
using RB_Soft.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RB_Soft.Infrastructure.Services
{
    public interface IDetailService
    {
        Task<IEnumerable<Detail>> GetAsync(int page, int count);
        Task<Detail> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<Detail> CreateAsync(DetailModel detail);
        Task<Detail> UpdateAsync(DetailModel detail);
    }
}
