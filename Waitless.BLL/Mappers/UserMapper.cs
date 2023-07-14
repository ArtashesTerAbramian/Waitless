using Waitless.DAL.Models;
using Waitless.DTO.UsersDtos;
using Riok.Mapperly.Abstractions;

namespace Waitless.BLL.Mappers;

[Mapper]
public static partial class UserMapper
{
    public static partial UserDto MapToUserDto(this User user);
    public static partial List<UserDto> MapToUsersDtos(this List<User> user);
}