using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaNode.Models
{
    public enum OP
    {
        Equals,
        NotEqual,
        LessThan,
        LessEqual,
        Greater,
        GreaterEqual
    }

    public class Condition
    {
        public string AttName { get; set; }
        public OP Op { get; set; }
        public string CompValue { get; set; }
    }
}
