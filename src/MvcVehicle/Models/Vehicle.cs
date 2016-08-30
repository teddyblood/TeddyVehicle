using System;
using System.ComponentModel.DataAnnotations;



namespace MvcVehicle.Models
{
    public class Vehicle
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength =3), Display(Name ="Car Model")]
        public string CarModel { get; set; }

        [DisplayFormat(DataFormatString= "{0:yyyy-MM}", ApplyFormatInEditMode = true), DataType(DataType.Date)]
        public DateTime SOP { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$"), Required , StringLength(30)]
        public string Maker { get; set; }

        [Range(1,10000)]
        public decimal EGsize { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$") ,StringLength(30)]
        public string Transmission { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$") ,StringLength(30)]
        public string Hybrid { get; set; }

    }
}
