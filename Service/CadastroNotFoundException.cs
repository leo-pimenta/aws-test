namespace aws_test.Service
{
    public class CadastroNotFoundException : Exception
    {
        public CadastroNotFoundException() {}
        public CadastroNotFoundException(string? message) : base(message) {}
        public CadastroNotFoundException(string? message, Exception? innerException) : base(message, innerException) {}
    }
}