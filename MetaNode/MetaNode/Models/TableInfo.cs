using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaNode.Models
{
    /// <summary>
    /// stores metatdata of an attibute
    /// </summary>
    public class AttributeInfo
    {
        /// <summary>
        /// Attribute's name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Attribute's Type (int, char, bool, string, etc...)
        /// </summary>
        public Type Type { get; set; }
        /// <summary>
        /// Index of the attritbute, start from 0
        /// </summary>
        public int Index { get; set; }
    }

    public class BlockInfo
    {
        /// <summary>
        /// the last timestamp when this block was modified
        /// </summary>
        public DateTime TimeStamp { get; set; }
        /// <summary>
        /// Name of the table
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// Index of the block, start from 0
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Identifier of the datanode that stores this block
        /// </summary>
        public string DataNodeName { get; set; }
        /// <summary>
        /// Identifier of the backup datanode that stores a copy of this block
        /// </summary>
        public string BackupNodeName { get; set; }
        /// <summary>
        /// number of records stores in this block
        /// </summary>
        public int RecordCount { get; set; }
        /// <summary>
        /// the index of the first record stored in this block
        /// </summary>
        public int StartIndex { get; set; }
        /// <summary>
        /// the index of the last record stored in this block
        /// </summary>
        public int EndIndex { get; set; }
    }

    /// <summary>
    /// Stores metadata of a table
    /// </summary>
    public class TableInfo
    {
        /// <summary>
        /// The last timestamp when the table was modified
        /// </summary>
        public DateTime TimeStamp { get; set; }
        /// <summary>
        /// Table Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Attributes of the table
        /// </summary>
        public Dictionary<string, Attribute> Attributes { get; set; }
        /// <summary>
        /// The total number of records currently stored in the table
        /// </summary>
        public int RecordCount { get { return Blocks == null ? 0 : Blocks.Sum(b => b.RecordCount); } set { RecordCount = value; } }
        /// <summary>
        /// Blocks of the table
        /// </summary>
        public List<BlockInfo> Blocks { get; set; }
    }
}
