using System.Collections.Generic;
using System.Linq;
using Aaron.SDK.T4.Extends;

namespace Aaron.SDK.T4.MySql.Models
{
    public enum TableType
    {
        /// <summary>
        /// 系统视图
        /// </summary>
        SYSTEM_VIEW,
        /// <summary>
        /// 表
        /// </summary>
        BASE_TABLE,
        /// <summary>
        /// 视图
        /// </summary>
        VIEW,
        /// <summary>
        /// 未知
        /// </summary>
        UnKnown
    }
    public class TableModel
    {
        /// <summary>
        /// 表原始名称
        /// </summary>
        public string OriginName { get; set; }
        /// <summary>
        /// 标准名称 驼峰
        /// </summary>
        public string Name
        {
            get
            {
                return OriginName.ToHumnName();
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 列
        /// </summary>
        public List<ColumnModel> Columns { get; set; } = new List<ColumnModel>();

        /// <summary>
        /// 数据字段 （除去共用字段）
        /// </summary>
        public List<ColumnModel> GetDataColumns(params string[] colNames)
        {
            //"Id","ExtraProperties","ConcurrencyStamp","CreationTime","CreatorId","LastModificationTime","LastModifierId","IsDeleted","DeleterId","DeletionTime"
            return Columns.Where(c => !colNames.Contains(c.Name)).ToList(); ;
        }
        /// <summary>
        /// 表类型
        /// </summary>
        public TableType TableType
        {
            get
            {
                switch (TableTypeStr)
                {
                    case "SYSTEM VIEW":
                        return TableType.SYSTEM_VIEW;
                    case "BASE TABLE":
                        return TableType.BASE_TABLE;
                    case "VIEW":
                        return TableType.VIEW;
                    default:
                        return TableType.UnKnown;
                }
            }
        }

        public string TableTypeStr { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        public ColumnModel PrimaryKey
        {
            get
            {
                return Columns.FirstOrDefault(a => a.KeyType == "PRI");
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}