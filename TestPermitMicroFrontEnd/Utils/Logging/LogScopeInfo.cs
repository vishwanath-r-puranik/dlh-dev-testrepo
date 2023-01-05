using System;
using System.Collections.Generic;

namespace TestPermitMicroFrontEnd.Utils.Logging
{
    public class LogScopeInfo
    {
        public LogScopeInfo()
        {
        }

        public string Text { get; set; }
        public Dictionary<string, object> Properties { get; set; }
    }
}
