using System.ComponentModel.DataAnnotations;
using ScribbleBoard.Models;
using Newtonsoft.Json; 
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;

namespace ScribbleBoard.ViewModels
{
  public class RegisterViewModel
  {
    [Required]
    public string UserName { get; set; }
    
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
    public static string Register(RegisterViewModel register)
    {
      string jsonObject = JsonConvert.SerializeObject(register);
      var apiCallTask = AuthHelper.Register(jsonObject);
      var result = apiCallTask.Result;
      Console.WriteLine(result);
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      string status = jsonResponse["status"].ToString();
      return status;
    }
  }
}


      