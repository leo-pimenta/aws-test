using AutoMapper;
using aws_test.Database;
using aws_test.Domain;
using aws_test.Dto;
using aws_test.Service;
using Microsoft.AspNetCore.Mvc;

namespace aws_test.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CadastroController : Controller
    {
        private readonly IMapper Mapper;
        private readonly ICadastro CadastroService;

        public CadastroController(CadastroContext context, IMapper mapper, ICadastro cadastroService) : base(context)
        {
            this.Mapper = mapper;
            this.CadastroService = cadastroService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(CadastroDto dto)
        {
            var cadastro = Mapper.Map<Cadastro>(dto);
            await CadastroService.Save(cadastro);
            return Created($"{HttpContext.Request.Path}/{cadastro.Id}", null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCadastro(Guid id)
        {
            try
            {
                return Ok(await CadastroService.Get(id));
            }
            catch (CadastroNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await CadastroService.GetAll());
        }
    }
}