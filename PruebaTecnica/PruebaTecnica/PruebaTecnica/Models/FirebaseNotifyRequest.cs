using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PruebaTecnica.Models
{
    public class FirebaseNotifyRequest
    {
        [JsonProperty("notification")]
        public Notification Notification { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }
    }

    public class Data
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Notification
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
