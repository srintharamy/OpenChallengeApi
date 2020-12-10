using System.Collections.Generic;

namespace WebApiContactChallenge.Common.Configuration
{
    /// <summary>
    ///     To avoid injecting Config in all layer
    /// </summary>
    public static class ConfigHelper
    {
        public const string ConnectionStringKey = "ConnectionStrings:ApiContactChallenge";

        private static readonly Dictionary<string, string> Configs = new Dictionary<string, string>();

        public static void SetConfig(string key, string value)
        {
            if (!Configs.ContainsKey(key))
            {
                Configs.Add(key, value);
            }
        }

        public static string GetConfig(string key)
        {
            return Configs[key];
        }
    }
}