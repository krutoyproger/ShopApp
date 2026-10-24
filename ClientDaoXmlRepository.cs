using Core;
using task2;

namespace Shop.Dal
{
    public class ClientDaoXmlRepository : XmlRepositoryBase<ClientDao>
    {
        public ClientDaoXmlRepository(string path) : base(path) { }
    }
}
