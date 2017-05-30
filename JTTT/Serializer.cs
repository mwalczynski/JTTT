using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JTTT
{
    public static class Serializer
    {
        public static string FilePath = "..//..//..//SerializeFile.txt";

        public static void WriteToJsonFile<T>(T objectToWrite) where T : new()
        {
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
