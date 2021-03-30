using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceNode.Models
{
    [Table("client")]
    public class Client
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }
        [Column("password")]
        public string Password { get; set; }
    }
}
