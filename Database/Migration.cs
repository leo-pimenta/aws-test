using aws_test.Domain;
using Microsoft.EntityFrameworkCore;

namespace aws_test.Database
{
    public class Migration : BaseMigration
    {
        private readonly ModelBuilder Model;

        public Migration(ModelBuilder model)
        {
            this.Model = model;
        }

        internal override void Create()
        {
            new CadastroMigration(Model.Entity<Cadastro>()).Create();
        }
    }
}