namespace N_Tier.Application.Models.Shift;

public class UpdateShiftModel
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
public class UpdateShiftResponseModel : BaseResponseModel { }
