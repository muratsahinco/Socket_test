using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FlightSearchRes
    {
        public string SearchId { get; set; } = Guid.NewGuid().ToString();
        public string ResponseDate { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

        public List<FlightList> Flights { get; set; }
    }

    public class FlightList
    {
        public string MarketingAirline { get; set; } = "Pegasus";

        public string AirportCode { get; set; } = "Saw";
        public string DepartureDate { get; set; } = "2022-07-07";
        public string ArrivalDatre { get; set; } = "2022-07-07";

        public decimal Price { get; set; } = 500;
        public DateTime FlightDate { get; set; }= DateTime.Now.AddDays(-2);
    }
}
