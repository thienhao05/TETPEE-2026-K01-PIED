namespace TetPee.Service.Seller;

public class SellerRequest
{
    public class CreateSellerRequest
    {
        public required string TaxCode { get; set; }
        public required string CompanyName { get; set; }
        public required string CompanyAddress { get; set; }
    }
    
    public class UpdateSellerRequest : CreateSellerRequest
    {
        public Guid Id { get; set; }
    }
}