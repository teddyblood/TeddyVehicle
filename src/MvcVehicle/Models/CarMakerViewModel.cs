using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcVehicle.Models
{
    public class CarMakerViewModel
    {
        public List<Vehicle> vehicles;
        public SelectList makers;
        public string carMakersearch { get; set; }

    }
}
