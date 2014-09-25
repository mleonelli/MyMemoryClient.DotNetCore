using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMemoryAPI
{

    public class MyMemorySetResponse
    {
        public string responseData { get; set; }
        public string responseDetails { get; set; }
        public int responseStatus { get; set; }
        public string responderId { get; set; }
        public List<Match> matches { get; set; }
    }

    public class MyMemoryGetResponse
    {
        public ResponseData responseData { get; set; }
        public string responseDetails { get; set; }
        public int responseStatus { get; set; }
        public string responderId { get; set; }
        public List<Match> matches { get; set; }
    }

    public class ResponseData
    {
        public string translatedText { get; set; }
    }

    public class Match
    {
        public string id { get; set; }
        public string segment { get; set; }
        public string translation { get; set; }
        public string quality { get; set; }
        public string reference { get; set; }
        [JsonProperty(PropertyName = "usage-count")]
        public int usageCount { get; set; }
        public string subject { get; set; }
        [JsonProperty(PropertyName = "created-by")]
        public string createdBy { get; set; }
        [JsonProperty(PropertyName = "last-updated-by")]
        public string lastUpdatedBy { get; set; }
        [JsonProperty(PropertyName = "create-date")]
        public DateTime createDate { get; set; }
        [JsonProperty(PropertyName = "last-update-date")]
        public DateTime lastUpdateDate { get; set; }
        public double match { get; set; }
    }

}
