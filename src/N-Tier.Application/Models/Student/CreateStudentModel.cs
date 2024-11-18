using N_Tier.Application.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Student
{
    public class CreateStudentModel
    {
        public Guid PersonId { get; set; }
        public PersonResponseModel Person { get; set; }
    }
    public class CreateStudentResponseModel : BaseResponseModel { }
}
