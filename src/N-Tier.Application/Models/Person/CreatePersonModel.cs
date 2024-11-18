using N_Tier.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Person
{
    public class CreatePersonModel
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public GenderEnum Gender { get; set; }
    }
    public class CreatePersonResponseModel : BaseResponseModel { }
}
