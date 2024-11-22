namespace Tenants.Domain.Common;

public class PaginationParameters
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public PaginationParameters(int pageNumber = 1, int pageSize = 10)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}