using Core;
using task2;

namespace Shop.Dal
{
    public class ShopDaoXmlRepository : XmlRepositoryBase<ShopDao>
    {
        public ShopDaoXmlRepository(string path) : base(path) { }
    }
}