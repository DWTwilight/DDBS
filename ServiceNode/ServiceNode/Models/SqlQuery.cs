using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceNode.Models
{
    public enum SqlQueryType
    {
        CreateTable,
        Insert,
        Delete,
        Update,
        Retrieve,
        DropTable,
        CreateIndex,
        DropIndex
    }
    public class SqlQuery
    {
        public SqlQueryType Type { get; set; }
        public string TableName { get; set; }
    }

    public class CreateTableQuery : SqlQuery
    {
        public CreateTableQuery()
        {
            this.Type = SqlQueryType.CreateTable;
        }
    }

    public class InsertQuery : SqlQuery
    {
        public List<string> Values { get; set; }
        public InsertQuery()
        {
            this.Type = SqlQueryType.Insert;
        }
    }

    public class DeleteQuery : SqlQuery
    {
        public List<Condition> Conditions { get; set; }
        public DeleteQuery()
        {
            this.Type = SqlQueryType.Delete;
        }
    }

    public class UpdateQuery : SqlQuery
    {
        public List<UpdateAction> Actions { get; set; }
        public List<Condition> Conditions { get; set; }
        public UpdateQuery()
        {
            this.Type = SqlQueryType.Update;
        }
    }
}
