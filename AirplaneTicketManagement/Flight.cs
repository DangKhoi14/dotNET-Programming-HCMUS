using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTicketManagement
{
    public class Flight
    {
        public string FlightID { get; set; }
        public DateTime TimeDepart {  get; set; }
        public DateTime TimeArrival { get; set; }
        public string FlightType { get; set; }
    }
}
