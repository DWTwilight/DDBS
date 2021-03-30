using MetaNode.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetaNode.Services
{
    public class TableService
    {
        public static string tableRoot;

        private readonly ILogger<TableService> logger;

        public ConcurrentDictionary<string, TableInfo> Tables { get; set; }

        public TableService(ILogger<TableService> logger)
        {
            this.logger = logger;
            this.Tables = new ConcurrentDictionary<string, TableInfo>();
            ReadFromFileAsync().Start();
        }

        private Task ReadFromFileAsync()
        {
            if (!Directory.Exists(tableRoot))
            {
                Directory.CreateDirectory(tableRoot);
                return Task.CompletedTask;
            }
            var tableFiles = Directory.GetFiles(tableRoot);

            Parallel.ForEach(tableFiles, tFile =>
            {
                try
                {
                    TableInfo tableInfo = null;
                    using (var sr = new StreamReader(tFile))
                    {
                        tableInfo = JsonSerializer.Deserialize<TableInfo>(sr.ReadToEnd());
                    }
                    if (tableInfo == null)
                    {
                        logger.LogError("Cannot read Table : " + tFile);
                    }
                    Tables.TryAdd(tableInfo.Name, tableInfo);
                }
                catch (Exception e)
                {
                    logger.LogError(e.Message);
                }
            });
            logger.LogInformation("Table MetaInfo Loaded.");
            return Task.CompletedTask;
        }

        private Task FlushAllToFileAsync()
        {
            Parallel.ForEach(Tables, tableInfo =>
            {
                using (var sw = new StreamWriter(tableRoot + "/" + tableInfo.Key + ".tbl"))
                {
                    sw.WriteLine(JsonSerializer.Serialize(tableInfo.Value));
                    sw.Flush();
                }
            });
            return Task.CompletedTask;
        }

        private Task FlushToFileAsync(string tableName)
        {
            var tableInfo = Tables[tableName];
            using (var sw = new StreamWriter(tableRoot + "/" + tableInfo.Name + ".tbl"))
            {
                sw.WriteLine(JsonSerializer.Serialize(tableInfo));
                sw.Flush();
            }
            return Task.CompletedTask;
        }

        public Task CreateTableAsync(string tableName)
        {
            if (Tables.ContainsKey(tableName))
            {
                throw new Exception("Table has existed!");
            }
            var tableInfo = new TableInfo()
            {
                TimeStamp = DateTime.Now,
                Name = tableName,
                Attributes = new Dictionary<string, Attribute>(),
                RecordCount = 0,
                Blocks = new List<BlockInfo>()
            };
            Tables.TryAdd(tableName, tableInfo);
            FlushToFileAsync(tableName).Start();
            return Task.CompletedTask;
        }
    }
}
