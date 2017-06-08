using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JTTT
{
    public static class Serializer
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string FilePath = "..//..//..//SerializeFile.txt";

        public static void WriteToJsonFile<T>(T objectToWrite) where T : new()
        {
            log.Info("Writing to JSON file");
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(FilePath);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                writer?.Close();
            }
        }

        public static T ReadFromJsonFile<T>() where T : new()
        {
            log.Info("reading from JSON file");
            TextReader reader = null;
            try
            {
                reader = new StreamReader(FilePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(fileContents);
            }
            finally
            {
                reader?.Close();
            }
        }
    }
}
