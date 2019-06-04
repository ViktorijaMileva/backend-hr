using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hr_management_system.Services
{
    public interface ILogging
    {
         void writeToLog(string path, string method);
    }
}