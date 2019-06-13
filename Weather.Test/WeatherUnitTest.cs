using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather.DomainModel.JSONModel;
using Weather.DomainModel.XMLModel;
using Weather.Service;

namespace Weather.Test
{
    [TestClass]
    public class WeatherUnitTest
    {
        [TestMethod]
        public void GetWeatherJSON_TEST()
        {
            RootObject rootObject = new RootObject();
            WeatherService<RootObject> weatherService = new WeatherService<RootObject>();
            rootObject = weatherService.GetWeather(false);

            Assert.IsNotNull(rootObject);
            Assert.IsNotNull(rootObject.main);
            Assert.AreEqual(rootObject.main.humidity,81);
        }

        [TestMethod]
        public void GetWeatherXML_TEST()
        {
            Current current = new Current();
            WeatherService<Current> weatherService = new WeatherService<Current>();
            current = weatherService.GetWeather(true);

            Assert.IsNotNull(current);
            Assert.IsNotNull(current.Humidity);
            Assert.AreEqual(current.Humidity.Value,"81");
        }
    }
}
