using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApplication.Logging
{
    public interface ILoggerManager
    {
        void LogInfo(String message);
        void LogException(String message);
    }
}
