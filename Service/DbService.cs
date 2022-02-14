using aws_test.Database;

namespace aws_test.Service
{
    public abstract class DbService
    {
        protected readonly CadastroContext DbContext;

        public DbService(CadastroContext context)
        {
            DbContext = context;
        }

        protected async Task CommitDb()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}