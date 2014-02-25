using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using XMS.Core;

namespace WebServiceForApp
{
    public class SecurityHelper
    {
        public static Regex DigitalAndLetterRegex = new Regex(@"[a-zA-Z0-9\|\-]+", RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// 解密
        /// </summary>
        public static string Decryptro(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return "";
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                return "";
            }

            string sDecrypt = null;

            AesCryptoServiceProvider provider = new AesCryptoServiceProvider();

            byte[] buffer = strToHexByte(value);

            provider.Key = strToHexByte(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key, "MD5").ToUpper());
            provider.IV = new byte[16];

            provider.Mode = CipherMode.ECB;

            using (MemoryStream stream = new MemoryStream())
            {
                using (CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    stream2.Write(buffer, 0, buffer.Length);
                    stream2.FlushFinalBlock();
                    sDecrypt = Encoding.UTF8.GetString(stream.ToArray());
                }
            }

            return sDecrypt;
        }

        /// <summary>
        /// 加密
        /// </summary>
        public static string Encryptro(string key, string value)
        {
            byte[] bIV = new byte[16];
            byte[] byteArray = Encoding.UTF8.GetBytes(value);

            string encrypt = null;

            AesManaged aes = new AesManaged();
            aes.Mode = CipherMode.ECB;
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(
                    strToHexByte(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key, "MD5").ToUpper()),
                    bIV), CryptoStreamMode.Write))
                {
                    cStream.Write(byteArray, 0, byteArray.Length);
                    cStream.FlushFinalBlock();
                    encrypt = byteToHexStr(mStream.ToArray());
                }
            }

            return encrypt;
        }


        private static byte[] strToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        private static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

    }
}
