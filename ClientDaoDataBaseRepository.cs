using Core;
using task2;

namespace Shop.Dal
{
    public class ClientDaoDataBaseRepository : DataBaseRepositoryBase<ClientDao>
    {
        public ClientDaoDataBaseRepository(ShopEntityContext context)
            : base(context, context.Clients) { }
    }
}