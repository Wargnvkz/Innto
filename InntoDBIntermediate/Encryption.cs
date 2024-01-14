using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace InntoDBIntermediate
{
    public class Encryption
    {
        //private static byte[] key = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 };
        //private static byte[] key4 = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6 };
        static string aes_key =   "fyu7LJ0Ha8wszbTptf5dOYxZOJhYFloj59ZzHv2brTk=";
        static string aes_key_1 = "fyuJH4JDFkiyfgi75eikvJKf8u6foFhThdYZJhFloZz=";
        static string aes_key_2 = "fyu7LJ0HoseisIv67bir6iODJh8YFloj59ZzHv2brTk=";
        static string aes_iv = "fMcbgfPXCEH8xBTgbXdtbQ==";
        static Encryption()
        {
            {
                var aes_key1 = Convert.FromBase64String(aes_key_1);
                var aes_key2 = Encoding.Unicode.GetString(aes_key1, 0, aes_key1.Length);
                var aes_key3 = AesEncrypt(aes_key2);
                var aes_key4 = Encoding.Unicode.GetBytes(aes_key3);
                aes_key = Convert.ToBase64String(aes_key4);
            }
            {
                var aes_key1 = Convert.FromBase64String(aes_key_2);
                var aes_key2 = Encoding.Unicode.GetString(aes_key1, 0, aes_key1.Length);
                var aes_key3 = AesEncrypt(aes_key2);
                var aes_key4 = Encoding.Unicode.GetBytes(aes_key3);
                aes_key = Convert.ToBase64String(aes_key4);
            }
            {
                var aes_key1 = Convert.FromBase64String(aes_key);
                var aes_key2 = Encoding.Unicode.GetString(aes_key1, 0, aes_key1.Length);
                var aes_key3 = AesEncrypt(aes_key2);
                var aes_key4 = Encoding.Unicode.GetBytes(aes_key3);
                aes_key = Convert.ToBase64String(aes_key4);
            }
        }

        public static void Encrypt<T>(T input)
        {
            var type = input.GetType();
            List<MemberInfo> members = new List<MemberInfo>();
            members.AddRange(type.GetFields());
            members.AddRange(type.GetProperties());
            foreach (MemberInfo member in members)
            {
                Type mt;
                var fi = member as FieldInfo;
                if (fi != null && fi.FieldType == typeof(string))
                {
                    var s = fi.GetValue(input) as string;
                    s = AesEncrypt(s);//EncryptString(s);
                    fi.SetValue(input, s);
                }
                else
                {
                    var pi = member as PropertyInfo;
                    if (pi != null && pi.PropertyType == typeof(string))
                    {
                        var s = pi.GetValue(input) as string;
                        s = AesEncrypt(s);// EncryptString(s);
                        pi.SetValue(input, s);
                    }
                }
            }
        }
        public static void Decrypt<T>(T input)
        {
            var type = input.GetType();
            List<MemberInfo> members = new List<MemberInfo>();
            members.AddRange(type.GetFields());
            members.AddRange(type.GetProperties());
            foreach (MemberInfo member in members)
            {
                Type mt;
                var fi = member as FieldInfo;
                if (fi != null && fi.FieldType == typeof(string))
                {
                    var s = fi.GetValue(input) as string;
                    s = AesDecrypt(s);//DecryptString(s);
                    fi.SetValue(input, s);
                }
                else
                {
                    var pi = member as PropertyInfo;
                    if (pi != null && pi.PropertyType == typeof(string))
                    {
                        var s = pi.GetValue(input) as string;
                        s = AesDecrypt(s);
                        pi.SetValue(input, s);
                    }
                }
            }
        }

        /* private static string EncryptString(string s)
         {
             if (s == null) return null;
             var sb = new StringBuilder();
             for (int i = 0; i < s.Length; i++)
             {
                 sb.Append((char)(s[i]^1));
             }
             return sb.ToString();
         }
         private static string DecryptString(string s)
         {
             if (s == null) return null;
             var sb = new StringBuilder();
             for (int i = 0; i < s.Length; i++)
             {
                 sb.Append((char)(s[i]^1));
             }
             return sb.ToString();
         }*/

        private static string AesEncrypt(string s)
        {
            if (s == null) return null;
            var bytes = Encoding.Unicode.GetBytes(s);
            System.Security.Cryptography.Aes aes = System.Security.Cryptography.Aes.Create();
            aes.Padding = PaddingMode.Zeros;
            /*aes.GenerateKey();
            aes.GenerateIV();
            aes_key = Convert.ToBase64String(aes.Key);
            aes_iv = Convert.ToBase64String(aes.IV);*/
            var Key = Convert.FromBase64String(aes_key);
            var IV = Convert.FromBase64String(aes_iv);
            var encryptor = aes.CreateEncryptor(Key, IV);
            var resbytes = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
            var resstring = Encoding.Unicode.GetString(resbytes, 0, resbytes.Length);
            return resstring;
        }
        private static string AesDecrypt(string s)
        {
            if (s == null) return null;
            var bytes = Encoding.Unicode.GetBytes(s);
            System.Security.Cryptography.Aes aes = System.Security.Cryptography.Aes.Create();
            aes.Padding = PaddingMode.Zeros;
            var Key = Convert.FromBase64String(aes_key);
            var IV = Convert.FromBase64String(aes_iv);
            var decryptor = aes.CreateDecryptor(Key, IV);
            var resbytes = decryptor.TransformFinalBlock(bytes, 0, bytes.Length);
            var resstring = Encoding.Unicode.GetString(resbytes, 0, resbytes.Length);
            return resstring;
        }

        /*public static string EncryptAES(string plainText)
        {
            byte[] encrypted;

            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Key = Convert.FromBase64String(aes_key);
                aes.IV = Convert.FromBase64String(aes_iv);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform enc = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, enc, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }

                        encrypted = ms.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        public static string DecryptAES(string encryptedText)
        {
            string decrypted = null;
            byte[] cipher = Convert.FromBase64String(encryptedText);

            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Key = Convert.FromBase64String(aes_key);
                aes.IV = Convert.FromBase64String(aes_iv);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform dec = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(cipher))
                {
                    using (CryptoStream cs = new CryptoStream(ms, dec, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            decrypted = sr.ReadToEnd();
                        }
                    }
                }
            }

            return decrypted;
        }*/
    }
}