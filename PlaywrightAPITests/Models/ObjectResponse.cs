namespace PlaywrightAPITests.Models;

using System.Text.Json.Serialization;

public class ObjectResponse
{
    public string id { get; set; }

    public string name { get; set; }

    public string createdAt { get; set; }

    public Data data { get; set; }

    public class Data
    {
        public int year { get; set; }

        public double price { get; set; }

        [JsonPropertyName("CPU model")]
        public string CPU_Model { get; set; }

        [JsonPropertyName("Hard disk size")]
        public string Hard_Disk_Size { get; set; }
    }
}