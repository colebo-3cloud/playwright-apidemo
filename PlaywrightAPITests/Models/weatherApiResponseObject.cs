namespace PlaywrightAPITests.Models;


public class WeatherApiResponseObject
{
    public double longitude { get; set; }
    public double elevation { get; set; }
    public double generationtime_ms { get; set; }
    public int utc_offset_seconds { get; set; }
    public string? timezone { get; set; }
    public string? timezone_abbreviation { get; set; }
    public Daily? daily { get; set; }
    public DailyUnits? daily_units { get; set; }

     public class Daily
    {
        public List<string>? time { get; set; }
        public List<double>? temperature_2m_max { get; set; }
    }

    public class DailyUnits
    {
        public string? temperature_2m_max { get; set; }
    }

    public double GetTempForDate(DateTime date)
   {
        int index = this.daily?.time?.IndexOf(date.ToString("yyyy-MM-dd")) ?? -1;
        double temp = this.daily?.temperature_2m_max?[index] ?? -1;
        return temp;
   }
}
