using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTicketManagement
{
    public class Flight
    {
        public string FlightID;
        public string Start;
        public string End;
        public DateTime TimeDepart;
        public DateTime TimeArrival;
        public string Airline;
    
        public Flight(string start, string end, DateTime timeDepart, DateTime timeArrival, string airline)
        {
            FlightID = airline + start + end + timeDepart.ToString();
            Start = start;
            End = end;
            TimeDepart = timeDepart;
            TimeArrival = timeArrival;
            Airline = airline;
        }
    }
}
