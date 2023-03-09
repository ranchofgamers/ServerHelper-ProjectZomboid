using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerHelper.Core.MapResetTool
{
    public class DeserializeZoneReport : Exception
    {
        public string ID { get; }
        public DeserializeType Type { get; }
        public DeserializeZoneReport(string message, string id, DeserializeType type) : base(message)
        {
            ID = id;
            Type = type;
        }
    }
    public enum DeserializeType
    {
        Successfully,
        Error,
        Skipped
    }
}
