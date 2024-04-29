namespace Squirrel.Infrastructure.Databases.CommandInterceptor
{
    public class SquirrelDbContextCommandInterceptor : AbstractCommandInterceptor
    {
        public SquirrelDbContextCommandInterceptor(string filePath) : base(filePath)
        {
        }
    }
}
