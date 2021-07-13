namespace ScribbleBoardApi.Models
{
  public class PaginationFilter
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string UserName {get;set;}
    public PaginationFilter()
    {
        this.PageNumber = 1;
        this.PageSize = 24;
    }
    public PaginationFilter(int pageNumber, int pageSize, string userName)
    {
        this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
        this.PageSize = pageSize > 24 ? 24 : pageSize;
        this.UserName = userName;
    }
}
}