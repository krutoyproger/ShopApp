using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class ClientDaoFileRepository : FileRepository<ClientDao>
    {
        public ClientDaoFileRepository(string filePath = "clients.txt")
            : base(filePath) { }

        protected override string Serialize(ClientDao client) =>
            DaoFileFormat.Join(
                client.Id,
                client.FirstName,
                client.LastName,
                client.Patronymic,
                DaoFileFormat.FormatDate(client.BirthDate));

        protected override ClientDao Deserialize(string line)
        {
            string[] parts = DaoFileFormat.Split(line, 5);

            return new ClientDao
            {
                Id = DaoFileFormat.ParseId(parts[0], line),
                FirstName =parts[1],
                LastName = parts[2],
                Patronymic = parts[3],
                BirthDate = DaoFileFormat.ParseDate(parts[4], line)
            };
        }
    }
}
