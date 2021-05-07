using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Data;

namespace Weather
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.SizeToContent = SizeToContent.Height;
            InitializeComponent();
            OutputNow();
            Output_3Days();
            SaveData();

        }
        private void Button_Update_Click(object sender, EventArgs e)
        {
            OutputNow();
            Output_3Days();
        }
        public enum Param
        {
            paramNow = 1,
            paramDays
        };
        public WeatherData[] WeatherDataNow()
        {

            WeatherNow now = new WeatherNow(); //содержит все Xpath 
            WeatherData[] DataNow = DefineWeather(now.Url, now.XPathTemp_1, now.XPathTemp_2, now.XPathPressure,
                                                  now.XPathWindSpeed, null, now.XPathWindDirection, now.XPathHumidity, now.XPathWater, (int)Param.paramNow);
            return DataNow;
        }
        //public WeatherData[] WeatherDataToday()
        //{

        //    WeatherToday today = new WeatherToday();
        //    WeatherData[] DataToday = DefineWeather(today.Url, today.XPathTemp_1, null, today.XPathPressure,
        //                                               today.XPathWindSpeed, null, today.XPathWindDirection, today.XPathHumidity, null, (int)Param.param3Days);
        //    return DataToday;
        //}
        //public WeatherData[] WeatherDataTomorrow()
        //{

        //    WeatherTomorrow tomorrow = new WeatherTomorrow();
        //    WeatherData[] DataTomorrow = DefineWeather(tomorrow.Url, tomorrow.XPathTemp_1, null, tomorrow.XPathPressure,
        //                                               tomorrow.XPathWindSpeed, null, tomorrow.XPathWindDirection, tomorrow.XPathHumidity, null, (int)Param.param3Days);
        //    return DataTomorrow;
        //}
        //public WeatherData[] WeatherDataDayAfterTomorrow()
        //{

        //    WeatherDayAfterTomorrow dayAfterTomorrow = new WeatherDayAfterTomorrow();
        //    WeatherData[] DataDayAfterTomorrow = DefineWeather(dayAfterTomorrow.Url, dayAfterTomorrow.XPathTemp_1, null, dayAfterTomorrow.XPathPressure,
        //                                               dayAfterTomorrow.XPathWindSpeed, null, dayAfterTomorrow.XPathWindDirection, dayAfterTomorrow.XPathHumidity, null, (int)Param.param3Days);
        //    return DataDayAfterTomorrow;
        //}
        //public WeatherData[] WeatherData4Day()
        //{

        //    Weather4Day w4day = new Weather4Day();
        //    WeatherData[] Data4Day = DefineWeather(w4day.Url, w4day.XPathTemp_1, null, w4day.XPathPressure,
        //                                               w4day.XPathWindSpeed, null, w4day.XPathWindDirection, w4day.XPathHumidity, null, (int)Param.param3Days);
        //    return Data4Day;
        //}
        public WeatherData[] GetWeatherData(string url)
        {

            WeatherLink weather = new WeatherLink();
            WeatherData[] weatherData = DefineWeather(url, weather.XPathTemp_1, null, weather.XPathPressure,
                                                       weather.XPathWindSpeed, null, weather.XPathWindDirection, weather.XPathHumidity, null, (int)Param.paramDays);
            return weatherData;
        }
        public struct WeatherData //структура - данные о погоде
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
            HttpWebResponse response = null;
            string result = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                Status.Text = "Подключение установлено";
                Grid0.Visibility = Visibility.Visible;
                Grid1.Visibility = Visibility.Visible;
                Grid2.Visibility = Visibility.Visible;
            }
            catch
            {
                if (Status.Dispatcher.CheckAccess())
                {
                    Status.Text = "Ошибка подключения, повторите попытку";
                    Grid0.Visibility = Visibility.Hidden;
                    Grid1.Visibility = Visibility.Hidden;
                    Grid2.Visibility = Visibility.Hidden;
                }
                return null;
            }

            if (response != null && response.StatusCode == HttpStatusCode.OK)
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

            string pageContent = LoadPage(url);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            if (pageContent != "" && pageContent != null)
            {
                document.LoadHtml(pageContent);
                int k = 0;
                //temperature
                HtmlNodeCollection linkTemp = document.DocumentNode.SelectNodes(xPathTemp_1);
                if (linkTemp != null)
                {
                    string[] temperature1 = new string[i];
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
                            try
                            {
                                dates[j].Temperature *= -1;
                            }
                            catch
                            {
                                dates[j].Temperature = double.MaxValue;
                            }
                        }
                    }
                }
                else
                    for (int j = 0; j < i; ++j)
                    {
                        dates[j].Temperature = double.MaxValue;
                    }


                //pressure
                HtmlNodeCollection linkpressure = document.DocumentNode.SelectNodes(xPathPressure);
                if (linkpressure != null)
                {
                    string[] pressure = new string[i];
                    k = 0;
                    foreach (HtmlNode link in linkpressure)
                    {
                        pressure[k] = link.InnerText;
                        ++k;
                    }
                    for (int j = 0; j < i; ++j)
                    {
                        try
                        {
                            dates[j].Pressure = int.Parse(pressure[j]);
                        }
                        catch
                        {
                            dates[j].Pressure = int.MaxValue;
                        }
                    }
                }
                else
                    for (int j = 0; j < i; ++j)
                    {
                        dates[j].Pressure = int.MaxValue;
                    }

                //wind speed
                HtmlNodeCollection linkwindspeed = document.DocumentNode.SelectNodes(xPathWindSpeed);
                if (linkwindspeed != null)
                {
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
                            try
                            {
                                string[] wind = wind2[j].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                                if (wind[0] != "&mdash;")
                                    dates[j].WindSpeed_2 = int.Parse(wind[0]);
                                else
                                    dates[j].WindSpeed_2 = 0;
                            }
                            catch
                            {
                                dates[j].WindSpeed_1 = int.MaxValue;
                                dates[j].WindSpeed_2 = int.MaxValue;
                            }
                        }
                    }
                }
                else
                    for (int j = 0; j < i; ++j)
                    {
                        dates[j].WindSpeed_1 = int.MaxValue;
                        dates[j].WindSpeed_2 = int.MaxValue;
                    }

                //wind direction
                HtmlNodeCollection linkWindDirection = document.DocumentNode.SelectNodes(xPathWindDirection);
                if (linkWindDirection != null)
                {
                    string[] WindDirection = new string[i];
                    k = 0;
                    foreach (HtmlNode link in linkWindDirection)
                    {
                        WindDirection[k] = link.InnerText;
                        ++k;
                    }
                    for (int j = 0; j < i; ++j)
                    {
                        try
                        {
                            string[] directions = WindDirection[j].Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                            dates[j].WindDirection = directions[0];
                        }
                        catch
                        {
                            dates[j].WindDirection = "";
                        }
                    }
                }
                else
                    for (int j = 0; j < i; ++j)
                    {
                        dates[j].WindDirection = "";
                    }

                //humidity
                HtmlNodeCollection linkHumidity = document.DocumentNode.SelectNodes(xPathHumidity);
                if (linkHumidity != null)
                {
                    string[] Humidity = new string[i];
                    k = 0;
                    foreach (HtmlNode link in linkHumidity)
                    {
                        Humidity[k] = link.InnerText;
                        ++k;
                    }
                    for (int j = 0; j < i; ++j)
                    {
                        try
                        {
                            dates[j].Humidity = int.Parse(Humidity[j]);
                        }
                        catch
                        {
                            dates[j].Humidity = int.MaxValue;
                        }
                    }
                }
                else
                    for (int j = 0; j < i; ++j)
                    {
                        dates[j].Humidity = int.MaxValue;
                    }

                //water
                if (xPathWater != null) //доступно только для "сейчас"
                {
                    HtmlNode linkWater_1day = document.DocumentNode.SelectSingleNode(xPathWater);
                    if (linkWater_1day != null)
                    {
                        string TemperatureWater = linkWater_1day.InnerText;
                        dates[0].Water = TemperatureWater;
                    }
                    else
                        dates[0].Water = "";
                }
            }
            return dates;
        }
        public void OutputNow() //вывод погоды "Сейчас"
        {
            WeatherData[] DataNow = WeatherDataNow();
            Date.Content = $"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}";

            foreach (WeatherData day in DataNow)
            {
                if (day.Temperature != double.MaxValue)
                    TempNow.Content = $"{day.Temperature}℃";
                if (day.Pressure != int.MaxValue)
                    PressureNow.Content = $"Давление воздуха:  {day.Pressure} мм рт. ст.";
                if (day.WindSpeed_1 != int.MaxValue && day.WindSpeed_2 != int.MaxValue)
                {
                    if (day.WindSpeed_2 != 0)
                        WindNow.Content = $"Ветер:  {day.WindSpeed_1} м/с - {day.WindSpeed_2} м/с, ";
                    else
                        WindNow.Content = $"Ветер:  {day.WindSpeed_1} м/с, ";
                }
                if (day.WindDirection != "" && day.WindDirection != null)
                    WindNow.Content += day.WindDirection.ToString();
                if (day.Humidity != int.MaxValue)
                    HumidityNow.Content = $"Влажность:  {day.Humidity} %";
                if (day.Water != "" && day.Water != null)
                    WaterNow.Content = $"Температура воды:  {day.Water}";
            }
        }
        public void Output_3Days() //вывод погоды "Сегодня, Завтра, Послезавтра"
        {
            List<string[]> data3Days = new List <string[]>();

            WeatherLink weather = new WeatherLink();

            string[] weatherUrls = weather.WeatherUrls;

            DateTime today = DateTime.Now;

            StringBuilder date = new StringBuilder($"{today.Day}.{today.Month}.{today.Year} ");
            StringBuilder temperature = new StringBuilder("Температура ");
            StringBuilder pressure = new StringBuilder("Давление ");
            StringBuilder windSpeed = new StringBuilder("Скорость_ветра ");
            StringBuilder windDirection = new StringBuilder("Направление_ветра ");
            StringBuilder humidity = new StringBuilder("Влажность ");


            for (int i=0; i<3; ++i)
            {
                string url = weatherUrls[i];
                WeatherData[] Data = GetWeatherData(url);

                int hour = 1;
                foreach (WeatherData data in Data)
                {
                    date.Append($"{hour}.00 ");
                    temperature.Append($"{data.Temperature} ");

                    pressure.Append($"{data.Pressure} ");

                    if (data.WindSpeed_2 != 0)
                        windSpeed.Append($"{data.WindSpeed_1}-{data.WindSpeed_2} ");
                    else
                        windSpeed.Append($"{data.WindSpeed_1} ");

                    windDirection.Append($"{data.WindDirection} ");
                    
                    humidity.Append($"{data.Humidity} ");

                    hour += 3;
                }
                if (i != 2)
                {
                    today = today.AddDays(1);
                    date.Append($"{today.Day}.{today.Month}.{today.Year} ");
                }
            }


            data3Days.Add(date.ToString().Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            data3Days.Add(temperature.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            data3Days.Add(pressure.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            data3Days.Add(windSpeed.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            data3Days.Add(windDirection.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            data3Days.Add(humidity.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            var dt = new DataTable();

            int columnCount = data3Days[0].Length;
            for (int i = 0; i < columnCount; ++i)
                dt.Columns.Add();

            StringBuilder str = new StringBuilder();
            for (int i = 0; i < data3Days.Count; ++i)
            {
                if (i > 0)
                {
                    for (int j = 0; j < data3Days[i].Length; ++j)
                    {
                        if ((j-1) % 8 == 0 && (j-1) != 0)

                            str.Append(" _ ");

                        str.Append($"{data3Days[i][j]} ");
                    }

                    dt.Rows.Add(str.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                    str.Clear();
                }
                else
                    dt.Rows.Add(data3Days[i]);
            }

            dataGrid.DataContext = dt.DefaultView;
            
            dataGrid.HeadersVisibility = DataGridHeadersVisibility.None;
            
        }
        public void SaveData()
        {
            DispatcherTimer timer = new DispatcherTimer();
            if (DateTime.Now.Hour == 1)
                SaveWeather();
            timer.Interval = TimeSpan.FromHours(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour == 1)
                SaveWeather();
        }
        public void SaveWeather()
        {

            string pathMain = @"C:/MonitoringWeather";
            if (!Directory.Exists(pathMain))
            {
                Directory.CreateDirectory(pathMain);
            }

            using (FileStream fileTemperature = File.Open("C:/MonitoringWeather/Temperature.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (FileStream filePressure = File.Open("C:/MonitoringWeather/Pressure.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (FileStream fileWindSpeed = File.Open("C:/MonitoringWeather/WindSpeed.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (FileStream fileWindDirection = File.Open("C:/MonitoringWeather/WindDirection.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (FileStream fileHumidity = File.Open("C:/MonitoringWeather/Humidity.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                ;
            }

            WeatherLink weather = new WeatherLink();
            string[] weatherUrls = weather.WeatherUrls;

            DateTime today = DateTime.Now;

            int countForDay = 0;

            foreach (string url in weatherUrls)
            {
                WeatherData[] Data = GetWeatherData(url);

                foreach (WeatherData data in Data)
                {
                    using (StreamWriter fileTemperature = new StreamWriter("C:/MonitoringWeather/Temperature.txt", true))
                    {
                        if (countForDay == 0)
                            fileTemperature.WriteLine();
                        if (countForDay % 8 == 0)
                            fileTemperature.Write($"{today.ToShortDateString()} ");
                        fileTemperature.Write($"{data.Temperature} ");
                    }

                    using (StreamWriter filePressure = new StreamWriter("C:/MonitoringWeather/Pressure.txt", true))
                    {
                        if (countForDay == 0)
                            filePressure.WriteLine();
                        if (countForDay % 8 == 0)
                            filePressure.Write($"{today.ToShortDateString()} ");
                        filePressure.Write($"{data.Pressure} ");
                    }

                    using (StreamWriter fileWindSpeed = new StreamWriter("C:/MonitoringWeather/WindSpeed.txt", true))
                    {
                        if (countForDay == 0)
                            fileWindSpeed.WriteLine();
                        if (countForDay % 8 == 0)
                            fileWindSpeed.Write($"{today.ToShortDateString()} ");
                        if (data.WindSpeed_2 != 0)
                            fileWindSpeed.Write($"{data.WindSpeed_1} - {data.WindSpeed_2} ");
                        else
                            fileWindSpeed.Write($"{data.WindSpeed_1} ");
                    }

                    using (StreamWriter fileWindDirection = new StreamWriter("C:/MonitoringWeather/WindDirection.txt", true))
                    {
                        if (countForDay == 0)
                            fileWindDirection.WriteLine();
                        if (countForDay % 8 == 0)
                            fileWindDirection.Write($"{today.ToShortDateString()} ");
                        fileWindDirection.Write($"{data.WindDirection} ");
                    }

                    using (StreamWriter fileHumidity = new StreamWriter("C:/MonitoringWeather/Humidity.txt", true))
                    {
                        if (countForDay == 0)
                            fileHumidity.WriteLine();
                        if (countForDay % 8 == 0)
                            fileHumidity.Write($"{today.ToShortDateString()} ");
                        fileHumidity.Write($"{data.Humidity} ");
                    }
                    ++countForDay;
                }
                today = today.AddDays(1);
            }
        }
    }
}
