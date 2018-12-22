using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BIG.Mobile.Views
{
    public class Stock
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "stock")]
        public int Qty { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("lastupdate")]
        public DateTime Lastupdate { get; set; }
        //public UnixDateTimeConverter Lastupdate { get; set; }
    }
}
