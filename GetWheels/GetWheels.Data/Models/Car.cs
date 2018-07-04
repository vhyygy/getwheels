using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GetWheels.Data.Models
{
    public class Car
    {
        [Key]
        [MaxLength(10)]
        public string PlateNo { get; set; }

        [MaxLength(60)]
        public string Model { get; set; }

        public int ReleaseYear { get; set; }

        public int TripsCount { get; set; }

        [ForeignKey("User")]
        public string OwnerId { get; set; }

        public User User { get; set; }
    }
}
