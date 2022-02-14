using aws_test.Domain;

namespace aws_test.Service
{
    public interface ICadastro
    {
        Task Save(Cadastro cadastro);
        Task<Cadastro> Get(Guid id);
        Task<IEnumerable<Cadastro>> GetAll();
    }
}