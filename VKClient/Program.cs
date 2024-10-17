using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    private static readonly HttpClient client = new();

    static async Task Main(string[] args)
    {
        string accessToken = "6f9ab4036f9ab4036f9ab403796cbbab8366f9a6f9ab403088b966bedb2d7693868fb1b";
        string method = "users.get";
        string userId = "";
        userId = Console.ReadLine();

        string url = $"https://api.vk.com/method/{method}?user_ids={userId}&access_token={accessToken}&v=5.131";

        var jresponse = await client.GetAsync(url);
        jresponse.EnsureSuccessStatusCode();

        var content = await jresponse.Content.ReadAsStringAsync();

        var response = JsonSerializer.Deserialize<Response>(content);

        Console.WriteLine($"{response.response[0].last_name}");
    }

    public class Response
    {
        public IList<Content> response { get; set; }
    }


    public class Content
    {
        public int id { get; set; }
        public int bdate { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
}