using Microsoft.EntityFrameworkCore;
using ef_crud_api.Data;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<DbContext>(options =>
        options.UseSqlServer(""));

        services.AddControllers();
    }
}