using System.Threading.Tasks;
using RestSharp;

namespace ScribbleBoard.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAllImages()
    {
      RestClient client = new RestClient("http://localhost:2000/api/");
      RestRequest request = new RestRequest("scribbleboard", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task<string> GetImage(int id)
    {
      RestClient client = new RestClient("http://localhost:2000/api/");
      RestRequest request = new RestRequest($"scribbleboard/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task PostImage(string newImage)
    {
      RestClient client = new RestClient("http://localhost:2000/api/");
      RestRequest request = new RestRequest("scribbleboard", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newImage);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task PutImage(int id, string newImage)
    { 
      RestClient client = new RestClient("http://localhost:2000/api/");
      RestRequest request = new RestRequest($"scribbleboard/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newImage);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task DeleteImage(int id)
    {
      RestClient client = new RestClient("http://localhost:2000/api/");
      RestRequest request = new RestRequest($"scribbleboard/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}