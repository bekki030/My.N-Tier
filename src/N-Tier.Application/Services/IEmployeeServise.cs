using N_Tier.Application.Models.TodoItem;
using N_Tier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Employee;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services
{
    public interface IEmployeeServise
    {
        Task<CreateEmployeeResponseModel> CreateAsync(CreateEmployeeModel createEmployeeModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<EmployeeResponseModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateEmployeeResponseModel> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel,
            CancellationToken cancellationToken = default);
    }
}
