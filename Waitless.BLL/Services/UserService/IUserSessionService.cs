using Ardalis.Result;
using Waitless.DAL.Models;
using Waitless.DTO;
using Waitless.DTO.UsersDtos;

namespace Waitless.BLL.Services.UserService;

public interface IUserSessionService
{
    Task<Result<UserSessionDto>> Add(LoginDto dto);
    Task<Result<bool>> Delete();
    Task<User> GetByToken(string token);
    Result<UserDto> GetUserCurrentInfo();
}