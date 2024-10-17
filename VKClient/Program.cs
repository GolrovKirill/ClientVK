using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    private static readonly HttpClient client = new ();

    static async Task Main(string[] args)
    {
        string accessToken = "6f9ab4036f9ab4036f9ab403796cbbab8366f9a6f9ab403088b966bedb2d7693868fb1b";
        string method = "users.get";

        string url = $"https://api.vk.com/method/{method}?user_ids=1&access_token={accessToken}";

        try
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}