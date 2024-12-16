using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class ExamSessionRepository : BaseRepository<ExamSession>, IExamSessionRepository
{
    public ExamSessionRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
