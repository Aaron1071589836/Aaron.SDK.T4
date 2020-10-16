using Dapper.Contrib.Extensions;

namespace Aaron.SDK.T4.MySql.SysEntitys
{
    [Table("COLUMNS")]
    public class ColumnEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string TABLE_CATALOG { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TABLE_SCHEMA { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TABLE_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>    
        public string COLUMN_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ORDINAL_POSITION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COLUMN_DEFAULT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IS_NULLABLE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DATA_TYPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? CHARACTER_MAXIMUM_LENGTH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? CHARACTER_OCTET_LENGTH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? NUMERIC_PRECISION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? NUMERIC_SCALE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? DATETIME_PRECISION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CHARACTER_SET_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COLLATION_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COLUMN_TYPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COLUMN_KEY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EXTRA { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PRIVILEGES { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COLUMN_COMMENT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GENERATION_EXPRESSION { get; set; }
    }
}
