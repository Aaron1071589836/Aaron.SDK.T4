using System;
using System.Collections.Generic;
using System.Linq;
using Aaron.SDK.T4.MySql.Models;
using Aaron.SDK.T4.MySql.SysEntitys;

namespace Aaron.SDK.T4.MySql
{
    public class GennerModelHelper
    {
        /// <summary>
        /// 表
        /// </summary>
        public List<TableModel> Tables { get; private set; } = new List<TableModel>();
        /// <summary>
        /// 存储过程及函数
        /// </summary>
        public List<ProcModel> Procs { get; set; } = new List<ProcModel>();
        public GennerModelHelper(string connect, string dbName)
        {          
            using (var db = new SystemDBContext(connect))
            {               
                var tbs = db.Query<TableEntity>($"select * from TABLES where TABLE_SCHEMA='{dbName}' and (TABLE_NAME like 'ecmis_%') ").ToList();
                var cols = db.Query<ColumnEntity>($"select * from COLUMNS where TABLE_SCHEMA='{dbName}'").ToList();
                foreach (var tb in tbs)
                {
                    var tbcols = cols.Where(c => c.TABLE_NAME == tb.TABLE_NAME).ToList();
                    var tcols = tbcols.OrderBy(a => a.ORDINAL_POSITION).Select(c => new ColumnModel
                    {
                        Description = c.COLUMN_COMMENT,
                        DefaultValue = c.COLUMN_DEFAULT,
                        FieldLength = c.CHARACTER_MAXIMUM_LENGTH,
                        AllowNull = c.IS_NULLABLE.Equals("YES", StringComparison.CurrentCultureIgnoreCase),
                        FieldType = c.DATA_TYPE,
                        OriginName = c.COLUMN_NAME,
                        ColumnType = c.COLUMN_TYPE,
                        KeyType = c.COLUMN_KEY,
                        Exta = c.EXTRA
                    }).ToList();

                    var tbMo = new TableModel
                    {
                        OriginName = tb.TABLE_NAME,
                        Description = tb.TABLE_COMMENT,
                        TableTypeStr = tb.TABLE_TYPE,
                        Columns = tcols,
                    };
                    Tables.Add(tbMo);
                }

                var @params = db.Query<ParameterEntity>($"select * from PARAMETERS where SPECIFIC_SCHEMA='{dbName}'").ToList();
                var procs = db.Query<ProcEntity>($"use mysql;select * from proc where db='{dbName}'").ToList();
                foreach (var proc in procs)
                {                  
                    var procParams = @params.Where(p => p.SPECIFIC_NAME == proc.specific_name).OrderBy(p => p.ORDINAL_POSITION).Select(p => new ProcParamModel
                    {
                        OriginName = p.PARAMETER_NAME,
                        ModeStr = p.PARAMETER_MODE,
                        ParamType = p.DATA_TYPE,
                        DtdIdentifier = p.DTD_IDENTIFIER
                    }).ToList();
                    var propModel = new ProcModel
                    {
                        OriginName = proc.specific_name,
                        Description = proc.comment,
                        Type = (MySqlProcType)Enum.Parse(typeof(MySqlProcType), proc.type),
                        Params = procParams
                    };

                    Procs.Add(propModel);
                }


            }
        }
    }
}
