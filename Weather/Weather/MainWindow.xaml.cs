using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;

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
            Output_3Days();
        }
        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            OutputNow();
        }

       public enum Param
        {
            paramNow = 1,
            param3Days
        };
        public void OutputNow() //вывод погоды "Сейчас"
        {
            
            WeatherNow now = new WeatherNow(); //содержит все Xpath 
            WeatherData[] DataNow = DefineWeather(now.Url, now.XPathTemp_1, now.XPathTemp_2, now.XPathPressure,
                                                  now.XPathWindSpeed, null, now.XPathWindDirection, now.XPathHumidity, now.XPathWater, (int)Param.paramNow);
            foreach (WeatherData day in DataNow)
            {
                TempNow.Content = day.Temperature.ToString();
                PressureNow.Content = $"Давление воздуха:  {day.Pressure} мм рт. ст.";
                if (day.WindSpeed_2 != 0)
                    WindNow.Content = $"Ветер:  {day.WindSpeed_1} м/с- {day.WindSpeed_2} м/с";
                else
                    WindNow.Content = $"Ветер:  {day.WindSpeed_1} м/с";
                WindNow.Content += day.WindDirection.ToString();
                HumidityNow.Content = $"Влажность:  {day.Humidity} %";
                WaterNow.Content = $"Температура воды:  {day.Water}";
            }
        }
        public void Output_3Days() //вывод погоды "Сегодня, Завтра, Послезавтра"
        {
           
            WeatherToday today = new WeatherToday();
            WeatherData[] DataToday = DefineWeather(today.Url, today.XPathTemp_1, null, today.XPathPressure,
                                                       today.XPathWindSpeed, null, today.XPathWindDirection, today.XPathHumidity, null, (int)Param.param3Days);
            WeatherTomorrow tomorrow = new WeatherTomorrow();
            WeatherData[] DataTomorrow = DefineWeather(tomorrow.Url, tomorrow.XPathTemp_1, null, tomorrow.XPathPressure,
                                                       tomorrow.XPathWindSpeed, null, tomorrow.XPathWindDirection, tomorrow.XPathHumidity, null, (int)Param.param3Days);

            WeatherDayAfterTomorrow dayAfterTomorrow = new WeatherDayAfterTomorrow();
            WeatherData[] DataDayAfterTomorrow = DefineWeather(dayAfterTomorrow.Url, dayAfterTomorrow.XPathTemp_1, null, dayAfterTomorrow.XPathPressure,
                                                       dayAfterTomorrow.XPathWindSpeed, null, dayAfterTomorrow.XPathWindDirection, dayAfterTomorrow.XPathHumidity, null, (int)Param.param3Days);
            int j = 1;//hour
            Console.WriteLine("Today");
            foreach (WeatherData day in DataToday)
            {
                Console.WriteLine($"Time {j}");
                Console.WriteLine($"Температура воздуха: {day.Temperature}");
                Console.WriteLine($"Давление воздуха:  {day.Pressure}");
                if (day.WindSpeed_2 != 0)
                    Console.WriteLine($"Скорость ветра:  {day.WindSpeed_1} - {day.WindSpeed_2}");
                else
                    Console.WriteLine($"Скорость ветра:  {day.WindSpeed_1}");
                Console.WriteLine($"Направление ветра:  {day.WindDirection}");
                Console.WriteLine($"Влажность:  {day.Humidity}");
                j += 3;
                Console.WriteLine();
            }

            j = 1;
            Console.WriteLine("Tomorrow");
            foreach (WeatherData day in DataTomorrow)
            {
                Console.WriteLine($"Time {j}");
                Console.WriteLine($"Температура воздуха: {day.Temperature}");
                Console.WriteLine($"Давление воздуха:  {day.Pressure}");
                if (day.WindSpeed_2 != 0)
                    Console.WriteLine($"Скорость ветра:  {day.WindSpeed_1} - {day.WindSpeed_2}");
                else
                    Console.WriteLine($"Скорость ветра:  {day.WindSpeed_1}");
                Console.WriteLine($"Направление ветра:  {day.WindDirection}");
                Console.WriteLine($"Влажность:  {day.Humidity}");
                j += 3;
                Console.WriteLine();
            }
           

            j = 1;
            Console.WriteLine("DayAfterTomorrow");
            foreach (WeatherData day in DataDayAfterTomorrow)
            {
                Console.WriteLine($"Time {j}");
                Console.WriteLine($"Температура воздуха: {day.Temperature}");
                Console.WriteLine($"Давление воздуха:  {day.Pressure}");
                if (day.WindSpeed_2 != 0)
                    Console.WriteLine($"Скорость ветра:  {day.WindSpeed_1} - {day.WindSpeed_2}");
                else
                    Console.WriteLine($"Скорость ветра:  {day.WindSpeed_1}");
                Console.WriteLine($"Направление ветра:  {day.WindDirection}");
                Console.WriteLine($"Влажность:  {day.Humidity}");
                j += 3;
                Console.WriteLine();
            }
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
