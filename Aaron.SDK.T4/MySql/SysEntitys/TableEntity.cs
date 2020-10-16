using Dapper.Contrib.Extensions;
using System;

namespace Aaron.SDK.T4.MySql.SysEntitys
{
    /// <summary>
    /// 
    /// </summary>
    [Table("TABLES")]
    public class TableEntity
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
        public string TABLE_TYPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ENGINE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? VERSION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ROW_FORMAT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? TABLE_ROWS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? AVG_ROW_LENGTH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? DATA_LENGTH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? MAX_DATA_LENGTH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? INDEX_LENGTH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? DATA_FREE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? AUTO_INCREMENT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CREATE_TIME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UPDATE_TIME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CHECK_TIME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TABLE_COLLATION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? CHECKSUM { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CREATE_OPTIONS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TABLE_COMMENT { get; set; }
    }
}
