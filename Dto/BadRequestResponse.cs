namespace aws_test.Dto
{
    public class BadRequestResponse
    {
        public IEnumerable<FieldError> Errors { get; set; }

        public BadRequestResponse(IEnumerable<FieldError> errors)
        {
            this.Errors = errors;
        }
    }
}