using Waitless.DAL.Models;
using Waitless.DTO.UsersDtos;
using Riok.Mapperly.Abstractions;

namespace Waitless.BLL.Mappers;

[Mapper]
public static partial class UserSessionMapper
{
    public static partial UserSessionDto MapToUserSessionDto(this UserSession user);
}