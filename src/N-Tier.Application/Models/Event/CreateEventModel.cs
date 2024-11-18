using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Event
{
    public class CreateEventModel
    {
        public string Name { get; set; }
        public Guid StudentId { get; set; }
    }
    public class CreateEventResponseModel : BaseResponseModel { }
}
