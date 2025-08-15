using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParticulateRegister.Domain.Models;

namespace ParticulateRegister.Domain.Interfaces
{
    public interface IParticulateRepository
    {
        Task<IEnumerable<ParticulateDto>> GetAllAsync();
        Task<ParticulateDto?> GetByIdAsync(Guid id);
        Task AddAsync(ParticulateDto particulate);
        Task UpdateAsync(ParticulateDto particulate);
        Task DeleteAsync(Guid id);
        Task AddHistoryAsync(ParticulateHistoryDto history);
    }
}
