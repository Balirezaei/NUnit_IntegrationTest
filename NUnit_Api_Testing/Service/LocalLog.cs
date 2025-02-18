namespace NUnit_Api_Testing.Service
{
    public interface ILocalLogger
    {
        void Log(string message);
    }
    public class LocalLog : ILocalLogger
    {
        public void Log(string message)
        {
            ///
        }
    }
}
