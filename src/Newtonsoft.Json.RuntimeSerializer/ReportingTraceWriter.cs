using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Newtonsoft.Json.RuntimeSerializer
{
    public class ReportingTraceWriter : ITraceWriter
    {
        public TraceLevel LevelFilter => TraceLevel.Verbose | TraceLevel.Info;

        public void Trace(TraceLevel level, string message, Exception ex)
        {
            Console.WriteLine($"Level: {level} - Message: {message}");
            if (ex != null)
                Console.Error.WriteLine($"Exception: {ex.Message}");
        }
    }
}
