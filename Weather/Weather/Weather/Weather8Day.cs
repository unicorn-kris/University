using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    class Weather8Day : WeatherLinks
    {
        public Weather8Day()
        {
            url = "https://www.gismeteo.ru/weather-saratov-5032/8-day/";
            xPathTemp_1 = "/html/body/section/div[2]/div/div[1]/div/div[2]/div[1]/div[2]/div/div[1]/div/div[3]/div/div/div/div/span[1]";
            xPathPressure = "/html/body/section/div[2]/div/div[1]/div/div[2]/div[12]/div/div[2]/div[2]/div[2]/div/div/div/div/span[1]";
            xPathWindSpeed = "/html/body/section/div[2]/div/div[1]/div/div[2]/div[1]/div[2]/div/div[1]/div/div[5]/div/div/div/span[1]/text()";
            xPathWindDirection = "/html/body/section/div[2]/div/div[1]/div/div[2]/div[7]/div/div[2]/div[2]/div[2]/div/div/div[3]";
            xPathHumidity = "/html/body/section/div[2]/div/div[1]/div/div[2]/div[13]/div/div[2]/div[2]/div[2]/div/div";
        }
        public new string Url => url;
        public new string XPathTemp_1 => xPathTemp_1;
        public new string XPathPressure => xPathPressure;
        public new string XPathWindSpeed => xPathWindSpeed;
        public new string XPathWindDirection => xPathWindDirection;
        public new string XPathHumidity => xPathHumidity;
    }
}
