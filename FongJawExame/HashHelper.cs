using System.Security.Cryptography;
using System.Text;

public static class HashHelper
{
    public static string ComputeSha256Hash(string rawData)
    {
        // �ϥ� SHA256 �ӭp�⫢�ƭ�
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // �p�⫢�ƭ�
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // �N byte array �ഫ�� string
            var builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
