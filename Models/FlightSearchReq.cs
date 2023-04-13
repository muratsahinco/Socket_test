using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FlightSearchReq
    {
        public string AirportCode { get; set; } = "Saw";
        public string DepartureDate { get; set; } = "2022-07-07";
        public string ArrivalDatre { get; set; } = "2022-07-07";
        public int AdultPax { get; set; } = 3;
        public int ChildPax { get; set; } = 1;
        public int InftPax { get; set; } = 0;
    }
}
