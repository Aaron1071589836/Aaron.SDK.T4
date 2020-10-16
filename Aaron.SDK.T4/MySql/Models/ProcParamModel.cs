using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aaron.SDK.T4.Extends;

namespace Aaron.SDK.T4.MySql.Models
{
    public enum ParamDirection
    {
        /// <summary>
        /// 输入
        /// </summary>
        IN,
        /// <summary>
        /// 输出
        /// </summary>
        OUT
    }
    /// <summary>
    /// 参数
    /// </summary>
    public class ProcParamModel
    {
        /// <summary>
        /// 驼峰命名
        /// </summary>
        public string Name
        {
            get
            {
                return OriginName.ToHumnName();
            }
        }
        /// <summary>
        /// 过程原始名称
        /// </summary>
        public string OriginName { get; set; }
        /// <summary>
        /// 输入输出  IN OUT
        /// </summary>
        public string ModeStr { get; set; }
        /// <summary>
        /// 输入输出类型 in out
        /// </summary>
        public ParamDirection? Direction
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ModeStr))
                {
                    return (ParamDirection)Enum.Parse(typeof(ParamDirection), ModeStr);
                }
                return null;
            }
        }
        /// <summary>
        /// 参数类型
        /// </summary>
        public string ParamType { get; set; }
        /// <summary>
        /// 对应C# 类型
        /// </summary>
        public string CSharpTypeName
        {
            get
            {
                return new DataTypeModel(ParamType).CSharpTypeName;
            }
        }
        /// <summary>
        /// 数据类型 如decimal(12,2)
        /// </summary>
        public string DtdIdentifier { get; set; }
    }
}
