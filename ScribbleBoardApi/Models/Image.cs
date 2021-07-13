using System; 

namespace ScribbleBoardApi.Models
{
  public class Image
  {
    public int ImageId {get; set;}
    // this needs to be converted between base64 string with Convert.FromBase64String() or Convert.ToBase64String();
    public string Data {get; set;}
    public string Title {get; set;}
    public string Description {get; set;}
    public DateTime CreatedAt {get; set;}
    public string UserId {get; set;}
    public string UserName {get; set;}
  }    
}