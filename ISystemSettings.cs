using System;
using System.Text.Json;

namespace NavigationCrashTest
{
    public interface ISystemSettings
    {
        public DefaultValueModel ReferenceData { get; }

        public DefaultValueModel DefaultAirport { get; }
        public DefaultValueModel DefaultCurrency { get; }

        public void UpdateDefaultAirport(DefaultValueModel model);
        public void UpdateDefaultCurrency(DefaultValueModel model);
    }

    public class DefaultValueModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class SystemSettings : ISystemSettings
    {

        public void UpdateDefaultAirport(DefaultValueModel model) => SetSettings(model);
        public void UpdateDefaultCurrency(DefaultValueModel model) => SetSettings(model);
        private DefaultValueModel _defaultCurrency;

        public DefaultValueModel ReferenceData => throw new NotImplementedException();

        public DefaultValueModel DefaultAirport => throw new NotImplementedException();

        public DefaultValueModel DefaultCurrency => throw new NotImplementedException();

        private static void SetSettings<T>(T model)
        {
            if (model == null)
            {
                //TODO: log something about an issue here
                return;
            }

            var key = typeof(T).FullName;


            if (key == null)
            {
                //TODO: log something about an issue here
                return;
            }

            var value = JsonSerializer.Serialize(model);
            Preferences.Set(key, value);
        }

        private static T GetSettings<T>() where T : class
        {
            var key = typeof(T).FullName;

            string preferenceData = null;

            if (key != null && Preferences.ContainsKey(key))
            {
                preferenceData = Preferences.Get(key, null);
            }

            return preferenceData == null ? null : JsonSerializer.Deserialize<T>(preferenceData);
        }
    }

}

