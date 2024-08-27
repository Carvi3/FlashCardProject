namespace FlashCardAPI.Exceptions
{
    public class ContentNotFoundException : Exception
    {
        public ContentNotFoundException() : base() { }
        public ContentNotFoundException(string message) : base(message)
        {
        }
        
    }
}
