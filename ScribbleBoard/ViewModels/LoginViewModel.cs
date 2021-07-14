using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ScribbleBoard.Models;
using System;

namespace ScribbleBoard.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public static string Login(LoginViewModel login)
        {
            string jsonObject = JsonConvert.SerializeObject(login);
            var apiCallTask = AuthHelper.Login(jsonObject);
            var result = apiCallTask.Result;
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            string loginResponse = jsonResponse.ToString();
            Console.WriteLine(loginResponse);
            if (loginResponse == "Error")
            {
                return "Error";
            }
            else
            {
                return jsonResponse["token"].ToString();
            }
        }
    }
}