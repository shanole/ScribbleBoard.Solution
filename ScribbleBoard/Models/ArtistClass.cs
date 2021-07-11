using System.Collections.Generic;

namespace ScribbleBoard.Models 
{
    public class Artist
    {
      public Artist()
      {
        this.Images = new HashSet<Image>();
      }
      public int ArtistId { get; set; }
      public string ArtistName { get; set; }
      public string Description { get; set; } 
      public virtual ApplicationUser User { get; set; }
      public virtual ICollection<Image> Images { get; set; }
    }
}