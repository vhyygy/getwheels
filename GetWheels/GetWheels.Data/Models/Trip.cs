using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GetWheels.Data.Models
{
    public class Trip
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Location From { get; set; }

        public Location To { get; set; }

        public string CarPlateNo { get; set; }

        [ForeignKey("Tenant")]
        public Guid TenantId { get; set; }

        public User Tenant { get; set; }
    }
}
