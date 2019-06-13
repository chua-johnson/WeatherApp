using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Weather.Service
{
    public class WeatherService<TEntity> where TEntity : class
    {
        public TEntity GetWeather(bool isXMLMode)
        {
            string url = string.Empty;
            if(isXMLMode)
            {
                url = "https://samples.openweathermap.org/data/2.5/weather?q=London&appid=5be2aba81594246d144ac24bfa7867f8&mode=xml";
                return getWeatherXML(url);
            }
            else
            {
                url = "https://samples.openweathermap.org/data/2.5/weather?q=London&appid=5be2aba81594246d144ac24bfa7867f8";
                return getWeatherJSON(url);
            }
            
            
        }

        private TEntity getWeatherJSON(string apiURL)
        {
            WebRequest requestGet = WebRequest.Create(apiURL);
            requestGet.Method = "GET";
            HttpWebResponse responseGet = (HttpWebResponse)requestGet.GetResponse();

            string jsonString = null;
            using (Stream stream = responseGet.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
            }
            return JsonConvert.DeserializeObject<TEntity>(jsonString);
        }

        private TEntity getWeatherXML(string apiURL)
        {
            WebRequest requestGet = WebRequest.Create(apiURL);
            requestGet.Method = "GET";
            HttpWebResponse responseGet = (HttpWebResponse)requestGet.GetResponse();

            using (Stream stream = responseGet.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                XmlSerializer serializer = new XmlSerializer(typeof(TEntity));
                return (TEntity)serializer.Deserialize(reader);
            }
        }
    }
}
