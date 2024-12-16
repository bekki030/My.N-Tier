using N_Tier.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Person
{
    public class UpdatePersonModel
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public GenderEnum Gender { get; set; }
    }
    public class UpdatePersonResponsemodel : BaseResponseModel { }
}
