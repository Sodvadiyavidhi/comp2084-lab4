using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PhoneApplication.Models
{
    public class Phone
    {
        public Phone()
        {
            DateReleased = DateTime.Now;
            PhoneName = "";


        }
        [ForeignKey("Manufacturer")]
        public int ManufacturerID { get; set; }
        [Key] public int  PhoneID { get; set; }
        public string PhoneName { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public double MSRP { get; set; }
        public int ScreenSize { get; set; }
        public DateTime DateReleased { get; set; }
    }
}