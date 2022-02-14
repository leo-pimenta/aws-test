namespace aws_test.Dto
{
    public class CadastroDto
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public CadastroDto(string nome, int idade)
        {
            this.Nome = nome;
            this.Idade = idade;
        }
    }
}