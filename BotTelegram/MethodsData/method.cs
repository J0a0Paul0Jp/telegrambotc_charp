using System.Text.Json.Serialization;

namespace Api.TelegramData
{
	

    public class GetMeData
    {
        
        [JsonPropertyName("id")]
        public long  id { get; set; }

        [JsonPropertyName("is_bot")]
        public bool is_bot { get; set; }

        [JsonPropertyName("first_name")]
        public string first_name { get; set; }

        [JsonPropertyName("username")]
        public string username { get; set; }

        [JsonPropertyName("can_join_groups")]
        public bool can_join_group { get; set; }

        [JsonPropertyName("can_read_all_group_messages")]
        public bool can_read_all_group_message { get; set; }

        [JsonPropertyName("supports_inline_queries")]
        public bool supports_inline_queries { get; set; }
    }

    public class UpdateData
    {

        [JsonPropertyName("ok")]
        public bool Ok { get; set;}

        [JsonPropertyName("result")]
        public  List<Update>  Result { get; set; }

    }

    public class Update{
        [JsonPropertyName("update_id")]
        public long update_id { get; set; }

        [JsonPropertyName("message")]
        public UpdateMessage message{ get; set; }
    }

    public class UpdateMessage
    {
        [JsonPropertyName("from")]
        public User from { get; set; }

        [JsonPropertyName("text")]
        public string text { get; set; }

        [JsonPropertyName("chat_id")]
        public long chat_id { get; set; }

    }

    public class User
    {
        [JsonPropertyName("id")]
        public long id { get; set; }

        [JsonPropertyName("first_name")]
        public string first_name { get; set; }

        [JsonPropertyName("username")]
        public string username { get; set; }
    }
}