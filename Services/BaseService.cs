using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace HOCBusiness.Services
{
    public class BaseService
    {
        public string BaseUrl { get; set; }

        public T DeserialiseJson<T>(string url)
        {
            var endpoint = (HttpWebRequest)WebRequest.Create(url);
            var response = endpoint.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
            }
        }

        public T DeserialiseXml<T>(string url)
        {
            var endpoint = (HttpWebRequest)WebRequest.Create(url);
            var response = endpoint.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                using (var reader = XmlReader.Create(streamReader))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(reader);
                }
            }
        }

    }
}
