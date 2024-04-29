using Squirrel.Infrastructure.Databases.SquirrelDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Squirrel.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : SquirrelController
    {
        private readonly SquirrelDbContext _squirrelDbContext;
        private readonly IConfiguration _configuration;

        public HealthCheckController(
            SquirrelDbContext context,
            IConfiguration configuration) : base()
        {
            _squirrelDbContext = context;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var healthCheck = new StringBuilder();
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Squirrel system time.
            healthCheck.AppendLine($"SQUIRREL SYSTEM TIME: {DateTime.UtcNow}")
                .AppendLine(AUnderscoresLine())
                .AppendLine()
                .AppendLine($"SQUIRREL ENVIRONMENT CONFIGURED: {environment}")
                .AppendLine(AUnderscoresLine());

            // Commit version information
            healthCheck.AppendLine()
                .AppendLine("GIT COMMIT INFORMATION:")
                .AppendLine()
                //.AppendLine($"Last Commit: {ThisAssembly.Git.Commit}")
                //.AppendLine($"SHA: {ThisAssembly.Git.Sha}")
                //.AppendLine($"Commit Time: {DateTime.Parse(ThisAssembly.Git.CommitDate):yyyy年MM月dd日 HH:mm:ss UTC}")
                //.AppendLine($"Branch: {ThisAssembly.Git.Branch}")
                //.AppendLine($"Commit quantity: {ThisAssembly.Git.Commits} (commits)")
                .AppendLine(AUnderscoresLine());

            // Verify Database connection
            healthCheck.AppendLine().AppendLine("SQUIRREL'S DATABASES:")
                .AppendLine("----");
#if DEBUG
            healthCheck.AppendLine("Squirrel Connection string: \n\t" + _configuration.GetConnectionString("SquirrelDB"));
#endif

            using (var connection = _squirrelDbContext.Database.GetDbConnection())
            {
                var resourceName = $"Server: {connection.DataSource}\r\nDatabase: {connection.Database}\r\nVerify Status";
                var result = await VerifyResourceAsync(resourceName,
                    async () => await _squirrelDbContext.Database.OpenConnectionAsync());

                healthCheck.AppendLine(result);
            }

            healthCheck.AppendLine(AUnderscoresLine());

            return new OkObjectResult(healthCheck.ToString());
        }

        private static async Task<string> VerifyResourceAsync(string resourceName, Func<Task> task)
        {
            try
            {
                await task();
                return $"{resourceName} => OK";
            }
            catch (Exception ex)
            {
                return $"{resourceName} => Failed: {ex}";
            }
        }

        private static string AUnderscoresLine() => "_______________________________________________________________________________________________________________";
    }
}

