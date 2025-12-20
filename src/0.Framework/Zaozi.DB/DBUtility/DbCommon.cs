using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Zaozi.DB.DBUtility
{
    public class DbCommon
    {

        #region 读取INI配置文件
        [DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]//返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="Section">节点</param>
        /// <param name="Key">字段名</param>
        /// <param name="NoText"></param>
        /// <param name="iniFilePath">文件名称</param>
        /// <returns></returns>
        public static string ReadIniData(string Section, string Key, string NoText, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);
                return temp.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        public static string WriteIniData(string Section, string Key, string value, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                StringBuilder temp = new StringBuilder(1024);
                WritePrivateProfileString(Section, Key, value, iniFilePath);
                return temp.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        #region 读取指定SectionName 下面所有内容
        public static List<string> ReadKeys(string SectionName, string iniFilename)
        {
            List<string> result = new List<string>();
            Byte[] buf = new Byte[65536];
            uint len = GetPrivateProfileStringA(SectionName, null, null, buf, buf.Length, iniFilename);
            int j = 0;
            for (int i = 0; i < len; i++)
                if (buf[i] == 0)
                {
                    result.Add(Encoding.Default.GetString(buf, j, i - j));
                    j = i + 1;
                }
            return result;
        }
        #endregion

        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern uint GetPrivateProfileStringA(string section, string key,
    string def, Byte[] retVal, int size, string filePath);



        public static string GetPath()
        {
            if (string.IsNullOrEmpty(LogPath))
            {
                if (HttpContext.Current == null)
                {
                    string sPath = AppDomain.CurrentDomain.BaseDirectory;
                    string sFilePath = Path.Combine(Path.Combine(sPath, "Configs"), "db.ini");
                    if (!File.Exists(sFilePath))
                    {
                        sFilePath = "c://PayConfigs\\db.ini";
                    }
                    LogPath = sFilePath;

                    #region 判断是否已注册COM, 如果已注册, 则寻找对应注册位置的配置文件

                    //object obj = Type.GetTypeFromCLSID(new Guid("55F5FA50-4D7B-4380-8547-9C7875E03559"));
                    //if (obj != null)
                    //{
                    //    Type t = obj as Type;
                    //    if (t.Name == "TradeActivex")
                    //    {
                    //        sPath = t.Assembly.Location;
                    //        int i = sPath.LastIndexOf("\\");
                    //        LogPath = sPath.Substring(0, i);
                    //        LogPath = LogPath + "\\Configs\\db.ini";
                    //    }
                    //}

                    #endregion
                }
                else
                {
                    LogPath = HttpContext.Current.Request.PhysicalApplicationPath + "Configs\\db.ini";
                }
            }
            return LogPath;
        }
        #endregion

        private static string LogPath = "";

        #region 保存本地交易日志
        public static void WriteMyLogs(string sLogid, string sLogInfo)
        {
            DateTime dateNow = DateTime.Now;
            StreamWriter SW;
            string sPath = GetPath();
            string strLogFile = sPath + "MyLog\\" + DateTime.Now.Date.ToString("yyyy-MM-dd") + ".log";

            //判断是否存在文件夹
            if (!Directory.Exists(sPath + "MyLog\\"))
                Directory.CreateDirectory(sPath + "MyLog\\");
            //判断日志文件是否存在
            if (File.Exists(strLogFile))
                SW = File.AppendText(strLogFile);
            else
            {
                SW = File.CreateText(strLogFile);
            }

            try
            {
                StringBuilder strLog = new StringBuilder();
                strLog.Append(dateNow.ToString("yyyy-MM-dd HH:mm:ss").Trim() + "  Logid：" + sLogid + "==>");
                strLog.Append("  ");
                strLog.Append(sLogInfo);
                SW.Write(strLog.ToString() + "\r\n");
            }
            catch
            {

            }
            finally
            {
                SW.Close();
            }

        }
        #endregion

        private static Dictionary<string, string> lstDb = new Dictionary<string, string>();

        /// <summary>
        /// 根据传入的键值对初始化连接字符串
        /// </summary>
        /// <param name="conString">key:连接节点  value:加密的连接串</param>
        /// <returns>当前连接池的数量</returns>
        public static int InitConnectString(Dictionary<string, string> conString)
        {
            try
            {
                foreach (var d in conString)
                {
                    if (lstDb.ContainsKey(d.Key))
                        lstDb[d.Key] = DecryConString(d.Value);
                    else
                        lstDb.Add(d.Key, d.Value);
                }
                return lstDb.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 支持多库
        /// </summary>
        /// <param name="_Type"></param>
        /// <returns></returns>
        public static string GetConnectString(string _Type)
        {
            string sDb = "";
            lstDb.TryGetValue(_Type, out sDb);
            if (string.IsNullOrEmpty(sDb))
            {
                string sFilePath = DbCommon.GetPath();
                sDb = DbCommon.ReadIniData("DB", _Type, "", sFilePath);
                sDb = DecryConString(sDb);
                lstDb[_Type] = sDb;
            }

            return sDb;
        }

        /// <summary>
        /// 加解密连接字符串的key
        /// </summary>
        private const string Key = "YLW2011!";
        //默认密钥向量  
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        public static string EncryConString(string constring)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(Key.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(constring);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return constring;
            }
        }

        public static string DecryConString(string constring)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(Key);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(constring);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch (Exception ex)
            {
                return constring;
            }
        }

        public static string CreateConnectString(string tag, string ip, string port, string Account, string pwd, string dbName, string dbType)
        {
            string conString = "";
            if (dbType.ToUpper() == "SQL")
            {
                string sIp = "";
                if (string.IsNullOrEmpty(port))
                {
                    sIp = ip;
                }
                else
                {
                    sIp = string.Format("{0},{1}", ip, port);
                }
                conString = string.Format("Data Source={0};uid={1};pwd={2};database={3};",
                 sIp, Account, pwd, dbName);
            }
            else
            {
                conString = string.Format("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));Persist Security Info=True;User ID={3};Password={4};",
                   ip, port, dbName, Account, pwd);
            }

            return conString;
        }


    }
}
