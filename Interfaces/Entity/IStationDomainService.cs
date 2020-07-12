using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore_Multi_BD.Entities;
using EFCore_Multi_BD.Input;

namespace EFCore_Multi_BD.Interfaces.Entity
{
    public interface IStationDomainService
    {
        Task<Station> InsertAsync(StationInput station);
        Task<Station> AlterAsync(int id, Station station);
        Task DeleteAsync(int id);
        Task<IEnumerable<Station>> GetAsync();
        Task<Station> GetByIdAsync(int id);
    }
}