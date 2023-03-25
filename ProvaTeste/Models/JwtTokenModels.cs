using Newtonsoft.Json;

namespace ProvaTeste.Models
{
    public class JwtTokenModels
    {
        [JsonProperty("sub")]
        public string Sub { get; set; }

        [JsonProperty("iss")]
        public string Iss { get; set; }

        [JsonProperty("pro")]
        public Pro Pro { get; set; }

        [JsonProperty("iat")]
        public int Iat { get; set; }

        [JsonProperty("exp")]
        public int Exp { get; set; }
    }

    public class Pro
    {
        [JsonProperty("User")]
        public string UserName { get; set; }
        [JsonProperty("Empresa")]
        public string Company { get; set; }

    }
}
