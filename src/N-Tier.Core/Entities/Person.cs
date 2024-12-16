using N_Tier.Core.Common;
using N_Tier.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities;

public class Person : BaseEntity,IAuditedEntity
{
    public string FullName { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
    public GenderEnum Gender { get; set; }
    public string? CreatedBy { get ; set; }
    public DateTime? CreatedOn { get; set; }
    public string?  UpdatedBy { get ; set ; }
    public DateTime? UpdatedOn { get; set; }
}
