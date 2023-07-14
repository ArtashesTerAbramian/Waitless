using Microsoft.EntityFrameworkCore;

namespace Waitless.DAL;

public class AppDbContextFactory : DesignTimeDbContextFactory<AppDbContext>
{
    private readonly IContextModificatorService _contextModificatorService;
    private readonly ILanguageService _languageService;

    public AppDbContextFactory()
    {

    }

    public AppDbContextFactory(IContextModificatorService contextModificatorService, ILanguageService languageService)
    {
        _contextModificatorService = contextModificatorService;
        _languageService = languageService;
    }

    protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
    {
        return new AppDbContext(options, _contextModificatorService, _languageService);
    }
}
