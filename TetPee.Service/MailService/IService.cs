namespace TetPee.Service.MailService;

public interface IService
{
    public Task SendMail(MailContent mailContext);
}

public class MailContent
{
    public required string To { get; set; } //Địa chỉ gừi đến
    public required string Subject { get; set; } // Chủ đề (tiêu đề mail)
    public required string Body { get; set; } // Nội dung (hỗ trợ HTML ) cảu email
}