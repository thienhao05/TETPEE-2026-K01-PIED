using Microsoft.EntityFrameworkCore;
using TetPee.Repository;
using TetPee.Service.Base;

namespace TetPee.Service.Seller;

public class SellerService : ISellerService
{
    private readonly AppDbContext _dbContext;
    
    public SellerService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Response.PageResult<SellerResponse.GetSellersResponse>> GetSellers(
        string? searchTerm,
        int pageSize,
        int pageIndex)
    {
        var query = _dbContext.Users
            .Where(x => x.Role == "Seller"); //sửa lại ngay chỗ này nè

        if (searchTerm != null)
        {
            query = query.Where(x => x.Email.Contains(searchTerm));
        }

        query = query
            .OrderBy(x => x.FirstName);

        query = query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);

        var selectedQuery = query
            .Select(x => new SellerResponse.GetSellersResponse()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                ImageUrl = x.ImageUrl,
                TaxCode = x.Seller.TaxCode,
                CompanyName = x.Seller.CompanyName
            });

        var listResult = await selectedQuery.ToListAsync();
        var totalItems = listResult.Count();

        var result = new Base.Response.PageResult<SellerResponse.GetSellersResponse>()
        {
            Items = listResult,
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalItems = totalItems,
        };
        return result;
    }

    public async Task<SellerResponse.GetSellersDetailsResponse?> GetSellerById(Guid sellerId)
    {
        var query = _dbContext.Sellers
            .Where(x => x.Id == sellerId);

        var selectedQuery = query
            .Select(x => new SellerResponse.GetSellersDetailsResponse()
            {
                PhoneNumber = x.User.PhoneNumber,
                DateOfBirth = x.User.DateOfBirth,
                CompanyAddress = x.CompanyAddress,
                Address = x.User.Address,
            });

        var result = await selectedQuery.FirstOrDefaultAsync();
        return result;

    }
}