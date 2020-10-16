using System;
using System.Collections.Generic;
using System.Linq;

namespace Aaron.SDK.T4.MySql.Models
{
    public class DataTypeModel
    {
        public Dictionary<string, string> MySqlDataTypes { get; set; } = new Dictionary<string, string>
        {
            { "bit", "bool" },
            { "tinyint", "sbyte" },
            { "smallint", "short" },
            { "int", "int" },
            { "bigint", "long" },

            { "varchar", "string" },
            { "varbinary", "string" },
            { "text", "string" },
            { "longtext", "string" },
            { "char", "string" },
            { "set", "string" },
            { "enum", "string" },
            { "mediumtext", "string" },

            { "decimal", "decimal" },
            { "double", "double" },
            { "float", "float" },

            { "date", "DateTime" },
            { "time", "TimeSpan" },                
            { "datetime", "DateTime" },
            { "timestamp", "DateTime" },
            
            { "blob", "byte[]" },
            { "longblob", "byte[]" },
            { "mediumblob", "byte[]" },
        };
        private string mysqlFileTypeName { get; set; }
        public string CSharpTypeName
        {
            get
            {
                try
                {
                    return MySqlDataTypes.FirstOrDefault(a => a.Key == mysqlFileTypeName).Value;
                }
                catch (Exception)
                {
                    return mysqlFileTypeName;
                }
            }
        }

        public DataTypeModel(string mysqlFileTypeName)
        {
            this.mysqlFileTypeName = mysqlFileTypeName;


        }
    }
}
