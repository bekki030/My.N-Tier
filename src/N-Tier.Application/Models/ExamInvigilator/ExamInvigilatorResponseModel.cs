﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.ExamInvigilator;

public class ExamInvigilatorResponseModel : BaseResponseModel
{
    public DateTime AssignedDate { get; set; }
}
