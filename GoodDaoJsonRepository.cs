using Core;
using task2;

namespace Shop.Dal
{
    public class GoodDaoJsonRepository : XmlRepositoryBase<GoodDao>
    {
        public GoodDaoJsonRepository(string path) : base(path) { }
    }
}

