using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace BlueMedia.Extensions;

public static class Extension
{
    public static string Sha256(this string content)
    {
        using var crypt = SHA256.Create();
        var hash = new StringBuilder();
        var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(content));
        foreach (var theByte in crypto)
        {
            hash.Append(theByte.ToString("x2"));
        }
        
        return hash.ToString();
    }
    
    public static string DecodeBase64(this string value)
    {
        var valueBytes = Convert.FromBase64String(value);
        return Encoding.UTF8.GetString(valueBytes);
    }
    
    public static T FromXml<T>(this string value)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StringReader(value);
        return (T)serializer.Deserialize(reader)!;
    }
}