using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BIG.Mobile.Views
{
   public  class Product_Catalog
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        [JsonProperty(PropertyName = "brand")]
        public string Brand { get; set; }

        [JsonProperty(PropertyName = "rim")]
        public string Rim { get; set; }

        [JsonProperty(PropertyName = "line")]
        public string Line { get; set; }

        [JsonProperty(PropertyName = "status")]
        public byte Status { get; set; }

        [JsonProperty(PropertyName = "isVisible")]
        public bool Visible { get; set; }

        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("lastupdate")]
        public DateTime Lastupdate { get; set; }
        //public UnixDateTimeConverter Lastupdate { get; set; }

    }
}
