using System.Text;
using System.Security.Cryptography;
using System.IO;


namespace OnlineUpdate
{
    internal enum HashType
    {
        md5,
        sha1,
        sha512

    }
    internal static class Hasher
    {
        internal static string HashFile(string filePath, HashType algo)
        {
            switch (algo)
            {
                case HashType.md5:
                    return MakeHashString(MD5.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case HashType.sha1:
                    return MakeHashString(SHA1.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case HashType.sha512:
                    return MakeHashString(SHA512.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                default:
                    return "";
            }

        }

        private static string MakeHashString(byte[] hash)
        {
            StringBuilder s = new StringBuilder();

            foreach (byte b in hash)
                s.Append(b.ToString("x2").ToLower());

            return s.ToString();

        }
    }
}
