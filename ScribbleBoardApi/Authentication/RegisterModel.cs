using System.ComponentModel.DataAnnotations;  

namespace ScribbleBoardApi.Authentication  
{  
    public class RegisterModel  
    {  
        [Required(ErrorMessage = "User Name is required")]  
        public string UserName { get; set; }  
  
        [EmailAddress]  
        [Required(ErrorMessage = "Email is required")]  
        public string Email { get; set; }  
  
        [Required(ErrorMessage = "Password is required")]  
        public string Password { get; set; }  
    }  
}  