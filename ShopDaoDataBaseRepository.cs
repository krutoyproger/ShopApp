using Core;
using task2;

namespace Shop.Dal
{
    public class ShopDaoDataBaseRepository : DataBaseRepositoryBase<ShopDao>
    {
        public ShopDaoDataBaseRepository(ShopEntityContext context)
            : base(context, context.Shops) { }
    }
}