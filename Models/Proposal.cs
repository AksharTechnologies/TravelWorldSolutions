using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsClassLibrary
{
    public class ProposalModel
    {

        public int ProposalId { get; set; }
        public string ClientName { get; set; }
        public int NumberOfPersons { get; set; }
        public int NumberOfRooms { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public List<string> listOfHotelIds { get; set; }
        
    }
}
