namespace aws_test.Domain
{
    public class Cadastro
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public Cadastro(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }
    }
}