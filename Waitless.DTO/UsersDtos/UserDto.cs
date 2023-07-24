using Waitless.Dto;

namespace Waitless.DTO.UsersDtos;

public class UserDto : BaseDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}