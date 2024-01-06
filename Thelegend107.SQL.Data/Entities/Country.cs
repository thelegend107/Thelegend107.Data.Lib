using MapDataReader;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResumeAPI.Entities
{
    [GenerateDataReaderMapper]
    [Table("[dbo].[Country]")]
    public partial class Country
    {
        public int Id { get; set; }
        public int? RegionId { get; set; }
        public int? SubRegionId { get; set; }
        public string Name { get; set; } = null!;
        public string? NativeName { get; set; }
        [JsonProperty("ISO3")]
        public string ISO3 { get; set; } = null!;
        [JsonProperty("ISO2")]
        public string ISO2 { get; set; } = null!;
        public int NumericCode { get; set; }
        public string PhoneCode { get; set; } = null!;
        public string? Capital { get; set; }
        public string Currency { get; set; } = null!;
        public string CurrencyName { get; set; } = null!;
        public string CurrencySymbol { get; set; } = null!;
        public string Tld { get; set; } = null!;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? Emoji { get; set; }
    }
}