using UnityEngine;
using System.Collections;
using System;
using System.Text;



namespace TestTool
{
	public static class StringExtension 
	{
	
	    /// <summary>
	    /// 判断字符串中是否包含中文
	    /// </summary>
	    /// <param name="str">需要判断的字符串</param>
	    /// <returns>判断结果</returns>
	    public static bool HasChinese(this string str)
	    {
	        return System.Text.RegularExpressions.Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
	    }
	
	    public static bool HasSpace(this string str)
	    {
	        return str.IndexOf(" ") >= 0;
	    }

        public static bool IsNumber(this string str)
        {
            try
            {
                Convert.ToDouble(str);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public static bool IsEnglishWord(this string str)
        {
            foreach (char c in str)
            {
                byte[] arrCN = Encoding.Default.GetBytes(new[]{c});
                if (arrCN.Length > 1)
                    return false;
            }
            return true;
        }

        static public string GetPinyinHeads(this string strText)
        {
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                myStr += getSpell(strText[i]);
            }
            return myStr;
        }

        static private string getSpell(string cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "*";
            }
            else return cnChar;
        }
        static private char getSpell(char cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(new[]{cnChar});
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) })[0];
                    }
                }
                return '*';
            }
            else return cnChar;
        }

	}
}
