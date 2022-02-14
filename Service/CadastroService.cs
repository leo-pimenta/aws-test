using aws_test.Database;
using aws_test.Domain;
using Microsoft.EntityFrameworkCore;

namespace aws_test.Service
{
    public class CadastroService : DbService, ICadastro
    {
        public CadastroService(CadastroContext context) : base(context) {}

        public async Task Save(Cadastro cadastro)
        {
            cadastro.Id = Guid.NewGuid();
            await DbContext.Cadastros.AddAsync(cadastro);
            await CommitDb();
        }

        public async Task<Cadastro> Get(Guid id)
        {
            Cadastro? cadastro = await DbContext.Cadastros.FindAsync(id);

            if (cadastro == null)
            {
                throw new CadastroNotFoundException("No cadastro with the given id.");
            }

            return cadastro;
        }

        public async Task<IEnumerable<Cadastro>> GetAll()
        {
            return await DbContext.Cadastros.ToListAsync();
        }
    }
}