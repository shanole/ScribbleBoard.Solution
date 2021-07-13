using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ScribbleBoard.Models
{
  public class Image
  {
    public int ImageId { get; set; }
    public string Data { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    // public virtual ApplicationUser User { get; set; }
    public string UserId {get; set;}
    public string UserName {get; set;}
    // this will have parameters for pageSize, pageNumber
    public static List<Image> GetAll(int pageNumber, int pageSize)
    {
      // this will also have parameters for pageSize, pageNumber
      var apiCallTask = ApiHelper.GetAllImages(pageNumber, pageSize);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Image> imagesList = JsonConvert.DeserializeObject<List<Image>>(jsonResponse.ToString());
      return imagesList;
    }
    public static Image GetDetails(int id)
    {
      var apiCallTask = ApiHelper.GetImage(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Image thisImage = JsonConvert.DeserializeObject<Image>(jsonResponse.ToString());
      return thisImage;
    }
    public static void Post(Image image)
    {
      string jsonImage = JsonConvert.SerializeObject(image);
      var apiCallTask = ApiHelper.PostImage(jsonImage);
    }
    public static void Put(Image image)
    {
      string jsonImage = JsonConvert.SerializeObject(image);
      var apiCallTask = ApiHelper.PutImage(image.ImageId, jsonImage);
    }
    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.DeleteImage(id);
    }
    public static List<Image> GetImagesByUser(string userName)
    {
      var apiCallTask = ApiHelper.GetImagesByUser(userName);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Image> imagesList = JsonConvert.DeserializeObject<List<Image>>(jsonResponse.ToString());
      return imagesList;
    } 
  }
}