namespace Waitless.DTO.UsersDtos;

public class UserSessionDto
{
    public long UserId { get; set; }
    public string Token { get; set; }
    public bool IsExpired { get; set; } 
}