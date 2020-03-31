using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WareHouse.Core.Helper
{
    public class Md5Helper
    {
        /// <summary>
        /// md5字符串加密
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string GetMd5(string txt)
        {
            using MD5 mi = MD5.Create();
            byte[] buffer = Encoding.Default.GetBytes(txt);
            //开始加密
            byte[] newBuffer = mi.ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();
            foreach (var t in newBuffer)
            {
                sb.Append(t.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// md5流加密
        /// </summary>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        public static string GenerateMd5(Stream inputStream)
        {
            using MD5 mi = MD5.Create();
            //开始加密
            byte[] newBuffer = mi.ComputeHash(inputStream);
            StringBuilder sb = new StringBuilder();
            foreach (var t in newBuffer)
            {
                sb.Append(t.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}