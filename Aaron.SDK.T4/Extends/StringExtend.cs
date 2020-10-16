using System.Linq;
using System.Text;

namespace Aaron.SDK.T4.Extends
{
    public static class StringExtends
    {
        /// <summary>
        /// 转小驼峰
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string ToLittleHumnName(this string fieldName)
        {
            var s = fieldName.ToHumnName();
            return s.Substring(0, 1).ToLower() + s.Substring(1);
        }
        /// <summary>
        /// 下划线命名转大驼峰命名
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string ToHumnName(this string fieldName)
        {
            if (null == fieldName)
            {
                return "";
            }           
            //fieldName = fieldName.ToLower();
            //fieldName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(fieldName);
            fieldName = fieldName.Substring(0, 1).ToUpper() + fieldName.Substring(1);
            if (!fieldName.Contains("_"))
                return fieldName;
            char[] chars = fieldName.ToArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];
                if (c == '_')
                {
                    int j = i + 1;
                    if (j < chars.Length)
                    {
                        sb.Append(chars[j].ToString().ToUpper());
                        i++;
                    }
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 驼峰命名转下划线命名
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static string ToUnderlineName(this string propertyName)
        {
            if (null == propertyName)
            {
                return "";
            }
            propertyName = propertyName.Substring(0, 1).ToLower() + propertyName.Substring(1);
            char[] chars = propertyName.ToCharArray();
            StringBuilder sb = new StringBuilder();
            foreach (char c in chars)
            {
                if (char.IsUpper(c))
                {
                    sb.Append("_" + c.ToString().ToLower());
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

    }
}
