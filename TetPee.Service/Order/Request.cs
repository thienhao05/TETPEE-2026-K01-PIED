namespace TetPee.Service.Order;

public class Request
{
    public class CreateOrderRequest
    {
        public string Address { get; set; }
        public List<ProductOrderRequest> Products { get; set; }
    }
    
    // Tạo đơn hàng ( Giả sử hệ thống mình, muốn đặt hàng thì phải chuyển khoản trước nhé)
    // Setup chuyển khoản thành công (bằng tiền thiệt), để xác nhận đơn hàng đã được đặt
    // Nếu tạo ra đơn hàng, mà không chuyển khoản liền, thì đơn hàng sẽ bị hủy sau 15 phút,
    // để tránh tình trạng khách hàng đặt hàng rồi không chuyển khoản, làm ảnh hưởng đến việc quản lý đơn hàng
    
    
    // Hủy đơn hàng
    // Cập nhật đơn hàng

    public class ProductOrderRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
    
    public class SepayWebhookRequest
    {
        public string Gateway { get; set; }
        public string TransactionDate { get; set; }
        public string AccountNumber { get; set; }
        public string SubAccount { get; set; }
        public string Code { get; set; }
        public string Content { get; set; }
        public string TransferType { get; set; }
        public string Description { get; set; }
        public decimal TransferAmount { get; set; }
        public string ReferenceCode { get; set; }
        public decimal Accumulated { get; set; }
        public long Id { get; set; }
    }
    
    /* Body mà thằng SePay sẽ gọi cho mình
        {
          "gateway": "BIDV",
          "transactionDate": "2026-04-06 23:41:15",
          "accountNumber": "8886369921",
          "subAccount": "96247BENTRAN",
          "code": "TCMPBf9c3895c14b94583bad78673263",
          "content": "QR - TCMPBf9c3895c14b94583bad786732631b1ca",
          "transferType": "in",
          "description": "BankAPINotify QR - SMPBf9c3895c14b94583bad786732631b1ca",
          "transferAmount": 2500,
          "referenceCode": "bc8af415-13e4-4bf9-8352-a8af59df5808",
          "accumulated": 0,
          "id": 48628369
        }
     */
}