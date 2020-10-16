using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aaron.SDK.T4.MySql.SysEntitys
{
    public class ParameterEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string SPECIFIC_CATALOG { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SPECIFIC_SCHEMA { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SPECIFIC_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ORDINAL_POSITION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PARAMETER_MODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PARAMETER_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DATA_TYPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? CHARACTER_MAXIMUM_LENGTH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? CHARACTER_OCTET_LENGTH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? NUMERIC_PRECISION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? NUMERIC_SCALE { get; set; }
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
        public string DTD_IDENTIFIER { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ROUTINE_TYPE { get; set; }
    }
}
