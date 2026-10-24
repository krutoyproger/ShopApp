using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace task2
{
    public abstract class JsonRepositoryBase<T>
    {
        protected readonly string FilePath;

        protected JsonRepositoryBase(string filePath) => FilePath = filePath;

        public List<T> GetAll()
        {
            if (!File.Exists(FilePath))
                return new List<T>();

            string json = File.ReadAllText(FilePath, Encoding.UTF8);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        public void Save(List<T> items)
        {
            string json = JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(FilePath, json, new UTF8Encoding(false));
        }
    }
}
