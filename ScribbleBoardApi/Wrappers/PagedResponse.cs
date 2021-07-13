using System;

namespace ScribbleBoardApi.Wrappers
{
  public class PagedResponse<T> : Response<T>
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
    public PagedResponse(T data, int count, int pageNumber, int pageSize)
    {
        this.CurrentPage = pageNumber;
        this.PageSize = pageSize;
        this.TotalRecords = count;
        this.Data = data;
        this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        this.Message = null;
        this.Succeeded = true;
        this.Errors = null;
    }
  }
}