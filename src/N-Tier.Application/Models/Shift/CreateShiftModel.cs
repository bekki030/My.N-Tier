namespace N_Tier.Application.Models.Shift;

public class CreateShiftModel
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
public class CreateShiftResponseModel : BaseResponseModel { }
