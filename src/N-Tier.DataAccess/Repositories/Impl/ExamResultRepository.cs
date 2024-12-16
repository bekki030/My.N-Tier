using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class ExamResultRepository : BaseRepository<ExamResult>, IExamResultRepository
{
    public ExamResultRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
