using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserRecords.Models
{
    public class UserModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
    }
}
