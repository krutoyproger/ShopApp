using Core;
using task2;

namespace Shop.Dal
{
    public class GoodDaoDataBaseRepository : DataBaseRepositoryBase<GoodDao>
    {
        public GoodDaoDataBaseRepository(ShopEntityContext context)
            : base(context, context.Goods) { }
    }
}
