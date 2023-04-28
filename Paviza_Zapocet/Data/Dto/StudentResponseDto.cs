using System.Text.Json.Serialization;

namespace Paviza_Zapocet.Data.Model
{
    public class ClientDataResponseDto
    {

        public int SuccessCount { get; set; } = 0;

        public int FailedCount { get; set; } = 0;

        public List<string> SuccessListPoid { get; set; } = new List<string>();

        public List<string> FailedListPoid { get; set; } = new List<string>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }

    }
}
