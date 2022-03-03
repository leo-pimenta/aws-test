using System.ComponentModel.DataAnnotations;

namespace aws_test.Dto
{
    public class CadastroDto
    {
        [Required(ErrorMessage = "\"Nome\" é um campo obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "\"Idade\" é um campo obrigatório.")]
        [Range(18, 120, ErrorMessage = "\"Idade\" deve ser maior que 18 e menor que 120 anos.")]
        public int Idade { get; set; }

        public CadastroDto(string nome, int idade)
        {
            this.Nome = nome;
            this.Idade = idade;
        }
    }
}