using Waitless.BLL.Services.MerchantService;

namespace Waitless.Api.Controllers;

public class MerchantController : ApiControllerBase
{
    private readonly IMerchantSessionService _merchantSessionService;

    public MerchantController(IMerchantSessionService merchantSessionService)
    {
        _merchantSessionService = merchantSessionService;
    }
}