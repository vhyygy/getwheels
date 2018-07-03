using System;
using System.Collections.Generic;
using System.Text;

namespace GetWheels.Data.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public int TripsCount { get; set; }

        public List<Trip> Trips { get; set; }

        public List<Car> Cars { get; set; }
    }
}
