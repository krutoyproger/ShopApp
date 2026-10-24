using Core;
using task2;

namespace Shop.Dal
{
    public class ShopDaoJsonRepository : JsonRepositoryBase<ShopDao>
    {
        public ShopDaoJsonRepository(string path) : base(path) { }
    }
}