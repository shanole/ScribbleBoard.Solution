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
    public string UserId {get; set;}
    public string UserName {get; set;}
    public static List<Image> GetAll(int pageNumber, int pageSize, string userName)
    {
      var apiCallTask = ApiHelper.GetAllImages(pageNumber, pageSize, userName);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Image> imagesList = JsonConvert.DeserializeObject<List<Image>>(jsonResponse["data"].ToString());
      int count = JsonConvert.DeserializeObject<int>(jsonResponse["totalRecords"].ToString());
      PagedList<Image> pagedImagesList = new PagedList<Image>(imagesList, count, pageNumber, pageSize);
      return pagedImagesList;
    }
    public static Image GetDetails(int id)
    {
      var apiCallTask = ApiHelper.GetImage(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Image thisImage = JsonConvert.DeserializeObject<Image>(jsonResponse["data"].ToString());
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
  }
}