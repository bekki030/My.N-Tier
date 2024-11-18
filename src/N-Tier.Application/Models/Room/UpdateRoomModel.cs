using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Room
{
    public class UpdateRoomModel
    {
        public string Name { get; set; }
        public int RoomNumber { get; set; }
    }
    public class UpdateRoomResponseModel : BaseResponseModel { }
}
