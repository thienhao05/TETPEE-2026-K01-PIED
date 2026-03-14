namespace TetPee.Service.Seller;

public interface ISellerService
{
    public Task<Base.Response.PageResult<SellerResponse.GetSellersResponse>> GetSellers(
        string? searchTerm,
        int pageSize,
        int pageIndex);
    
    public Task<SellerResponse.GetSellersDetailsResponse?> GetSellerById(Guid sellerId);
}