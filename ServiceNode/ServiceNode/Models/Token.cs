using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceNode.Models
{
    public class Token
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ExpireTime { get; set; }

        public Token(string userID, int validHours)
        {
            UserID = userID;
            CreateTime = DateTime.Now;
            ExpireTime = CreateTime.AddHours(validHours);
        }

        public bool IsValid()
        {
            return DateTime.Now < ExpireTime;
        }
    }
}
