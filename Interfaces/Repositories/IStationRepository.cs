using EFCore_Multi_BD.Entities;
using EFCore_Multi_BD.Interfaces.Repositories.Base;

namespace EFCore_Multi_BD.Interfaces.Repositories
{
    public interface IStationRepository : IRepositoryBase<Station, int>
    {
    }
}