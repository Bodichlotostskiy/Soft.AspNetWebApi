namespace RB_Soft.Data.Entities.Logging
{
    public class Log
    {
        public int LogId { get; set; }
        public string Message { get; set; }
        public LogLevel LogLevel { get; set; }

        public Log(string message, LogLevel logLevel)
        {
            Message = message;
            LogLevel = logLevel;
        }
    }
}
