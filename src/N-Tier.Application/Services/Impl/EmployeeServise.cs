using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Employee;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Services.Impl
{
    public class EmployeeServise : IEmployeeServise
    {
        private readonly IEmployeeRepository _employeeServise;
        private readonly IMapper _mapper;
        public EmployeeServise(IMapper mapper,IEmployeeRepository employeeServise)
        {
            _employeeServise = employeeServise;
            _mapper = mapper;
        }
        public async Task<CreateEmployeeResponseModel> CreateAsync(CreateEmployeeModel createEmployeeModel, CancellationToken cancellationToken = default)
        {
            var employee = _mapper.Map<Employee>(createEmployeeModel);
            return new CreateEmployeeResponseModel 
            { 
              Id = (await _employeeServise.AddAsync(employee)).Id,
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var employee = await _employeeServise.GetFirstAsync(x=> x.Id == id);
            return new BaseResponseModel
            {
                Id = (await _employeeServise.DeleteAsync(employee)).Id,
            };
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var employee = await _employeeServise.GetAllAsync(x=> x.Id == id,include:x=>x.Include(x=>x.Person));
            return _mapper.Map<IEnumerable<EmployeeResponseModel>>(employee);
        }

        public async Task<UpdateEmployeeResponseModel> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel, CancellationToken cancellationToken = default)
        {
            var employee = await _employeeServise.GetFirstAsync(x=> x.Id == id);
            _mapper.Map(employee, updateEmployeeModel);
            return new UpdateEmployeeResponseModel
            {
                Id = (await _employeeServise.UpdateAsync(employee)).Id,
            };
        }
    }
}
