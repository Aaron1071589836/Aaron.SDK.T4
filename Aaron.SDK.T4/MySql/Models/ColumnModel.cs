using Aaron.SDK.T4.Extends;

namespace Aaron.SDK.T4.MySql.Models
{
    /// <summary>
    /// 数据库列属性
    /// </summary>
    public class ColumnModel
    {
        /// <summary>
        /// 列原始名称
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
        /// 去掉换行符
        /// </summary>
        public string DescriptionInline
        {
            get
            {
                return Description.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ");
            }
        }

        /// <summary>
        /// 字段类型
        /// </summary>
        public string FieldType { get; set; }
        /// <summary>
        /// 主键 PRI
        /// </summary>
        public string KeyType { get; set; }
        /// <summary>
        /// 自增长 auto_increment
        /// </summary>
        public string Exta { get; set; }
        /// <summary>
        /// 如 varchar(16)
        /// </summary>
        public string ColumnType { get; set; }
        /// <summary>
        /// 对应C# 类型
        /// </summary>
        public string CSharpTypeName
        {
            get
            {
                return new DataTypeModel(FieldType).CSharpTypeName;
            }
        }
        /// <summary>
        /// 字段修饰符
        /// </summary>
        public string FieldModifier
        {
            get
            {
                var modifier = CSharpTypeName;
                var nullAble = AllowNull && modifier != "string" && modifier != "byte[]" ? "?" : "";
                return $"{modifier}{nullAble}";
            }
        }

        /// <summary>
        /// 允许为空
        /// </summary>
        public bool AllowNull { get; set; }
        /// <summary>
        /// 字段长度
        /// </summary>
        public long? FieldLength { get; set; }
        /// <summary>
        /// 字段默认值
        /// </summary>
        public object DefaultValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToStringWithDescription()
        {
            var remark = Description.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
            var prop = $"/// <summary>\r\n\t\t/// {remark}\r\n\t\t/// </summary>";
            prop += $"\r\n\t\t[Description(\"{remark}\")]";
            prop += $"\r\n\t\tpublic {FieldModifier} {Name} {{ get; set; }}";
            return prop;
        }

        /// <summary>
        /// 字段描述
        /// </summary>
        /// <returns></returns>
        public string GetNote()
        {
            var remark = Description.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ");
            var prop = $"/// <summary>\r\n\t\t/// {remark}\r\n\t\t/// </summary>";
            return prop;
        }

        /// <summary>
        /// 重写ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var prop = $"public {FieldModifier} {Name} {{ get; set; }}";
            return prop;
        }
    }
}
