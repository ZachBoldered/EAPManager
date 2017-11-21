using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Pos
{
    /// <summary>
    /// AES 加密解密
    /// </summary>
    public class AES
    {
        //默认密钥向量
        private static byte[] Keys = { 0x41, 0x72, 0x65, 0x79, 0x6F, 0x75, 0x6D, 0x79, 0x53, 0x6E, 0x6F, 0x77, 0x6D, 0x61, 0x6E, 0x3F };

        //密钥
        public static string KeyValue = "12345678901234567890123456789012";

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为32位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptAES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] inputData = UTF8Encoding.UTF8.GetBytes(encryptString);

                RijndaelManaged rijndaelProvider = new RijndaelManaged();
                rijndaelProvider.Key = UTF8Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32));
                rijndaelProvider.IV = Keys;
                ICryptoTransform rijndaelEncrypt = rijndaelProvider.CreateEncryptor();

                byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);

                return Convert.ToBase64String(encryptedData);
            }
            catch
            {
                return "Encrypt Failed!";
            }
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为32位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptAES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] inputData = Convert.FromBase64String(decryptString);

                RijndaelManaged rijndaelProvider = new RijndaelManaged();
                rijndaelProvider.Key = UTF8Encoding.UTF8.GetBytes(decryptKey.Substring(0, 32));
                rijndaelProvider.IV = Keys;
                ICryptoTransform rijndaelDecrypt = rijndaelProvider.CreateDecryptor();

                byte[] decryptedData = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);
                return UTF8Encoding.UTF8.GetString(decryptedData);
            }
            catch
            {
                return "Decrypt Failed!";  
            }
        }
    }

    /// <summary>
    /// DES 加密解密
    /// </summary>
    public class DES
    {
        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        //密钥
        public static string KeyValue = "19840117";

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return "Encrypt Failed!";
            }
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return "Decrypt Failed!";     
            }
        }
    }

    /// <summary>
    /// 哈希加密包括MD5,SHA1加密
    /// </summary>
    public class Hash
    {
        /// <summary>
        /// MD5函数
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>MD5结果</returns>
        public static string MD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(str);
            byte[] result = md5.ComputeHash(data);
            string ret = "";
            for (int i = 0; i < result.Length; i++)
                ret += result[i].ToString("x").PadLeft(2, '0');
            return ret;
        }

        /// <summary>
        /// SHA1函数
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>SHA1结果</returns>
        public static string SHA1(string str)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(str);
            byte[] result = sha1.ComputeHash(data);
            return Convert.ToBase64String(result); //返回长度为64字节的字符串
        }
    }
}
