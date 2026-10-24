
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace task2
{
    public class ShopDaoFileRepository : FileRepository<ShopDao>
    {
        public ShopDaoFileRepository(string filePath = "shops.txt")
            : base(filePath) { }

        protected override string Serialize(ShopDao shop) =>
            DaoFileFormat.Join(
                shop.Id,
                shop.Name,
                shop.Code);

        protected override ShopDao Deserialize(string line)
        {
            string[] parts = DaoFileFormat.Split(line, 3);

            return new ShopDao
            {
                Id = DaoFileFormat.ParseId(parts[0], line),
                Name =(parts[1]),
                Code = (parts[2])
            };
        }
    }

}
