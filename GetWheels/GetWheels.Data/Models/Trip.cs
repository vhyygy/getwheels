using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GetWheels.Data.Models
{
    public class Trip
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string CarPlateNo { get; set; }

        [ForeignKey("LocationFrom")]
        public Guid LocationFromId { get; set; }

        [ForeignKey("LocationToId")]
        public Guid LocationToId { get; set; }

        [ForeignKey("Tenant")]
        public string TenantId { get; set; }

        public User Tenant { get; set; }

        public Location LocationFrom { get; set; }

        public Location LocationTo { get; set; }
    }
}
