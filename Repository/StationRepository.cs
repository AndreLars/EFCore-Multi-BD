using EFCore_Multi_BD.Context;
using EFCore_Multi_BD.Entities;
using EFCore_Multi_BD.Interfaces.Repositories;
using EFCore_Multi_BD.Repository.Base;

namespace EFCore_Multi_BD.Repository
{
    public class StationRepository : RepositoryBase<Station, int>, IStationRepository
    {
        public StationRepository(GasStationContext context) : base(context)
        { }
    }
}