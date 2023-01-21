using Newtonsoft.Json;

namespace FuckML.WebAPI.Settings
{
    public class DopplerValueReturn
    {
        [JsonProperty("name")]
        public string SecretName { get; set; } = "";

        [JsonProperty("value")]
        public DopplerValue Value { get; set; } = new();

        [JsonProperty("success")]
        public bool IsSuccess { get; set; }

        public class DopplerValue
        {
            [JsonProperty("raw")]
            public string Raw { get; set; } = "";

            [JsonProperty("computed")]
            public string Computed { get; set; } = "";
        }
    }
}
