using aws_test.Database;
using Microsoft.AspNetCore.Mvc;

namespace aws_test.Controllers
{
    public abstract class Controller : ControllerBase
    {
        protected readonly CadastroContext DbContext;

        public Controller(CadastroContext context)
        {
            DbContext = context;
        }
    }
}