using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesAPI.Models
{
    public class UserRating
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; }
        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "movieId")]
        public int MovieId { get; set; }
        [JsonProperty(PropertyName = "score")]
        public double Score { get; set; }
    }
}