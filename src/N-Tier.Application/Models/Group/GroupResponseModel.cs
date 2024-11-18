using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Group
{
    public class GroupResponseModel : BaseResponseModel
    {
        public string Name { get; set; }
        public Guid StudentId { get; set; }
    }
}
