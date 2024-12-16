using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class StudentBehaviorRepository : BaseRepository<StudentBehavior>, IStudentBehaviorRepository
{
    public StudentBehaviorRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
