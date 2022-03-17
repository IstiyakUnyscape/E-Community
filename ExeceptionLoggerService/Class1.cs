using System;

namespace ExeceptionLoggerService
{
    public interface IExceptionLogger
    {

        public void LogException(string Exception);
    }

    public class ExceptionLogger : IExceptionLogger
    {
        private readonly string _FullLoggerPath;

        public ExceptionLogger(string LoggerFilePath)
        {
            _FullLoggerPath = LoggerFilePath;
        }
        public void LogException(string Exception)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(_FullLoggerPath);
            if (!fi.Exists)
            {
                fi.Create();
            }
            else
            {
                using(System.IO.StreamWriter sr = new System.IO.StreamWriter(_FullLoggerPath,true))
                {

                    sr.WriteLine("===== Exception Starts=======");
                    sr.WriteLine(Exception);
                    sr.WriteLine("===== Exception End=======");
                    sr.Close();
                }
            }
        }
    }

}
