using Waitless.DAL;

namespace Waitless.BLL.Services.ContextModificatorService;
public class WebContextModificatorService : IContextModificatorService
{
    public bool IsGlobalQueryFiltersEnable => true;
}