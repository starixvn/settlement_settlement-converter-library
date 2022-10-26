using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Fanex.Settlement.Converter.Services;

public interface XmlConvertService
{
    string Serialize<T>(T results);

    T? Deserialize<T>(string input);
}

public class XmlConvertServiceImp : XmlConvertService
{
    private static XmlSerializerNamespaces NamespaceSettings
    {
        get
        {
            var setting = new XmlSerializerNamespaces();
            setting.Add(string.Empty, string.Empty);

            return setting;
        }
    }

    private static XmlWriterSettings Settings => new()
    {
        Encoding = new UnicodeEncoding(false, false),
        Indent = false,
        OmitXmlDeclaration = true
    };

    public string Serialize<T>(T results)
    {
        var serializer = new XmlSerializer(typeof(T));

        var stringBuilder = new StringBuilder();

        using var xmlWriter = XmlWriter.Create(stringBuilder, Settings);
        serializer.Serialize(xmlWriter, results, NamespaceSettings);

        return stringBuilder.ToString();
    }

    public T? Deserialize<T>(string input)
    {
        var ser = new XmlSerializer(typeof(T));

        using var sr = new StringReader(input);
        return (T)ser.Deserialize(sr)!;
    }
}