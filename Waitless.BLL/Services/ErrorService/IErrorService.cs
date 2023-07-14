using Waitless.DTO;

namespace Waitless.BLL.Services.ErrorService;
public interface IErrorService
{
    Task<ErrorModelDto> GetById(long id);
}