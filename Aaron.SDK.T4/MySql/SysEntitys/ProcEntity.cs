using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aaron.SDK.T4.MySql.SysEntitys
{
    public class ProcEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string db { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string specific_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string language { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sql_data_access { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_deterministic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string security_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] param_list { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] returns { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] body { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string definer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime created { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime modified { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sql_mode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string character_set_client { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string collation_connection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string db_collation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] body_utf8 { get; set; }
    }
}
