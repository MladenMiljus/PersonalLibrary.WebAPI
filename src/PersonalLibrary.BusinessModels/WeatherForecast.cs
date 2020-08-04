using System;

namespace PersonalLibrary.BusinessModels
{
    /// <summary>
    /// Weather Forecast business model POCO
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Temperature in celsius
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Temperature in farenheight
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// Summary of weather
        /// </summary>
        public string Summary { get; set; }
    }
}
