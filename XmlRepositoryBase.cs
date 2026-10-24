using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Core
{
    public abstract class XmlRepositoryBase<T>
    {
        protected readonly string FilePath;

        protected XmlRepositoryBase(string filePath) => FilePath = filePath;

        public List<T> GetAll()
        {
            if (!File.Exists(FilePath))
                return new List<T>();

            var serializer = new XmlSerializer(typeof(List<T>));
            using (var stream = File.OpenRead(FilePath))
            {
                return (List<T>)serializer.Deserialize(stream);
            }
        }

        public void Save(List<T> items)
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            using (var writer = new StreamWriter(FilePath, false, new UTF8Encoding(false)))
            {
                serializer.Serialize(writer, items);
            }
        }
    }
}
