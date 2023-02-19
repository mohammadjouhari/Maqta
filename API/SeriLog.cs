using Serilog;
namespace API
{
    public class SeriLog : ISeriLog
    {
        public void Log(string message)
        {
            File.AppendAllText("Logs/Error/applog.txt", message);
        }
    }
}
