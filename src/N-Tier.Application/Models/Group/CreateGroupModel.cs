using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Group
{
    public class CreateGroupModel
    {
        public string Name { get; set; }
        public Guid StudentId { get; set; }
    }
    public class CreateGroupResponseModel : BaseResponseModel { }
}
