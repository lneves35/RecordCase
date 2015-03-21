using System.IO;
using System.Xml.Serialization;

namespace RecordCase.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static string SerializeObject<T>(this T toSerialize)
        {
            var xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (var textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
    }
}
