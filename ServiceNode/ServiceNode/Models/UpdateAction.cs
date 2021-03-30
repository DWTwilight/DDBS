using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceNode.Models
{
    public enum UpdateType
    {
        SetValue,
        AddValue,
        SubValue
    }
    public class UpdateAction
    {
        public string AttName { get; set; }
        public UpdateType Type { get; set; }
        public string Value { get; set; }
    }
}
