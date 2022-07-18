using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPIClient;
using Api.TelegramData;
using Newtonsoft.Json;
using System.Text;


public class ApiTelegram
{

    private static readonly HttpClient client = new HttpClient();
    private static string? _token;
    private static string? _api;


    public ApiTelegram(string token_api)
    {
        _token = token_api;
        _api = $"https://api.telegram.org/bot{_token}";
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

    }


    public async Task<GetMeData> GetMe()
    {
        var requestData = new Dictionary<string, object>();
        HttpResponseMessage streamTask = await this.SendApi("getMe", requestData);
        var json = await streamTask.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<Repository>(json);
         
        return data.Result;
    }
    
    public async Task<HttpResponseMessage> SendApi(string methdo, object requestData)
    {
        
        var jsonContent = JsonConvert.SerializeObject(requestData);
        var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json"); 
        HttpResponseMessage streamTask = await client.PostAsync(
                $"{_api}/{methdo}", contentString
        );
        
        return streamTask;
    }


    public async Task<Repository> SendMessage(long chat_id, string text, string parse_mode = "markdown")
    {
        
        var requestData = new Dictionary<string, object>();
        requestData["chat_id"] = chat_id;
        requestData["text"] = text;
        requestData["parse_mode"] = parse_mode;

        HttpResponseMessage streamTask = await this.SendApi("sendMessage", requestData);
        var json = await streamTask.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<Repository>(json);
        return data;
    }

    
    public async Task<List<Update>> GetUpdates(long offset=0, int limit=100, int timeout=0, List<String> allowed_updates=null)
    {
        var requestData = new Dictionary<string, object>();
        requestData["offset"] = offset;
        requestData["limit"] = limit;
        requestData["timeout"] = timeout;
        requestData["allowed_updates"] = allowed_updates;
        var streamTask = await this.SendApi("getUpdates", requestData);
        var json = await streamTask.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<UpdateData>(json);
        return data.Result;
    }
}

namespace Api.TelegramBot
{

	public class Bot:ApiTelegram
	{
		public Bot(string token_api):base(token_api) { }

        public async Task Run()
        {
            Console.WriteLine("ApiTelegram working ...");
            long offset = 0; 
            
            while (true)
            {
                var updates =  await this.GetUpdates(offset+1);
                var me = await this.GetMe();                
                
                foreach (var up in updates) 
                {
                    Console.WriteLine(up.message.text);
                    offset = up.update_id;
                    if (up.message.text.Equals("/start"))
                    {
                       await this.SendMessage(up.message.from.id, $"Olá {up.message.from.first_name}, como vai? meu id {me.username}");
                    }
                }
            }
        }		
	}
}