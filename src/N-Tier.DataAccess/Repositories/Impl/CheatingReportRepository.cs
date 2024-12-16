using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class CheatingReportRepository : BaseRepository<CheatingReport>, ICheatingReportRepository
{
    public CheatingReportRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
