using Newtonsoft.Json;

namespace vk_callback_server.Controllers
{
    public class Message
    {
        public string Type { get; set; }

        [JsonProperty(propertyName: "group_id")]
        public int GroupId { get; set; }
    }
}