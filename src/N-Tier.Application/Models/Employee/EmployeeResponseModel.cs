using N_Tier.Application.Models.Person;
using N_Tier.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Employee
{
    public class EmployeeResponseModel : BaseResponseModel
    {
        public PersonResponseModel Person { get; set; }
        public PositionEnum Position { get; set; }
    }
}
