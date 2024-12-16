﻿using N_Tier.Application.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Student
{
    public class UpdateStudentModel
    {
        public virtual CreatePersonModel Person { get; set; }
        public Guid GroupId { get; set; }
    }
    public class UpdateStudentResponseModel : BaseResponseModel { }
}
