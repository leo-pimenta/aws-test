using System.ComponentModel.DataAnnotations;

namespace aws_test.Dto
{
    public class CadastroDto
    {
        [Required(ErrorMessage = "Field \"Name\" is required.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Field \"Age\" is required.")]
        [Range(18, 120, ErrorMessage = "Field \"Age\" must be greater than 18 and less than 120 years.")]
        public int Idade { get; set; }

        public CadastroDto(string nome, int idade)
        {
            this.Nome = nome;
            this.Idade = idade;
        }
    }
}