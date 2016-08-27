using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsClassLibrary
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string ContactPersonName { get; set; }
        public int Rating { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int City { get; set; }
        public int State { get; set; }
        public string Pin { get; set; }
        public string EmailAddress1 { get; set; }
        public string EmailAddress2 { get; set; }
        public int HotelType { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
    }
}
