using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Room
{
    public class CreateRoomModel
    {
        public string Name { get; set; }
        public int RoomNumber { get; set; }
    }
    public class CreateRoomResponseModel : BaseResponseModel { }
}
