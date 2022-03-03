namespace aws_test.Dto
{
    public class FieldError
    {
        public string Key { get; set; }
        public IEnumerable<string> Value { get; set;}

        public FieldError(string key, IEnumerable<string> value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}