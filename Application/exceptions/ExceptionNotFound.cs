namespace Application.exceptions
{
    public class ExceptionNotFound : Exception
    {
        public ExceptionNotFound() : base()
        {
        }
        public ExceptionNotFound(string message) : base(message)
        {
        }
        public ExceptionNotFound(string message, Exception ex) : base(message)
        {
        }
    }
}
