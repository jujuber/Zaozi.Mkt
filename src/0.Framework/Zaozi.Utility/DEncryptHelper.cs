using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Zaozi.Utility
{
    /// <summary>
    /// 加密解密类
    /// </summary>
    public class DEncryptHelper
    {


        /// <summary>
        /// 计算签名信息
        /// </summary>
        /// <param name="parameters">代价密的键值对</param>
        /// <param name="publickey">签名密钥</param>
        /// <returns>计算后的签名</returns>
        public static string MakeSign(IDictionary<string, string> parameters, string publickey)
        {
            string signContent = GetSignContent(parameters);
            string sBlock = signContent + "&key=" + publickey;
            return MakeSigns(sBlock, true);
        }

        /// <summary>
        /// 计算签名
        /// </summary>
        /// <param name="sBlock">待签名的字符串</param>
        /// <param name="publickey">密钥</param>
        /// <returns></returns>
        public static string MakeSign(string sBlock, string publickey)
        {
            sBlock = sBlock + "&key=" + publickey;
            return MakeSigns(sBlock, true);
        }

        /// <summary>
        /// 计算签名
        /// </summary>
        /// <param name="block">待签名的字符串</param>
        /// <param name="isToUpper">是否转大写</param>
        /// <returns></returns>
        public static string MakeSigns(string block, bool isToUpper)
        {
            //转url格式
            string str = block;
            using var md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }

            string sResult = sb.ToString();

            if (isToUpper) return sb.ToString().ToUpper();
            else return sb.ToString();
        }

        /// <summary>
        /// 计算待加密的字符串
        /// </summary>
        /// <param name="parameters">参数键值对</param>
        /// <returns>待加密的字符串</returns>
        public static string GetSignContent(IDictionary<string, string> parameters)
        {
            return GetSignContent(parameters, true);
        }

        /// <summary>
        /// 计算待加密的字符串
        /// </summary>
        /// <param name="parameters">待加密的key-value值</param>
        /// <param name="isCheckValue">空值是否过滤 true：过滤 false：不过滤</param>
        /// <returns>待加密的字符串</returns>
        public static string GetSignContent(IDictionary<string, string> parameters, bool isCheckValue)
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder("");
            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (key.ToUpper() == "SIGN") continue;
                if (!string.IsNullOrEmpty(key))
                {
                    if (isCheckValue)
                    {
                        if (!string.IsNullOrEmpty(value))
                            query.Append(key).Append("=").Append(value).Append("&");
                    }
                    else
                        query.Append(key).Append("=").Append(value).Append("&");
                }
            }
            string content = query.ToString().Substring(0, query.Length - 1);

            return content;
        }



        #region 加密 MD5 DES URLCODE

        #region ========MD5加密（可逆）========
        #region ========加密========

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Encrypt(string Text)
        {
            return Encrypt(Text, "YYOUO^*^^(*)(+_)|)+()+_(_)(");
        }
        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Encrypt(string Text, string sKey)
        {
            using DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            using CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        #endregion

        #region ========解密========


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, "YYOUO^*^^(*)(+_)|)+()+_(_)(");
        }
        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Decrypt(string Text, string sKey)
        {
            using DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            using CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        #endregion
        #endregion

        #region ========MD5加密（不可逆）========
        /// <summary>
        /// MD5加密(不可逆) 16位
        /// </summary>
        /// <param name="a_strString"></param>
        /// <returns></returns>
        public static string MD5Encrypt16bit(string a_strString)
        {
            using MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(a_strString));
            return ConvertToHex(result).Substring(0, 16);
        }

        /// <summary>
        /// MD5加密(不可逆)
        /// </summary>
        /// <param name="a_strString"></param>
        /// <returns></returns>
        public static string MD5Encrypt32bit(string a_strString)
        {
            using MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(a_strString));
            return ConvertToHex(result).ToString();
        }

        private static string ConvertToHex(byte[] bArr)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bArr.Length; i++)
            {
                byte b = bArr[i];
                int value = (b & 0xFF) + (b < 0 ? 128 : 0);
                sb.Append(value < 16 ? "0" : "");
                sb.Append(value.ToString("x"));
            }
            return sb.ToString();
        }
        #endregion

        #region ==========DES加密（可逆）=======
        /// <summary>
        /// 对称加密法
        /// </summary>
        public class DES
        {
            private byte[] biv = { 0xA4, 0x19, 0xCD, 0x6F, 0x99, 0xCC, 0x53, 0x1C };
            private string _Key = "HZG_XF10";
            /// <summary>
            /// 密钥
            /// </summary>
            public string Key
            {
                get { return _Key; }
                set { _Key = value; }
            }

            /// <summary>
            /// 加密(数据Unicode编码)
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            public string Encode(string data)
            {
                return Coding(data, 0);
            }

            /// <summary>
            /// 加密(数据Unicode编码)
            /// </summary>
            /// <param name="data"></param>
            /// <param name="key">密钥</param>
            /// <returns></returns>
            public string Encode(string data, string key)
            {
                this._Key = key;
                return Encode(data);
            }

            /// <summary>
            /// 解密数据
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            public string Decode(string data)
            {
                return Coding(data, 1);
            }

            /// <summary>
            /// 解密数据
            /// </summary>
            /// <param name="data"></param>
            /// <param name="key">密钥</param>
            /// <returns></returns>
            public string Decode(string data, string key)
            {
                this._Key = key;
                return Decode(data);
            }

            public string DeCodeU(string data)
            {
                return Coding(data, 0);
            }
            private string Coding(string data, int oper)
            {
                using MemoryStream memstream = new MemoryStream();
                using DESCryptoServiceProvider desser = new DESCryptoServiceProvider();
                byte[] bkey = Encoding.ASCII.GetBytes(Key);
                byte[] bdata;
                ICryptoTransform ict;
                string rts = "";
                try
                {
                    if (oper == 0)
                    {
                        bdata = Encoding.Unicode.GetBytes(data);
                        ict = desser.CreateEncryptor(bkey, biv);
                    }
                    else
                    {
                        bdata = Convert.FromBase64String(data);
                        ict = desser.CreateDecryptor(bkey, biv);
                    }
                    using CryptoStream crs = new CryptoStream(memstream, ict, CryptoStreamMode.Write);
                    crs.Write(bdata, 0, bdata.Length);
                    crs.FlushFinalBlock();
                    if (oper == 0)
                    {
                        rts = Convert.ToBase64String(memstream.GetBuffer(), 0, (int)memstream.Length);
                    }
                    else
                    {
                        rts = Encoding.Unicode.GetString(memstream.GetBuffer(), 0, (int)memstream.Length);
                    }
                    memstream.Close();
                }
                catch { }
                return rts;
            }
        }
        #endregion

        #region URLCode

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DESEncode(string str)
        {
            DES des = new DES();
            return des.Encode(str);
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string DESDecode(string code)
        {
            return new DES().Decode(code);
        }

        /// <summary>
        /// URL参数加密 DES
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlEncode(string str)
        {
            str += "$HZG$" + DateTime.Now.Day.ToString();
            return HttpUtility.UrlEncode(DESEncode(str));
        }

        /// <summary>
        /// URL参数解密 DES (当天有)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string UrlDecode(string code)
        {
            string decode = DESDecode(code);
            if (decode == "") return "";
            string[] ss = decode.Split(new string[] { "$HZG$" }, StringSplitOptions.RemoveEmptyEntries);
            if (ss.Length != 2) return "";
            if (ss[1] != DateTime.Now.Day.ToString())
                return "";
            return ss[0];
        }
        #endregion
        #endregion



        public static string MD5Encrypt(string strText)
        {
            using var md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(strText));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }
            //所有字符转为大写

            string sResult = sb.ToString().ToUpper();

            return sResult;
        }

    }
}
