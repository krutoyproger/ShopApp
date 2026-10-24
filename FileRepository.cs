using System.Collections.Generic;
using System.IO;
using Core;

namespace task2
{
    public abstract class FileRepository<T> : IRepository<T> where T : class, IPrimary
    {
        protected readonly string FilePath;

        protected FileRepository(string filePath) => FilePath = filePath;

        protected abstract string Serialize(T item);
        protected abstract T Deserialize(string line);

        public IReadOnlyList<T> GetAll()
        {
            var list = new List<T>();
            if (!File.Exists(FilePath)) return list;
            foreach (var line in File.ReadAllLines(FilePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                    list.Add(Deserialize(line));
            }
            return list;
        }

        public void Save(List<T> items)
        {
            var lines = new List<string>();
            foreach (var item in items) lines.Add(Serialize(item));
            File.WriteAllLines(FilePath, lines);
        }

        // Заглушки для интерфейса, чтобы проект собрался
        public void Add(T item) { }
        public T GetById(int id) => null;
        public bool Update(T item) => false;
        public bool Delete(int id) => false;
    }
}