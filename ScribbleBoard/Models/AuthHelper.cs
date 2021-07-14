using RestSharp;
using System.Threading.Tasks;

namespace ScribbleBoard.Models
{
  public class AuthHelper
  {
    public static async Task<string> Register(string register)
    {
      RestClient client = new RestClient("http://localhost:2000/api/");
      RestRequest request = new RestRequest("authenticate/register", Method.POST);
      request.AddJsonBody(register);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task<string> Login(string login)
    {
      RestClient client = new RestClient("http://localhost:2000/api/");
      RestRequest request = new RestRequest("authenticate/login", Method.POST);
      request.AddJsonBody(login);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
      if (response.StatusCode == System.Net.HttpStatusCode.OK)
      {
        return response.Content;
      }
      else
      {
        return "Error";
      }
    }
  }
}
