using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
     class WeatherLink: WeatherDataLinks
    {
        private string _urlToday = "https://www.gismeteo.ru/weather-saratov-5032/";
        private string _urlTomorrow = "https://www.gismeteo.ru/weather-saratov-5032/tomorrow/";
        private string _urlDayAfterTomorrow = "https://www.gismeteo.ru/weather-saratov-5032/3-day/";
        private string _url4Day = "https://www.gismeteo.ru/weather-saratov-5032/4-day/";
        private string _url5Day = "https://www.gismeteo.ru/weather-saratov-5032/5-day/";
        private string _url6Day = "https://www.gismeteo.ru/weather-saratov-5032/6-day/";
        private string _url7Day = "https://www.gismeteo.ru/weather-saratov-5032/7-day/";
        private string[] _weatherUrls ;
        public WeatherLink()
        {
            _weatherUrls = new [] { _urlToday, _urlTomorrow, _urlDayAfterTomorrow, _url4Day, _url5Day, _url6Day, _url7Day};
            xPathTemp_1 = "/html/body/section/div[2]/div/div[1]/div/div[2]/div[1]/div[2]/div/div[1]/div/div[3]/div/div/div/div/span[1]";
            xPathPressure = "/html/body/section/div[2]/div/div[1]/div/div[2]/div[12]/div/div[2]/div[2]/div[2]/div/div/div/div/span[1]";
            xPathWindSpeed = "/html/body/section/div[2]/div/div[1]/div/div[2]/div[1]/div[2]/div/div[1]/div/div[5]/div/div/div/span[1]/text()";
            xPathWindDirection = "/html/body/section/div[2]/div/div[1]/div/div[2]/div[7]/div/div[2]/div[2]/div[2]/div/div/div[3]";
            xPathHumidity = "./html/body/section/div[2]/div/div/div/div[2]/div[13]/div/div[2]/div[2]/div[2]/div/div";
        }
        public string[] WeatherUrls => _weatherUrls;
        public new string XPathTemp_1 => xPathTemp_1;
        public new string XPathPressure => xPathPressure;
        public new string XPathWindSpeed => xPathWindSpeed;
        public new string XPathWindDirection => xPathWindDirection;
        public new string XPathHumidity => xPathHumidity;

        //public string UrlToday => _urlToday;
        //public string UrlTomorrow => _urlToday;
        //public string UrlDayAtferTomorrow => _urlToday;
        //public string Url4Day => urlToday;
        //public string Url5Day => urlToday;
        //public string Url6Day => urlToday;
        //public string Url7Day => urlToday;
        //public string Url8Day => urlToday;
        //public string Url9Day => urlToday;
        //public string Url10Day => urlToday;

    }
}
