using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aaron.SDK.T4.Extends;

namespace Aaron.SDK.T4.MySql.Models
{
    public enum MySqlProcType
    {
        /// <summary>
        /// 过程
        /// </summary>
        PROCEDURE,
        /// <summary>
        /// 函数
        /// </summary>
        FUNCTION
    }
    /// <summary>
    /// 存储过程及函数
    /// </summary>
    public class ProcModel
    {
        /// <summary>
        /// 类型
        /// </summary>
        public MySqlProcType Type { get; set; }
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
        /// 描述信息
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public List<ProcParamModel> @Params { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string InterfaceStr()
        {
            var returnParams = @Params.Where(p => !p.Direction.HasValue).ToList();//返回参数
            var otherParams = @Params.Where(p => p.Direction.HasValue).ToList();//其他参数
            var inParams = otherParams.Where(p => p.Direction.Value == ParamDirection.IN).ToList();//输入参数
            var outParams = otherParams.Where(p => p.Direction.Value == ParamDirection.OUT).ToList();//输出参数

            var funHead = "";           
            var rerurnTypeStr = "";
           
            switch (Type)
            {
                case MySqlProcType.PROCEDURE:
                    if (outParams.Any())
                    {
                        if (outParams.Count == 1)
                        {
                            rerurnTypeStr = outParams.FirstOrDefault().CSharpTypeName;
                        }
                        else
                        {
                            rerurnTypeStr = $"({ string.Join(",", outParams.Select(p => $"{p.CSharpTypeName} {p.Name}"))})";
                        }
                    }
                    else
                    {
                        rerurnTypeStr = "int";
                    }

                    funHead = $"\t\t{rerurnTypeStr} {this.Name}({string.Join(",", otherParams.Select(p => $"{p.CSharpTypeName} {p.Name}"))})";                    
                    break;
                case MySqlProcType.FUNCTION:

                    if (returnParams.Any())
                    {
                        if (returnParams.Count == 1)
                        {
                            rerurnTypeStr = returnParams.FirstOrDefault().CSharpTypeName;                           
                        }
                        else
                        {
                            rerurnTypeStr = $"({ string.Join(",", returnParams.Select(p => $"{p.CSharpTypeName} {p.Name}"))})";                           
                        }
                    }
                    else
                    {
                        rerurnTypeStr = "void";
                    }
                    funHead = $"\t\t{rerurnTypeStr} {this.Name}({string.Join(",", otherParams.Select(p => $"{p.CSharpTypeName} {p.Name}"))})";                
                    break;
                default:
                    break;
            }
            return $"{funHead};";
        }
        /// <summary>
        /// 重写ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var returnParams = @Params.Where(p => !p.Direction.HasValue).ToList();//返回参数
            var otherParams = @Params.Where(p => p.Direction.HasValue).ToList();//其他参数
            var inParams = otherParams.Where(p => p.Direction.Value == ParamDirection.IN).ToList();//输入参数
            var outParams = otherParams.Where(p => p.Direction.Value == ParamDirection.OUT).ToList();//输出参数

            var funHead = "";
            var funBody = "";
            var rerurnTypeStr = "";

            funBody += $"\t\t\tvar @params = new {{ {string.Join(",", otherParams.Select(p => $"{p.OriginName} = {p.Name}"))} }};\r\n";
            switch (Type)
            {
                case MySqlProcType.PROCEDURE:
                    if (outParams.Any())
                    {
                        if (outParams.Count == 1)
                        {
                            rerurnTypeStr = outParams.FirstOrDefault().CSharpTypeName;
                        }
                        else
                        {
                            rerurnTypeStr = $"({ string.Join(",", outParams.Select(p => $"{p.CSharpTypeName} {p.Name}"))})";
                        }
                    }
                    else
                    {
                        rerurnTypeStr = "int";
                    }

                    funHead = $"\t\tpublic {rerurnTypeStr} {this.Name}({string.Join(",", otherParams.Select(p => $"{p.CSharpTypeName} {p.Name}"))})";
                    if (outParams.Any())
                    {
                        funBody += $"\t\t\tthis.ExecuteProc(\"{this.OriginName}\",@params);\r\n";
                        if (outParams.Count == 1)
                        {
                            funBody += $"\t\t\tvar res = @params.{outParams.FirstOrDefault().OriginName};\r\n";
                        }
                        else
                        {
                            funBody += $"\t\t\tvar res =  ({string.Join(",", outParams.Select(p => $"@params.{p.OriginName}"))});\r\n";
                        }
                    }
                    else
                    {
                        funBody += $"\t\t\tvar res = this.ExecuteProc(\"{this.OriginName}\",@params);\r\n";
                    }
                    funBody += "\t\t\treturn res;\r\n";
                    break;
                case MySqlProcType.FUNCTION:

                    if (returnParams.Any())
                    {
                        if (returnParams.Count == 1)
                        {
                            rerurnTypeStr = returnParams.FirstOrDefault().CSharpTypeName;
                            funBody += $"\t\t\tvar res = this.ExecuteFun<{returnParams.FirstOrDefault().CSharpTypeName}>(\"{this.OriginName}\",@params);\r\n";
                        }
                        else
                        {
                            rerurnTypeStr = $"({ string.Join(",", returnParams.Select(p => $"{p.CSharpTypeName} {p.Name}"))})";
                            funBody += $"\t\t\tvar res = this.ExecuteFun<({string.Join(",", returnParams.Select(p => $"{p.CSharpTypeName} {p.Name}"))})>(\"{this.OriginName}\",@params);\r\n";
                        }
                    }
                    else
                    {
                        rerurnTypeStr = "void";
                    }
                    funHead = $"\t\tpublic {rerurnTypeStr} {this.Name}({string.Join(",", otherParams.Select(p => $"{p.CSharpTypeName} {p.Name}"))})";
                    funBody += "\t\t\treturn res;\r\n";
                    break;
                default:
                    break;
            }
            return $"{funHead}\r\n\t\t{{\r\n{funBody}\r\n\t\t}}";
        }
    }
}
