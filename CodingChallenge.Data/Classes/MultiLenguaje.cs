using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public static class MultiLenguaje
    {
        public static string val;
        public static string path;
        public static JObject jsonLanguage;
                
        public static string GetValue(string key,EnumeradorIdioma enumeradorIdioma)
        {
            switch (enumeradorIdioma)
            {
                case EnumeradorIdioma.Castellano:
                    val = ConfigurationManager.AppSettings["ConfigIdiomaAR"];
                    break;
                case EnumeradorIdioma.Ingles:
                    val = ConfigurationManager.AppSettings["ConfigIdiomaUS"];
                    break;
                default:
                    val = ConfigurationManager.AppSettings["ConfigIdioma"];
                    break;
            }
            path = System.Environment.ExpandEnvironmentVariables(val);
            using (StreamReader file = File.OpenText(path))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                jsonLanguage = (JObject)JToken.ReadFrom(reader);
            }

            return jsonLanguage.GetValue(key).ToString();
        }
        public static string GetValue(string key)
        {            
            val = ConfigurationManager.AppSettings["ConfigIdioma"];
            path = System.Environment.ExpandEnvironmentVariables(val);
            using (StreamReader file = File.OpenText(path))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                jsonLanguage = (JObject)JToken.ReadFrom(reader);
            }

            return jsonLanguage.GetValue(key).ToString();
        }


    }
}
