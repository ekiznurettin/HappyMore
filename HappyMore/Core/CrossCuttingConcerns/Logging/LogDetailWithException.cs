using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogDetailWithException:LogDetail
    {
        public string ExceptionMessasge { get; set; }
        public string Username { get; set; }
    }
}
