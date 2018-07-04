using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;

namespace GetWheels.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public int TripsCount { get; set; }

        public int BookingCount { get; set; }

        public List<Trip> Trips { get; set; }

        public List<Booking> Bookings { get; set; }

        public List<Car> Cars { get; set; }
    }
}
