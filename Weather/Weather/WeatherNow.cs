using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    class WeatherNow : WeatherLinks
    {
        private string xPathTemp_2;
        private string xPathWater;
        public WeatherNow()
        {
            url = "https://www.gismeteo.ru/weather-saratov-5032/now/";
            xPathTemp_1 = "./html/body/section/div[2]/div/div[1]/div/div[2]/div[1]/div[1]/div/div/div[1]/div[3]/div[1]/span[1]/span/text()";
            xPathTemp_2 = "./html/body/section/div[2]/div/div[1]/div/div[2]/div[1]/div[1]/div/div/div[1]/div[3]/div[1]/span[1]/span/span";
            xPathPressure = "/html/body/section/div[2]/div/div[1]/div/div[2]/div[1]/div[2]/div/div[6]/div[2]/div/div[2]/div[1]";
            xPathWindSpeed = "./html/body/section/div[2]/div/div[1]/div/div[2]/div[1]/div[2]/div/div[6]/div[1]/div/div[2]/div[1]/text()";
            xPathWindDirection = "/html/body/section/div[2]/div/div[1]/div/div[2]/div[1]/div[2]/div/div[6]/div[1]/div/div[2]/div[2]/text()[2]";
            xPathHumidity = "/html/body/section/div[2]/div/div[1]/div/div[2]/div[1]/div[2]/div/div[6]/div[3]/div/div[2]";
            xPathWater = "./html/body/section/div[2]/div/div[1]/div/div[2]/div[1]/div[2]/div/div[6]/div[5]/div/div[2]/div[1]";
        }
        public new string Url => url;
        public new string XPathTemp_1 => xPathTemp_1;
        public string XPathTemp_2 => xPathTemp_2;
        public new string XPathPressure => xPathPressure;
        public new string XPathWindSpeed => xPathWindSpeed;
        public new string XPathWindDirection => xPathWindDirection;
        public new string XPathHumidity => xPathHumidity;
        public string XPathWater => xPathWater;
    }
}
