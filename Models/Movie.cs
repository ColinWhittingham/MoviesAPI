using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesAPI.Models
{
    public class Movie
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "yearOfRelease")]
        public int YearOfRelease { get; set; }
        [JsonIgnore]
        public string Genre { get; set; }
        [JsonProperty(PropertyName = "runningTime")]
        public int RunningTimeMins { get; set; }
        [JsonIgnore]
        public ICollection<UserRating> Ratings { get; set; }

        [JsonIgnore]
        public double? AverageRating { get => Ratings?.Average(o => o.Score); }
        [JsonProperty(PropertyName = "averageRating")]
        public double? AverageDisplayRating { get => AverageRating.HasValue ? Math.Round((AverageRating.Value * 2), MidpointRounding.AwayFromZero) / 2 : (double?)null; }
    }
}