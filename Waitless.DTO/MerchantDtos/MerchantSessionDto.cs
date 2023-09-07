namespace Waitless.DTO.MerchantDtos;

public class MerchantSessionDto
{
    public long MerchantId { get; set; }
    public string Token { get; set; }
    public bool IsExpired { get; set; } 
}