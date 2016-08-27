using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace TravelWorldSolutions.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string ContactPersonName { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine2 { get; set; }
        [Required]
        public int City { get; set; }
        [Required]
        public int State { get; set; }
        [Required]
        public string Pin { get; set; }
        [Required]
        public string EmailAddress1 { get; set; }
        [Required]
        public string EmailAddress2 { get; set; }
        [Required]
        public int HotelType { get; set; }
        [Required]
        public string PhoneNumber1 { get; set; }

        public string PhoneNumber2 { get; set; }
    }
}