using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using HtmlAgilityPack;
using System.IO;
using System.Threading;

namespace Weather
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OutputNow();
        }
        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            OutputNow();
        }
       
        public void OutputNow() //вывод погоды "Сейчас"
        {
            WeatherNow now = new WeatherNow(); //содержит все Xpath 
                WeatherData[] DataNow = DefineWeather(now.Url, now.XPathTemp_1, now.XPathTemp_2, now.XPathPressure,
                                                      now.XPathWindSpeed, null, now.XPathWindDirection, now.XPathHumidity, now.XPathWater, 1);
                foreach (WeatherData day in DataNow)
                {
                    TempNow.Content = day.Temperature.ToString();
                    PressureNow.Content = $"Давление воздуха:  {day.Pressure}";
                    if (day.WindSpeed_2 != 0)
                        WindNow.Content = $"Ветер:  {day.WindSpeed_1} - {day.WindSpeed_2} ";
                    else
                        WindNow.Content = $"Ветер:  {day.WindSpeed_1} ";
                    WindNow.Content += day.WindDirection.ToString();
                    HumidityNow.Content = $"Влажность:  {day.Humidity}";
                    WaterNow.Content = $"Температура воды:  {day.Water}";
                }
        }
        public void Output_3Days() //вывод погоды "Сегодня, Завтра, Послезавтра"
        {
            //WeatherNow now = new WeatherNow(); //содержит все Xpath 
            //WeatherData[] DataNow = DefineWeather(now.Url, now.XPathTemp_1, now.XPathTemp_2, now.XPathPressure,
            //                                      now.XPathWindSpeed, null, now.XPathWindDirection, now.XPathHumidity, now.XPathWater, 1);
            //foreach (WeatherData day in DataNow)
            //{
            //    TempNow.Content = day.Temperature.ToString();
            //    PressureNow.Content = $"Давление воздуха:  {day.Pressure}";
            //    if (day.WindSpeed_2 != 0)
            //        WindNow.Content = $"Ветер:  {day.WindSpeed_1} - {day.WindSpeed_2} ";
            //    else
            //        WindNow.Content = $"Ветер:  {day.WindSpeed_1} ";
            //    WindNow.Content += day.WindDirection.ToString();
            //    HumidityNow.Content = $"Влажность:  {day.Humidity}";
            //    WaterNow.Content = $"Температура воды:  {day.Water}";
            //}
        }
        public struct WeatherData //элемент, хранящий данные о погоде
        {
            public double Temperature;
            public int Pressure;
            public int Humidity;
            public int WindSpeed_1;
            public int WindSpeed_2;
            public string WindDirection;
            public string Water;
        }
        public string LoadPage(string url) //загрузка страницы
        {
            string result = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                if (receiveStream != null)
                {
                    StreamReader readStream;
                    if (response.CharacterSet == null)
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    result = readStream.ReadToEnd();
                    readStream.Close();
                }
                response.Close();
            }
            return result;
        }
        public WeatherData[] DefineWeather(string url, string xPathTemp_1, string xPathTemp_2, string xPathPressure, string xPathWindSpeed, string xPathWindSpeed_2,
                                          string xPathWindDirection, string xPathHumidity, string xPathWater, int Param) //парсер
        {
            WeatherData[] dates = new WeatherData[0];
            int i = 0;
            if (Param == 1) //now
            {
                dates = new WeatherData[1];
                i = 1;
            }
            if (Param == 2) //tomorrow
            {
                dates = new WeatherData[8];
                i = 8;
            }
            if (Param == 3) //3 days
            {
                dates = new WeatherData[12];
                i = 12;
            }

            string pageContent = LoadPage(url);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(pageContent);

            //temperature
            HtmlNodeCollection linkTemp = document.DocumentNode.SelectNodes(xPathTemp_1);
            string[] temperature1 = new string[i];
            int k = 0;
            foreach (HtmlNode link in linkTemp)
                if (k < i)
                {
                    temperature1[k] = link.InnerText;
                    ++k;
                }

            for (int j = 0; j < i; ++j)
            {
                int minus = temperature1[j].IndexOf('m'); //if temp < 0

                while (!char.IsDigit(temperature1[j][0]))
                {
                    temperature1[j] = temperature1[j].Remove(0, 1);
                }
                dates[j].Temperature = int.Parse(temperature1[j]);

                if (xPathTemp_2 != null) //если есть дробная часть
                {
                    HtmlNode linkTemp_1day_2 = document.DocumentNode.SelectSingleNode(xPathTemp_2);

                    string temperature2 = "";
                    if (linkTemp_1day_2 != null)
                    {
                        temperature2 = linkTemp_1day_2.InnerText;
                        dates[j].Temperature += (int.Parse(temperature2.Remove(0, 1)) * 0.1);
                    }
                }
                if (minus >= 0) //если температура меньше нуля
                {
                    dates[j].Temperature *= -1;
                }
            }

            //pressure
            HtmlNodeCollection linkpressure = document.DocumentNode.SelectNodes(xPathPressure);
            string[] pressure = new string[i];
            k = 0;
            foreach (HtmlNode link in linkpressure)
            {
                pressure[k] = link.InnerText;
                ++k;
            }
            for (int j = 0; j < i; ++j)
            {
                dates[j].Pressure = int.Parse(pressure[j]);
            }

            //wind speed
            HtmlNodeCollection linkwindspeed = document.DocumentNode.SelectNodes(xPathWindSpeed);
            string[] wind1_2 = new string[i];
            char[] separators = new char[] { '-', ' ', '\0', '\n' };
            k = 0;
            foreach (HtmlNode link in linkwindspeed)
            {
                wind1_2[k] = link.InnerText;
                ++k;
            }
            for (int j = 0; j < i; ++j)
            {
                string[] wind = wind1_2[j].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                dates[j].WindSpeed_1 = int.Parse(wind[0]);
                if (wind.Length > 1)
                    dates[j].WindSpeed_2 = int.Parse(wind[1]);
            }
            if (xPathWindSpeed_2 != null) //только для 3 дней
            {
                HtmlNodeCollection linkwindspeed2 = document.DocumentNode.SelectNodes(xPathWindSpeed_2);
                string[] wind2 = new string[i];
                char[] separator = new char[] { '-', ' ', '\0', '\n' };
                k = 0;
                foreach (HtmlNode link in linkwindspeed2)
                {
                    wind2[k] = link.InnerText;
                    ++k;
                }
                for (int j = 0; j < i; ++j)
                {
                    string[] wind = wind2[j].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    if (wind[0] != "&mdash;")
                        dates[j].WindSpeed_2 = int.Parse(wind[0]);
                    else
                        dates[j].WindSpeed_2 = 0;
                }
            }

            //wind direction
            HtmlNodeCollection linkWindDirection = document.DocumentNode.SelectNodes(xPathWindDirection);
            string[] WindDirection = new string[i];
            k = 0;
            foreach (HtmlNode link in linkWindDirection)
            {
                WindDirection[k] = link.InnerText;
                ++k;
            }
            for (int j = 0; j < i; ++j)
            {
                string[] directions = WindDirection[j].Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                dates[j].WindDirection = directions[0];
            }

            //humidity
            HtmlNodeCollection linkHumidity = document.DocumentNode.SelectNodes(xPathHumidity);
            string[] Humidity = new string[i];
            k = 0;
            foreach (HtmlNode link in linkHumidity)
            {
                Humidity[k] = link.InnerText;
                ++k;
            }
            for (int j = 0; j < i; ++j)
            {
                dates[j].Humidity = int.Parse(Humidity[j]);
            }

            //water
            if (xPathWater != null) //доступно только для "сейчас"
            {
                HtmlNode linkWater_1day = document.DocumentNode.SelectSingleNode(xPathWater);
                string TemperatureWater = linkWater_1day.InnerText;

                //int plus = TemperatureWater.IndexOf('+');
                //if (plus >= 0)
                //{
                //    TemperatureWater = TemperatureWater.Remove(0, plus);
                //    int j = 0;
                //    while (Char.IsDigit(TemperatureWater[j]))
                //    {
                //        dates[0].Water += TemperatureWater[j];
                //        ++j;
                //    }
                //}
                //else
                //{
                //    int j = 1;
                //    while (!Char.IsDigit(TemperatureWater[j]))
                //    {
                //        TemperatureWater.Remove(0, j);
                //    }
                    dates[0].Water = TemperatureWater;
            }
            return dates;
        }

       
    }
    
}
