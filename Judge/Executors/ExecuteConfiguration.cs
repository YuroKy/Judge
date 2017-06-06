namespace Judge.Models
{
    public class ExecuteConfiguration
    {
        public string Path { get; private  set; }
        public string StartArgument { get; private set; }

        public ExecuteConfiguration(string path, string startArgument)
        {
            this.Path = path;
            this.StartArgument = startArgument;
        }
    }
}