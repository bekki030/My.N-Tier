using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class ShiftRepository : BaseRepository<Shift>, IShiftRepository
{
    public ShiftRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
