using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GetWheels.Data.Models
{
    public class Booking
    {
        [Key]
        [StringLength(10)]
        public string Id { get; set; }

        public DateTime DateBooked { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public BookingStatus Status { get; set; }

        [ForeignKey("Car")]
        public string PlateNo { get; set; }

        [ForeignKey("Passenger")]
        public string PassengerId { get; set; }

        public Car Car { get; set; }

        public User Passenger { get; set; }
    }
}
