using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.DTO.UsersDtos;

namespace Waitless.BLL.Services.UserService;

public interface IUserService
{
    Task<Result> AddUserAsync(AddUserDto dto);
    Task<Result> Delete(long id);
    Task<PagedResult<List<UserDto>>> GetAllAsync(UserFilter filter);
    Task<Result<UserDto>> GetByTokenAsync(string token);
    Task<Result<UserDto>> GetUserByUsernameAsync(string username);
    Task<Result> UpdateAsync(UpdateUserDto dto);
    Task<Result<bool>> VerifyUserAsync(string token);
}