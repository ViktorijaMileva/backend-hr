using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Hr_management_system.Services
{
    public class Logging // : ILogging
    {
        public static void writeToLog(string uri, string method)
        {
            string path = Path.GetFullPath(@"Logs/employees_log.dat");

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                try
                {
                    sw.WriteLine(DateTime.Now + " [" + method + "] URL: " + uri);
                    sw.Flush();
                }
                catch(IOException ex)
                {
                    ex.GetBaseException();
                }
                finally
                {
                    sw.Close();
                }
            }
        }
    }
}