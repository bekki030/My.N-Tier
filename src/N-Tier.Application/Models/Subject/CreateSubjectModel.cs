﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Subject
{
    public class CreateSubjectModel
    {
        public string Name { get; set; }
    }
    public class CreateSubjectResponseModel : BaseResponseModel { }
}