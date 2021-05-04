using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    abstract class WeatherDataLinks
    {
        protected string url;
        protected string xPathTemp_1;
        protected string xPathPressure;
        protected string xPathWindSpeed;
        protected string xPathWindDirection;
        protected string xPathHumidity;

        public string Url { get; }
        public string XPathTemp_1 { get; }
        public string XPathPressure { get; }
        public string XPathWindSpeed { get; }
        public string XPathWindDirection { get; }
        public string XPathHumidity { get; }
    }
}
