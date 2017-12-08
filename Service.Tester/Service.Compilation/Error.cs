namespace Service.Compilation
{
    public class Error
    {
        public string Message { get; set; }
        public override string ToString()
        {
            return Message;
        }
    }
}