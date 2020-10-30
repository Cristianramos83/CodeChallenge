using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string val = ConfigurationManager.AppSettings["ConfigIdioma"];
            string path = System.Environment.ExpandEnvironmentVariables(val);

            using (StreamReader file = File.OpenText(path))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
            }
        }
}
