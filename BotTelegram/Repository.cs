using System;
using System.Globalization;
using System.Text.Json.Serialization;
using Api.TelegramData;

namespace WebAPIClient
{
    public class Repository
    {
        
        [JsonPropertyName("result")]
        public GetMeData Result { get; set; }
        
        [JsonPropertyName("ok")]
        public bool Ok { get; set; }

        [JsonPropertyName("html_url")]
        public Uri Url { get; set; }

    }
}