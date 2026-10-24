using Core;
using task2;

namespace Shop.Dal
{
    public class GoodDaoXmlRepository : XmlRepositoryBase<GoodDao>
    {
        public GoodDaoXmlRepository(string path) : base(path) { }
    }
}
