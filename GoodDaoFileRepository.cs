using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class GoodDaoFileRepository : FileRepository<GoodDao>
    {
        public GoodDaoFileRepository(string filePath = "goods.txt")
            : base(filePath) { }

        protected override string Serialize(GoodDao good) =>
            DaoFileFormat.Join(
                good.Id,
                good.Name,
                good.Code);

        protected override GoodDao Deserialize(string line)
        {
            string[] parts = DaoFileFormat.Split(line, 3);

            return new GoodDao
            {
                Id = DaoFileFormat.ParseId(parts[0], line),
                Name = parts[1],
                Code = parts[2],
            };
        }
    }
}
