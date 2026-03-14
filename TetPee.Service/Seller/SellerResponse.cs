namespace TetPee.Service.Seller;

public class SellerResponse
{
    public class GetSellersResponse
    {
        public string Email { get; set; } = null;
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public string? ImageUrl { get; set; } = null;
        public string TaxCode { get; set; } = null;
        public string CompanyName { get; set; } = null; 
    }
    
    public class GetSellersDetailsResponse : GetSellersResponse
    {
        public string PhoneNumber { get; set; } = null;
        public string DateOfBirth { get; set; } = null;
        public string CompanyAddress { get; set; } = null;
        public string Address{ get; set; } = null;
    }
    
}