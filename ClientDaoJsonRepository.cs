using Core;
using task2;

namespace Shop.Dal
{
    public class ClientDaoJsonRepository : JsonRepositoryBase<ClientDao>
    {
        public ClientDaoJsonRepository(string path) : base(path) { }
    }
}