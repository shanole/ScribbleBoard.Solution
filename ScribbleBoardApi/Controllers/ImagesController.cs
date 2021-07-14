using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScribbleBoardApi.Models; 
using ScribbleBoardApi.Wrappers;
using Microsoft.AspNetCore.Authorization;

namespace ScribbleBoardApi.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class ImagesController : ControllerBase
  {
    private readonly ScribbleBoardApiContext _db;
    public ImagesController(ScribbleBoardApiContext db)
    {
      _db = db;
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PaginationFilter filter)
    {
      var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, filter.UserName);
      var query = _db.Images.AsQueryable();
      if (validFilter.UserName != null)
      {
        query = query.Where(e => e.UserName == validFilter.UserName);
      }
      //// USING PAGEDRESPONSE WRAPPER
      var totalRecords = query.Count();
      var images = await query.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToListAsync();
      return Ok(new PagedResponse<List<Image>>(images, totalRecords, validFilter.PageNumber, validFilter.PageSize));
    }
    [HttpPost]
    public async Task<ActionResult<Image>> Post(Image image)
    {
      _db.Images.Add(image);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetImage), new {id = image.ImageId}, image);
    }
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetImage(int id)
    {
      Image img = await _db.Images.FindAsync(id);
      if (img == null)
      {
        return NotFound();
      }
      // maybe also put this in a wrapper?
      return Ok(new Response<Image>(img));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Image image)
    {
      if (id != image.ImageId)
      {
        return BadRequest();
      }
      _db.Entry(image).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ImageExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteImage(int id)
    {
      var img = await _db.Images.FindAsync(id);
      if (img == null)
      {
        return NotFound();
      }
      _db.Images.Remove(img);
      await _db.SaveChangesAsync();
      return NoContent();
    }
    // uploading directly to API 
    [HttpPost]
    [Route("[action]")]
    public async Task<ActionResult<Image>> UploadDirect(IFormFile image)
    {
      using (var stream = new MemoryStream())
      {
        image.CopyTo(stream);
        var img = new Image()
        {
          Data = "data:image/jpeg;base64," + Convert.ToBase64String(stream.ToArray()),
          UserId = "directUploadID",
          UserName = "directUpload",
          Title = image.FileName,
          Description = $"Description for {image.FileName}",
          CreatedAt = DateTime.Now
        };
        _db.Images.Add(img);
        await _db.SaveChangesAsync();
        return CreatedAtAction("UploadDirect", new { id = img.ImageId}, img);
      }
    }
   private bool ImageExists(int id)
    {
      return _db.Images.Any(e => e.ImageId == id);
    }

  }
}