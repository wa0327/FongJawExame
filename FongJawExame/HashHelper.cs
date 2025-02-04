using System.Security.Cryptography;
using System.Text;

public static class HashHelper
{
    public static string ComputeSha256Hash(string rawData)
    {
        // 使用 SHA256 來計算哈希值
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // 計算哈希值
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // 將 byte array 轉換為 string
            var builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
